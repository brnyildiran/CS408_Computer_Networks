using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2021_SpringStep1Server
{
    public partial class Form1 : Form
    {
        int lineCount = File.ReadLines(@"../../user-db.txt").Count();

        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<Socket> clientSockets = new List<Socket>();
        Dictionary<String, Socket> clientSocketsDict = new Dictionary<String, Socket>();

        List<string> clientusernames = new List<string>();
        List<Tuple<string, string>> friendsList = new List<Tuple<string, string>>(); // (me, friend)


        int postCount = CountPost();

        bool terminating = false;
        bool listening = false;
        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);

            if (new FileInfo(@"../../friendship.txt").Length != 0)
            {
                List<String> friends = File.ReadAllLines(@"../../friendship.txt").ToList();
                foreach (string friendship in friends)
                {
                    var f = Tuple.Create(friendship.Split('-')[0], friendship.Split('-')[1]);
                    friendsList.Add(f);
                }
                File.WriteAllText(@"../../friendship.txt", string.Empty);
            }


            InitializeComponent();
        }

        private void button_listen_Click(object sender, EventArgs e)
        {
            int port;
            if (Int32.TryParse(textBox_port.Text, out port))
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, port); //listen in any interface, initialize end point here. 
                serverSocket.Bind(endPoint);
                serverSocket.Listen(3); 

                listening = true;
                button_listen.Enabled = false;

                //When client disconnect no problem in the server so no need to check here with try. 
                Thread acceptThread = new Thread(Accept); // Thread to accept new clients from now on. 
                acceptThread.Start();

                serverLogs.AppendText("Started listening on port: " + port + "\n");

            }
            else
            {
                serverLogs.AppendText("Please check port number \n");
            }

        }

        private void Accept() //Accepting new clients to the server. 
        {

            while (listening)
            {
                try
                {
                    Socket newClient = serverSocket.Accept(); // accept corresponding sockets for clients.

                    // Need to check username whether from database or not.
                    Thread usernameCheckThread = new Thread(() => usernameCheck(newClient));
                    usernameCheckThread.Start();

                }
                catch
                {
                    if (terminating) // If we close the server. No crash, correctly closed and not listening from now on. 
                    {
                        listening = false;
                    }
                    else //Problem occured here. 
                    {
                        serverLogs.AppendText("The socket stopped working.\n");
                    }

                }
            }

        }

        private void usernameCheck(Socket thisClient)
        {
            string message = "NOT_FOUND"; // will be used for usernames from outside the database. 
            try
            {
                Byte[] username_buffer = new Byte[64];
                thisClient.Receive(username_buffer);

                string username = Encoding.Default.GetString(username_buffer); // Convert byte array to string.
                username = username.Substring(0, username.IndexOf("\0"));
                //username = username.Trim('\0');

                if (clientusernames.Contains(username)) // if in database but already connected.
                {
                    serverLogs.AppendText(username + " has tried to connect from another client!\n");
                    message = "Already_Connected";
                }
                else
                {
                    var lines = File.ReadLines(@"../../user-db.txt"); // check the txt line by line.
                    foreach (var line in lines)
                    {
                        if (line == username) // if the db contains the username, can connect !
                        {
                            clientSockets.Add(thisClient);
                            clientusernames.Add(username);
                            
                            message = "SUCCESS";
                            serverLogs.AppendText(username + " has connected.\n");
                            
                            //After the client is connected, Received information from the client's actions.
                            Thread receiveThread = new Thread(() => Receive(thisClient, username)); //Receive posts.
                            receiveThread.Start();
                            
                        }
                    }

                }
                if(message=="NOT_FOUND")
                {
                    serverLogs.AppendText(username + " tried to connect to the server but cannot!\n");
                }
                try
                {
                    thisClient.Send(Encoding.Default.GetBytes(message)); //send the corresponding message to the client.
                    Console.WriteLine("AFTER SEND TO CURRENT CLIENT");
                    clientSocketsDict.Add(username, thisClient);
                    Console.WriteLine("AFTER ADD TO DICT");
                    sendOfflineNotification(username, clientSocketsDict[username]);
                    Console.WriteLine("AFTER SEND OFFLINE NOTIF");

                }
                catch
                {
                    serverLogs.AppendText("There was a problem when sending the username response to the client.\n");
                }
            }

            catch
            {
                serverLogs.AppendText("Problem receiving username.\n");
            }


        }

        private void Receive(Socket thisClient, string username)//Actions from clients.
        {
            bool connected = true; //To receive information, should be connected by default.
            while (connected && !terminating) //still connected and not closing.
            {
                try
                {
                    Byte[] buffer = new Byte[64];
                    thisClient.Receive(buffer);//Gets information related to thisclient.

                    string incomingMessage = Encoding.Default.GetString(buffer);//convert byte array to string.
                    //incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));
                    incomingMessage = incomingMessage.Trim('\0');

                    //string label = incomingMessage.Substring(0, 10);

                    if (incomingMessage.Substring(0, 10) == "DISCONNECT")
                    {
                        thisClient.Close();
                        clientSockets.Remove(thisClient);
                        clientusernames.Remove(username);//remove it from the connected list.
                        clientSocketsDict.Remove(username);
                        
                        connected = false;
                        serverLogs.AppendText(username + " has disconnected\n");
                    }
                    else if (incomingMessage.Substring(0, 10) == "SHOW_POSTS")
                    {
                        allposts(thisClient, username); //This function will print all posts when requested. 
                    }
                    else if (incomingMessage.Substring(0, 10) == "SEND_POSTS")
                    {
                        string post = incomingMessage.Substring(10);
                        postCount += 1;
                        postToLog(username, postCount, post);
                    }
                    else if (incomingMessage.Substring(0,10) == "DELET_POST")
                    {
                        String postID = incomingMessage.Substring(10);
                        deletePost(postID, username, thisClient);
                    }
                    else if(incomingMessage.Substring(0, 10) == "ADD_FRIEND")
                    {
                        String friend_username = incomingMessage.Substring(10);
                        addFriend(friend_username, username, thisClient);
                    }
                    else if(incomingMessage.Substring(0, 10) == "SEEFRIENDS")
                    {
                        seeAllFriends(username, thisClient);
                    }
                    else if (incomingMessage.Substring(0, 10) == "FRIENDPOST")
                    {
                        seeFriendsPosts(username, thisClient);
                    }
                    else if (incomingMessage.Substring(0, 10) == "YOUR_POSTS")
                    {
                        seeOwnPosts(username, thisClient);
                    }
                    else if (incomingMessage.Substring(0, 10) == "REMOVE_FRI")
                    {
                        String friend_username = incomingMessage.Substring(10);
                        removeFriend(friend_username, username, thisClient);
                    }
                    serverLogs.ScrollToCaret();


                }
                catch
                {
                    if (!terminating)
                    {
                        serverLogs.AppendText(username + " has disconnected.\n");
                    }
                    thisClient.Close();
                    clientSockets.Remove(thisClient);
                    clientusernames.Remove(username);
                    clientSocketsDict.Remove(username);
                    string temp_friend = "";
                    if (friendsList.Count != 0)
                    {
                        foreach (Tuple<string, string> friendship in friendsList)
                        {
                            Console.WriteLine("appending " + friendship.Item1 + "and" + friendship.Item2 + "\n");
                            temp_friend += friendship.Item1 + "-" + friendship.Item2 + '\n'; 
                        }
                        File.AppendAllText(@"../../friendship.txt", temp_friend);
                    }
                    
                    connected = false;
                    serverLogs.ScrollToCaret();

                }
            }

        }

        private void removeFriend(string friend_username, string own_username, Socket thisClient)
        {
            //If the username don't exist in the user_db, give an error
            List<string> lines = File.ReadAllLines("../../posts.log").ToList();
            var users = File.ReadLines(@"../../user-db.txt").ToList();

            if (!users.Contains(friend_username)) // if in database but already connected.
            {
                serverLogs.AppendText("This user does not exist!\n");
                Byte[] buffer = Encoding.Default.GetBytes("DONOTEXISTThis user does not exist!");
                thisClient.Send(buffer);
            }

            else
            {
                bool isDuplicate = false;
                if (friend_username == own_username) //sending a friend req. to yourself
                {
                    serverLogs.AppendText("You cannot remove yourself from your friends list!\n");
                    Byte[] buffer_cnt_rmv_slf = Encoding.Default.GetBytes("CANT_RSELFYou cannot remove yourself from your friends list!");
                    thisClient.Send(buffer_cnt_rmv_slf);
                }

                else
                {
                    if (friendsList.Count == 0)
                    {
                        serverLogs.AppendText("Invalid request!\n");
                        Byte[] buffer_rmv_4 = Encoding.Default.GetBytes("NOTFRINOREYou are not friends with " + friend_username + " therefore you cannot remove them from your friends list!\n");
                        thisClient.Send(buffer_rmv_4);
                        isDuplicate = true;
                    }

                    foreach (Tuple<string, string> fship in friendsList)
                    {
                        //IF FRIEND; REMOVE
                        if ((fship.Item1 == friend_username && fship.Item2 == own_username) || (fship.Item1 == own_username && fship.Item2 == friend_username))
                        {
                            if (fship.Item1 == friend_username && fship.Item2 == own_username)
                            {
                                friendsList.Remove(fship);
                                serverLogs.AppendText(own_username + " removed " + friend_username + " from their friends list.\n");
                                break;
                            }
                            else if (fship.Item1 == own_username && fship.Item2 == friend_username)
                            {
                                friendsList.Remove(fship);
                                serverLogs.AppendText(own_username + " removed " + friend_username + " from their friends list.\n");
                                break;
                            }
                        }
                        else
                        //YOU ARE NOT FRIEND, THEREFORE CAN'T REMOVE
                        {
                            Byte[] buffer_rmv_4 = Encoding.Default.GetBytes("NOTFRINOREYou are not friends with " + friend_username
                                                                    + " therefore you cannot remove them from your friends list!\n");
                            thisClient.Send(buffer_rmv_4);
                            isDuplicate = true;
                        }
                    }


                    if (isDuplicate == false)
                    {
                        if (!clientusernames.Contains(friend_username))
                        {
                            //List<String> send = new List<string>();
                            //send.Add("A-" + own_username + "-" + friend_username);
                            string send = "R-" + own_username + "-" + friend_username + "\n";

                            Console.Write("R-" + own_username + "-" + friend_username);
                            File.AppendAllText("../../notification.txt", send);
                            Byte[] buffer_rmv_3 = Encoding.Default.GetBytes("OWN_NOTIFRYou have removed " + friend_username + " from your friends list!");
                            thisClient.Send(buffer_rmv_3);

                        }
                        else
                        {
                            Byte[] buffer_rmv = Encoding.Default.GetBytes("RE_NOTIFIC" + own_username + " removed you from their friends list!");
                            clientSocketsDict[friend_username].Send(buffer_rmv);

                            Byte[] buffer_rmv_2 = Encoding.Default.GetBytes("OWN_NOTIFRYou have been removed from " + friend_username + "'s friends list!");
                            thisClient.Send(buffer_rmv_2);

                            Console.Write("\n\n\n HERE 5 \n\n\n");
                        }
                    }
                }
            }
        }

        private void seeFriendsPosts(string username, Socket thisClient)
        {
            bool notEmptyFriendsPost = false;
            //read all posts from file
            string allposts = File.ReadAllText(@"../../posts.log");
            string pattern = @"\d\d\d\d[-]\d\d[-]\d\d[T]\d\d[:]\d\d[:]\d\d";

            Regex regex = new Regex(pattern);
            string[] splitted = regex.Split(allposts);
            MatchCollection matches = Regex.Matches(allposts, pattern);

            for (int i = 1; i < splitted.Length; i++)
            {
                int beforeid = splitted[i].IndexOf("/", 2);
                int afterid = splitted[i].IndexOf("/", beforeid + 1);

                string Name = splitted[i].Substring(2, beforeid - 2);
                string pID = splitted[i].Substring(beforeid + 1, afterid - beforeid - 1);
                string post = splitted[i].Substring(afterid + 1, splitted[i].Length - 4 - afterid);
                foreach (Tuple<string, string> friendship in friendsList)
                {
                    if ((friendship.Item1 == username && Name == friendship.Item2) || (friendship.Item2 == username && Name == friendship.Item1))
                    {
                        try
                        {
                            Byte[] buffer1 = Encoding.Default.GetBytes("FRIENDPOSTUsername: " + Name);
                            try
                            {
                                thisClient.Send(buffer1);
                                Byte[] response = new Byte[64];
                                thisClient.Receive(response);
                                string received = Encoding.Default.GetString(response);
                                Byte[] buffer2 = Encoding.Default.GetBytes("FRIENDPOSTPostID: " + pID);
                                try
                                {
                                    thisClient.Send(buffer2);
                                    Byte[] response2 = new Byte[64];
                                    thisClient.Receive(response);
                                    string received2 = Encoding.Default.GetString(response);
                                    Byte[] buffer3 = Encoding.Default.GetBytes("FRIENDPOSTPost: " + post);
                                    try
                                    {
                                        thisClient.Send(buffer3);
                                        Byte[] response3 = new Byte[64];
                                        thisClient.Receive(response);
                                        string received3 = Encoding.Default.GetString(response);
                                        Byte[] buffer4 = Encoding.Default.GetBytes("FRIENDPOSTTime: " + matches[i - 1] + "\n");
                                        try
                                        {
                                            thisClient.Send(buffer4);
                                            Byte[] response4 = new Byte[64];
                                            thisClient.Receive(response);
                                            string received4 = Encoding.Default.GetString(response);
                                            notEmptyFriendsPost = true;
                                        }
                                        catch
                                        {
                                            serverLogs.AppendText("There was a problem sending the time.\n");
                                        }
                                    }
                                    catch
                                    {
                                        serverLogs.AppendText("There was a problem sending the post.\n");
                                    }
                                }
                                catch
                                {
                                    serverLogs.AppendText("There was a problem sending the post ID.\n");
                                }

                            }
                            catch
                            {
                                serverLogs.AppendText("There was a problem sending the username.\n");
                            }

                        }
                        catch
                        {
                            serverLogs.AppendText("There was a problem with the GetBytes function.\n");
                        }
                    }
                }
            }
            if (notEmptyFriendsPost == false)
            {
                Byte[] buffer1 = Encoding.Default.GetBytes("FRIENDPOSTThere are no posts from friends.");
                thisClient.Send(buffer1);
                serverLogs.AppendText(username + "'s friends haven't posted anything.\n");
                serverLogs.ScrollToCaret();
            }
            else
            {
                serverLogs.AppendText("Showed all posts of the friends of " + username + ".\n");
                serverLogs.ScrollToCaret();
            }
        }

        private void seeOwnPosts(string username, Socket thisClient)
        {
            bool notEmpty = false;
            //read all posts from file
            string allposts = File.ReadAllText(@"../../posts.log");
            string pattern = @"\d\d\d\d[-]\d\d[-]\d\d[T]\d\d[:]\d\d[:]\d\d";

            Regex regex = new Regex(pattern);
            string[] splitted = regex.Split(allposts);
            MatchCollection matches = Regex.Matches(allposts, pattern);
            for (int i = 1; i < splitted.Length; i++)
            {
                int beforeid = splitted[i].IndexOf("/", 2);
                int afterid = splitted[i].IndexOf("/", beforeid + 1);

                string Name = splitted[i].Substring(2, beforeid - 2);
                string pID = splitted[i].Substring(beforeid + 1, afterid - beforeid - 1);
                string post = splitted[i].Substring(afterid + 1, splitted[i].Length - 4 - afterid);
            
                if (Name == username)
                {
                    try
                    {
                        Byte[] buffer1 = Encoding.Default.GetBytes("YOUR_POSTSUsername: " + Name);
                        try
                        {
                            thisClient.Send(buffer1);
                            Byte[] response = new Byte[64];
                            thisClient.Receive(response);
                            string received = Encoding.Default.GetString(response);
                            Byte[] buffer2 = Encoding.Default.GetBytes("YOUR_POSTSPostID: " + pID);
                            try
                            {
                                thisClient.Send(buffer2);
                                Byte[] response2 = new Byte[64];
                                thisClient.Receive(response);
                                string received2 = Encoding.Default.GetString(response);
                                Byte[] buffer3 = Encoding.Default.GetBytes("YOUR_POSTSPost: " + post);
                                try
                                {
                                    thisClient.Send(buffer3);
                                    Byte[] response3 = new Byte[64];
                                    thisClient.Receive(response);
                                    string received3 = Encoding.Default.GetString(response);
                                    Byte[] buffer4 = Encoding.Default.GetBytes("YOUR_POSTSTime: " + matches[i - 1] + "\n");
                                    try
                                    {
                                        thisClient.Send(buffer4);
                                        Byte[] response4 = new Byte[64];
                                        thisClient.Receive(response);
                                        string received4 = Encoding.Default.GetString(response);
                                        notEmpty = true;
                                    }
                                    catch
                                    {
                                        serverLogs.AppendText("There was a problem sending the time.\n");
                                    }
                                }
                                catch
                                {
                                    serverLogs.AppendText("There was a problem sending the post.\n");
                                }
                            }
                            catch
                            {
                                serverLogs.AppendText("There was a problem sending the post ID.\n");
                            }

                        }
                        catch
                        {
                            serverLogs.AppendText("There was a problem sending the username.\n");
                        }

                    }
                    catch
                    {
                        serverLogs.AppendText("There was a problem with the GetBytes function.\n");
                    }
                }
            }
            if (notEmpty == false)
            {
                Byte[] buffer1 = Encoding.Default.GetBytes("YOUR_POSTSYou haven't posted anything yet.");
                thisClient.Send(buffer1);
                serverLogs.AppendText(username +" haven't posted anything yet.\n");
                serverLogs.ScrollToCaret();
            }
            else
            {
                serverLogs.AppendText("Showed all posts from " + username + ".\n");
                serverLogs.ScrollToCaret();
            }

        }

        private void seeAllFriends(string username, Socket thisClient)
        {
            String msg ="";
            if (friendsList.Count == 0)
            {
                msg = "You have no friends :(\n";
            }
            else
            {
                msg += "Showing friends for " + username + ":\n";
                bool noFriends = true;
                foreach (Tuple<string, string> friendship in friendsList)
                {
                    if (friendship.Item1 == username)
                    {
                        //String friend = friendship.Item2 + "\n"
                        msg += friendship.Item2 + "\n";
                        noFriends = false;
                    }
                    if (friendship.Item2 == username)
                    {
                        msg += friendship.Item1 + "\n";
                        noFriends = false;
                    }
                }
                if (noFriends)
                {
                    msg = "You have no friends :(\n";
                }
            }
            Byte[] buffer = Encoding.Default.GetBytes("ALLFRIENDS"+msg);
            thisClient.Send(buffer);
        }

        private void sendOfflineNotification(string username, Socket thisClient)
        {
            string notification = "";
            string new_file ="";
            List<String> lines = File.ReadAllLines(@"../../notification.txt").ToList(); // check the txt line by line.
            foreach (var line in lines)
            {
                var type_sender_receiver = line.Split('-');
                if (type_sender_receiver[2] == username)
                {
                    // A-fatih-ali
                    if (type_sender_receiver[0] == "A")
                    {
                        notification += type_sender_receiver[1] + " has added you as a friend!\n";
                    }
                    else if (type_sender_receiver[0] == "R")
                    {
                        notification += type_sender_receiver[1] + " removed you from their friends list!\n";
                    }
                    else
                    {
                        new_file += line+'\n'; 
                    }
                }
                else
                {
                    new_file += line+'\n';
                }
            }
            Console.Write(notification);
            Byte[] buffer = Encoding.Default.GetBytes("ALLNOTIFIC" + notification);
            thisClient.Send(buffer);
            File.WriteAllText(@"../../notification.txt", new_file);
            if(new FileInfo(@"../../friendship.txt").Length != 0)
            {
                List<String> friends = File.ReadAllLines(@"../../friendship.txt").ToList();
                foreach(string friendship in friends)
                {
                    var f = Tuple.Create(friendship.Split('-')[0], friendship.Split('-')[1]);
                    friendsList.Add(f);
                }
                File.WriteAllText(@"../../friendship.txt", string.Empty);
            }
        }

        private void addFriend(string friend_username , string own_username, Socket thisClient)
        {
            //If the username don't exist in the user_db, give an error
            List<string> lines = File.ReadAllLines("../../posts.log").ToList();
            var users = File.ReadLines(@"../../user-db.txt").ToList();
            
            if (!users.Contains(friend_username)) // if in database but already connected.
            {
                serverLogs.AppendText("This user does not exist!\n");
                Byte[] buffer = Encoding.Default.GetBytes("DONOTEXISTThis user does not exist!");
                thisClient.Send(buffer);
            }

            else
            {
                bool isDuplicate = false; 
                if (friend_username == own_username) //sending a friend req. to yourself
                {
                    serverLogs.AppendText("You cannot send a request to yourself!\n");
                    Byte[] buffer = Encoding.Default.GetBytes("CANTITSELFYou cannot send a request to yourself!");
                    thisClient.Send(buffer);
                }
                
                else
                {
                    if (friendsList.Count != 0) //sending a friend req. to a friend.
                    {

                        foreach (Tuple<string, string> fship in friendsList)
                        {
                            if (fship.Item1 == friend_username && fship.Item2 == own_username
                                || fship.Item1 == own_username && fship.Item2 == friend_username)
                            {
                                isDuplicate = true;
                                Byte[] buffer4 = Encoding.Default.GetBytes("DUPLICATE_You are already friends with " + friend_username + "!\n");
                                thisClient.Send(buffer4);
                                break;
                            }
                        }
                    }
                    if (isDuplicate == false)
                    {
                        Console.Write(own_username + " added " + friend_username + " as a friend.\n");
                        serverLogs.AppendText(own_username + " added " + friend_username + " as a friend.\n");
                        var friendship = Tuple.Create(own_username, friend_username);
                        friendsList.Add(friendship);
                        if (!clientusernames.Contains(friend_username))
                        {
                            //List<String> send = new List<string>();
                            //send.Add("A-" + own_username + "-" + friend_username);
                            string send = "A-" + own_username + "-" + friend_username+ "\n";
                            
                            Console.Write("A-" + own_username + "-" + friend_username);
                            File.AppendAllText("../../notification.txt", send);
                            Byte[] buffer3 = Encoding.Default.GetBytes("OWN_NOTIFIYou have added " + friend_username + " as a friend!");
                            thisClient.Send(buffer3);

                        }
                        else
                        {
                            Byte[] buffer = Encoding.Default.GetBytes("ADDNOTIFIC" + own_username + " added you as a friend!");
                            clientSocketsDict[friend_username].Send(buffer);

                            Byte[] buffer2 = Encoding.Default.GetBytes("OWN_NOTIFIYou have added " + friend_username + " as a friend!");
                            thisClient.Send(buffer2);
                        }
                    }
                }
            }
        }

        private void deletePost(string post_id_to_delete, string username, Socket thisClient)
        {
            Console.Write("post id to delete: " + post_id_to_delete);
            Console.Write("user to delete: " + username);

            List<string> lines = File.ReadAllLines("../../posts.log").ToList();
            List<string> newLines = new List<string>();
            bool flag = false;
            try { 
            foreach (String line in lines)
            {
                Console.Write("\n" +line+ "\n");
                int firstSlash = line.IndexOf("/", 2);
                int beforeid = line.IndexOf("/", firstSlash+1);
                int afterid = line.IndexOf("/", beforeid + 1);
                string Name = line.Substring(firstSlash+1, beforeid - firstSlash - 1);
                Console.Write("\nname: " + Name + "\n");
                string pID = line.Substring(beforeid + 1, afterid - beforeid - 1);
                Console.Write("\npID: " + pID + "\n");

                if (pID == post_id_to_delete)
                {
                    if (Name == username)
                    {
                            flag = true;
                            // deleting the line, do something
                        Byte[] buffer = Encoding.Default.GetBytes("DELET_POSTPost deleted.");
                        thisClient.Send(buffer);
                        serverLogs.AppendText("Post with id " + post_id_to_delete + " deleted.\n");
                         continue;
                    }
                    else
                    {
                            flag = true;
                        // the post does not belong to this user, do something
                        Byte[] buffer = Encoding.Default.GetBytes("DELET_POSTPost couldn't be deleted, it does not belong to this user.");
                        thisClient.Send(buffer);
                        serverLogs.AppendText("Post with id" + post_id_to_delete + " couldn't be deleted. It doesn't belong to " + username + "\n");

                        }

                    }
                
                 
                newLines.Add(line);
            }
                if (!flag)
                {
                    Byte[] buffer = Encoding.Default.GetBytes("DELET_POSTPost not found.");
                    thisClient.Send(buffer);
                    serverLogs.AppendText("Post with id" + post_id_to_delete + "not found.\n");

                }
                File.WriteAllLines("../../posts.log", newLines);
            }
            catch
            {
                serverLogs.AppendText("There was a problem deleting the post.\n");
            }
        }

        private void postToLog(string username, object postID, string post)
        {
            DateTime currentDateTime = DateTime.Now;
            string DT = currentDateTime.ToString("s"); // 2021-11-20T16:54:52
            using (StreamWriter file = new StreamWriter("../../posts.log", append: true))//append all posts to a file.
            {
                file.WriteLine(DT + " /" + username + "/" + postID.ToString() + "/" + post + "/");
            }
            serverLogs.AppendText(username + " has sent a post:\n" + post + "\n");
        }

        private void allposts(Socket thisClient, string username)
        {
            string allposts = File.ReadAllText(@"../../posts.log");
            string pattern = @"\d\d\d\d[-]\d\d[-]\d\d[T]\d\d[:]\d\d[:]\d\d";

            Regex regex = new Regex(pattern);
            string[] splitted = regex.Split(allposts);
            MatchCollection matches = Regex.Matches(allposts, pattern);
            for (int i = 1; i < splitted.Length; i++)
            {
                int beforeid = splitted[i].IndexOf("/", 2);
                int afterid = splitted[i].IndexOf("/", beforeid + 1);
                string Name = splitted[i].Substring(2, beforeid - 2);
                string pID = splitted[i].Substring(beforeid + 1, afterid - beforeid - 1);
                string post = splitted[i].Substring(afterid + 1, splitted[i].Length - 4 - afterid);
                if (username != Name)
                {
                    try
                    {
                        Byte[] buffer1 = Encoding.Default.GetBytes("SHOW_POSTSUsername: " + Name);
                        try
                        {
                            thisClient.Send(buffer1);
                            Byte[] response = new Byte[64];
                            thisClient.Receive(response);
                            string received = Encoding.Default.GetString(response);
                            Byte[] buffer2 = Encoding.Default.GetBytes("SHOW_POSTSPostID: " + pID);
                            try
                            {
                                thisClient.Send(buffer2);
                                Byte[] response2 = new Byte[64];
                                thisClient.Receive(response);
                                string received2 = Encoding.Default.GetString(response);
                                Byte[] buffer3 = Encoding.Default.GetBytes("SHOW_POSTSPost: " + post);
                                try
                                {
                                    thisClient.Send(buffer3);
                                    Byte[] response3 = new Byte[64];
                                    thisClient.Receive(response);
                                    string received3 = Encoding.Default.GetString(response);
                                    Byte[] buffer4 = Encoding.Default.GetBytes("SHOW_POSTSTime: " + matches[i - 1] + "\n");
                                    try
                                    {
                                        thisClient.Send(buffer4);
                                        Byte[] response4 = new Byte[64];
                                        thisClient.Receive(response);
                                        string received4 = Encoding.Default.GetString(response);
                                    }
                                    catch
                                    {
                                        serverLogs.AppendText("There was a problem sending the time.\n");
                                    }
                                }
                                catch
                                {
                                    serverLogs.AppendText("There was a problem sending the post.\n");
                                }
                            }
                            catch
                            {
                                serverLogs.AppendText("There was a problem sending the post ID.\n");
                            }

                        }
                        catch
                        {
                            serverLogs.AppendText("There was a problem sending the username.\n");
                        }

                    }
                    catch
                    {
                        serverLogs.AppendText("There was a problem with the GetBytes function.\n");
                    }
                }
            }
            serverLogs.AppendText("Showed all posts for " + username + ".\n");
            serverLogs.ScrollToCaret();

        }
        private static int CountPost()
        {
            if (!File.Exists(@"../../posts.log"))//if not generated before.
            {
                File.Create(@"../../posts.log").Dispose();
            }

            string allPosts = File.ReadAllText(@"../../posts.log");

            if (allPosts == "")
            {
                return 0;
            }
            //maybe also line by line can be tried.
            string pattern = @"\d\d\d\d[-]\d\d[-]\d\d[T]\d\d[:]\d\d[:]\d\d";

            Regex regex = new Regex(pattern);
            string[] splitted = regex.Split(allPosts);

            int beforeID = splitted[splitted.Length - 1].IndexOf("/", 2);
            int afterID = splitted[splitted.Length - 1].IndexOf("/", beforeID + 1);

            string pID = splitted[splitted.Length - 1].Substring(beforeID + 1, afterID - beforeID - 1);

            return Int32.Parse(pID);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string temp_friend = "";

            if (friendsList.Count != 0)
            {
                foreach (Tuple<string, string> friendship in friendsList)
                {
                    Console.WriteLine("appending " + friendship.Item1 + "and" + friendship.Item2 + "\n");
                    temp_friend += friendship.Item1 + "-" + friendship.Item2 + '\n';
                }
                File.AppendAllText(@"../../friendship.txt", temp_friend);
            }
            
            serverLogs.ScrollToCaret();

            listening = false;
            terminating = true;
            Environment.Exit(0);
        }

      
    }
}
