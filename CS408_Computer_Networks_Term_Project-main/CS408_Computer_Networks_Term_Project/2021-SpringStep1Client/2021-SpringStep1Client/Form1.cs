using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2021_SpringStep1Client
{
    public partial class Form1 : Form
    {
        bool terminating = false; //this is the will of the client to disconnect from the server. 
        bool connected = false; //Initially the client is not connected.
        bool disconnectPressed = false;
        string clientUsername = "";
        Socket clientSocket; 
        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);// do it in order to not need any delegate to access the GUI object. 
            InitializeComponent();
        }

   
        private void Button_connect_Click(object sender, EventArgs e)
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); // IPv4, stream to exchange messages byte array forms.
            string IP = textBoxIP.Text;
            int Port;

            if(Int32.TryParse(textBoxPort.Text, out Port)) // check if integer or not if not sure use it in that way with TryParse
            {
                string username = textBoxUsername.Text;
                //Possible Problems.
                if(username == "")
                { clientLogs.AppendText("Please enter you username.\n");}
                else if(IP == "")
                { clientLogs.AppendText("Please enter an IP address.\n"); }

                //If no problem related to textboxes in order to connect.
                else
                {
                    try 
                    {
                        clientSocket.Connect(IP, Port);
                        try
                        {
                            clientSocket.Send(Encoding.Default.GetBytes(username));
                            try
                            {
                                Byte[] responsebuffer = new Byte[64];
                                clientSocket.Receive(responsebuffer);
                                string response = Encoding.Default.GetString(responsebuffer);
                                //response = response.Substring(0, response.IndexOf("\0"));
                                response = response.Trim('\0');

                                if (response == "NOT_FOUND")
                                {
                                    clientLogs.AppendText("Please enter a valid username.\n");// not a db user, error. 
                                }
                                else if (response == "Already_Connected")
                                {
                                    clientLogs.AppendText("This user is already connected.\n");
                                }
                                else if (response == "SUCCESS")
                                {
                                    
                                    Button_connect.Enabled = false; // since we are connected we should not able to click to connect again. 
                                    button_SendPost.Enabled = true;
                                    button_Disconnect.Enabled = true;
                                    button_AllPosts.Enabled = true;
                                    textBoxPost.Enabled = true; // should be able to send posts.
                                    disconnectPressed = false;
                                    button_DeletePost.Enabled = true;
                                    button_AddFriend.Enabled = true;
                                    button_RemoveFriend.Enabled = true;

                                    textBoxDeletePost.Enabled = true;
                                    textBoxAddFriend.Enabled = true;
                                    textBoxRemoveFriend.Enabled = true;
                                    button_FriendsPosts.Enabled = true;
                                    button_FriendsList.Enabled = true;
                                    button_OwnPosts.Enabled = true;
                                    connected = true;
                                    clientUsername = username;
                                    clientLogs.AppendText("Hello " + username + "! You are connected to the server.\n");

                                    Thread receiveThread = new Thread(Receive);
                                    receiveThread.Start();
                                }
                            }
                            catch
                            {
                                clientLogs.AppendText("There was a problem receiving response.\n");
                            }
                        }
                        catch
                        {
                            clientLogs.AppendText("Problem occured while username is sent.\n");
                        }
                    }
                    catch
                    {
                        clientLogs.AppendText("Could not connect to the server.\n");
                    }
                    
                }
            }
            else
            {
                clientLogs.AppendText("Check the port\n");
            }
        }

        private void button_SendPost_Click(object sender, EventArgs e)
        {
            string message = "SEND_POSTS" + textBoxPost.Text;
            textBoxPost.Text = "";
            if (message != "" && message.Length <= 64)//correct format of the message. 
            {
                Byte[] buffer = Encoding.Default.GetBytes(message);
                try
                {
                    clientSocket.Send(buffer);

                    clientLogs.AppendText("You have successfully sent a post!\n");
                    clientLogs.AppendText(clientUsername + ": " + message.Substring(10) + " \n");
                }
                catch
                {
                    clientLogs.AppendText("There was a problem sending the post to the server.\n");
                }
            }

        }

        private void button_AllPosts_Click(object sender, EventArgs e)
        {
            string message = "SHOW_POSTS";
            Byte[] buffer = Encoding.Default.GetBytes(message);
            try
            {
                clientLogs.AppendText("\nShowing all posts from clients: \n");
                clientSocket.Send(buffer);
            }
            catch
            {
                clientLogs.AppendText("There was a problem in the request of reaching posts page to server.\n");
            }

        }
        private void Receive()
        {
            while (connected)
            { 
                try
                {   Byte[] buffer = new Byte[10000];
                    clientSocket.Receive(buffer);

                    Byte[] response = Encoding.Default.GetBytes("receivedinfo");
                    clientSocket.Send(response);

                    string incomingMessage = Encoding.Default.GetString(buffer);
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));
                    //incomingMessage = incomingMessage.Trim('\0');

                   string label = incomingMessage.Substring(0, 10);

                    if (label == "SHOW_POSTS")
                    {
                       clientLogs.AppendText(incomingMessage.Substring(10) + "\n");
                    }
                    else if (label == "DELET_POST")
                    {
                        clientLogs.AppendText(incomingMessage.Substring(10) + "\n");
                    }
                    else if(label == "DONOTEXIST")
                    {
                        clientLogs.AppendText(incomingMessage.Substring(10) + "\n");
                    }
                    else if(label == "CANTITSELF")
                    {
                        clientLogs.AppendText(incomingMessage.Substring(10) + "\n");
                    }
                    else if(label == "ALLFRIENDS")
                    {
                        clientLogs.AppendText(incomingMessage.Substring(10));
                    }
                    else if (label == "ADDNOTIFIC")
                    {
                        clientLogs.AppendText(incomingMessage.Substring(10) + "\n");
                    }
                    else if(label == "OWN_NOTIFI")
                    {
                        clientLogs.AppendText(incomingMessage.Substring(10) + "\n");
                    }
                    else if(label == "ALLNOTIFIC")
                    {
                        clientLogs.AppendText(incomingMessage.Substring(10) + "\n");
                    }
                    else if(label == "DUPLICATE_")
                    {
                        clientLogs.AppendText(incomingMessage.Substring(10) + "\n");
                    }
                    else if (label == "FRIENDPOST")
                    {
                        clientLogs.AppendText(incomingMessage.Substring(10) + "\n");
                    }
                    else if (label == "YOUR_POSTS")
                    {
                        clientLogs.AppendText(incomingMessage.Substring(10) + "\n");
                    }
                    else if (label == "CANT_RSELF")
                    {
                        clientLogs.AppendText(incomingMessage.Substring(10) + "\n");
                    }
                    else if (label == "RE_NOTIFIC")
                    {
                        clientLogs.AppendText(incomingMessage.Substring(10) + "\n");
                    }
                    else if (label == "OWN_NOTIFR")
                    {
                        clientLogs.AppendText(incomingMessage.Substring(10) + "\n");
                    }
                    else if(label == "NOTFRINORE")
                    {
                        clientLogs.AppendText(incomingMessage.Substring(10) + "\n");
                    }
                    clientLogs.ScrollToCaret();

                }
                catch
                {
                    if (!terminating && !disconnectPressed)//not terminating the action and not disconnected.
                    {
                        clientLogs.AppendText("The server has disconnected.\n");//Probably the server has stopped, client cannot connect then to that server. 
                        Button_connect.Enabled = true;
                        textBoxPost.Enabled = false;
                        button_SendPost.Enabled = false;
                        button_Disconnect.Enabled = false;
                        button_AllPosts.Enabled = false;
                        button_DeletePost.Enabled = false;
                        textBoxDeletePost.Enabled = false;
                        textBoxAddFriend.Enabled = false;
                        textBoxRemoveFriend.Enabled = false;
                        button_RemoveFriend.Enabled = false;
                        button_FriendsList.Enabled = false;
                        button_FriendsPosts.Enabled = false;
                        button_OwnPosts.Enabled = false;
                        button_AddFriend.Enabled = false;
                    }

                    clientSocket.Close();
                    connected = false;
                }

            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            connected = false;
            terminating = true;
            Environment.Exit(0);
            //throw new NotImplementedException();
        }

        private void button_Disconnect_Click(object sender, EventArgs e)
        {
            string message = "DISCONNECT";
            Byte[] buffer = Encoding.Default.GetBytes(message);
            try
            {
                clientSocket.Send(buffer);

                disconnectPressed = true;

                Button_connect.Enabled = true;
                textBoxPost.Enabled = false;
                button_SendPost.Enabled = false;
                button_Disconnect.Enabled = false;
                button_AllPosts.Enabled = false;
                button_DeletePost.Enabled = false;
                textBoxDeletePost.Enabled = false;
                textBoxAddFriend.Enabled = false;
                textBoxRemoveFriend.Enabled = false;
                button_RemoveFriend.Enabled = false;
                button_FriendsList.Enabled = false;
                button_FriendsPosts.Enabled = false;
                button_OwnPosts.Enabled = false;
                button_AddFriend.Enabled = false;
                clientSocket.Close();
                connected = false;

                clientLogs.AppendText("Successfuly disconnected.\n");
            }
            catch
            {
                clientLogs.AppendText("There was a problem sending disconnect request to server.\n");
            }
        }

        private void button_DeletePost_Click(object sender, EventArgs e)
        {
            String postID = textBoxDeletePost.Text;
            string message = "DELET_POST" + postID;
            Byte[] buffer = Encoding.Default.GetBytes(message);
            try
            {
                //clientLogs.AppendText("\nPost with ID " + postID + " deleted. \n");
                clientSocket.Send(buffer);
                //Byte[] responsebuffer = new Byte[64];

                //clientSocket.Receive(responsebuffer);
                //string received = Encoding.Default.GetString(responsebuffer);


            }
            catch
            {
                clientLogs.AppendText("There was a problem in the request of deleting post to server.\n");
            }
        }

        private void button_AddFriend_Click(object sender, EventArgs e)
        {
            String friend_username = textBoxAddFriend.Text;
            string message = "ADD_FRIEND" + friend_username;
            Byte[] buffer = Encoding.Default.GetBytes(message);

            try
            {
                clientSocket.Send(buffer);
            }
            catch
            {
                clientLogs.AppendText("There was a problem in the request of adding friend to server.\n");
            }

        }

        private void button_FriendsList_Click(object sender, EventArgs e)
        {
            string message = "SEEFRIENDS";
            Byte[] buffer = Encoding.Default.GetBytes(message);

            try
            {
                clientSocket.Send(buffer);
            }
            catch
            {
                clientLogs.AppendText("There was a problem in the request of seeing friends to server.\n");
            }

        }

        private void button_OwnPosts_Click(object sender, EventArgs e)
        {
            string message = "YOUR_POSTS";
            Byte[] buffer = Encoding.Default.GetBytes(message);

            try
            {
                clientLogs.AppendText("\nShowing all posts from you: \n");
                clientSocket.Send(buffer);
            }
            catch
            {
                clientLogs.AppendText("There was a problem showing posts from you.\n");
            }
        }

        private void button_FriendsPosts_Click(object sender, EventArgs e)
        {
            string message = "FRIENDPOST";
            Byte[] buffer = Encoding.Default.GetBytes(message);

            try
            {
                clientLogs.AppendText("\nShowing all posts from your friends: \n");
                clientSocket.Send(buffer);
            }
            catch
            {
                clientLogs.AppendText("There was a problem showing your posts from your friends.\n");
            }
        }

        private void button_RemoveFriend_Click(object sender, EventArgs e)
        {
            String friend_username = textBoxRemoveFriend.Text;
            string message = "REMOVE_FRI" + friend_username;
            Byte[] buffer = Encoding.Default.GetBytes(message);

            try
            {
                clientSocket.Send(buffer);
            }
            catch
            {
                clientLogs.AppendText("There was a problem in the request of removing friend to server.\n");
            }
        }
    }
}
