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

namespace client
{
    public partial class Form1 : Form
    {
        bool terminating = false;
        bool connected = false;
        Socket clientSocket;

        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string IP = ipTextBox.Text;
            int portNum;
            string username = usernameTextBox.Text;

            if (Int32.TryParse(portTextBox.Text, out portNum))
            {
                if (username != "" && username.Length <= 128)
                {
                    if (IP != "")
                    {
                        try
                        {
                            clientSocket.Connect(IP, portNum);
                            Byte[] send_buffer = new Byte[10000000];
                            Byte[] receive_buffer = new Byte[10000000];

                            send_buffer = Encoding.Default.GetBytes(username);
                            clientSocket.Send(send_buffer);

                            clientSocket.Receive(receive_buffer);
                            string incomingMessage = Encoding.Default.GetString(receive_buffer);
                            incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));
                            if (incomingMessage !="NOT FOUND") {
                                if (incomingMessage != "ALREADY CONNECTED")
                                {
                                    if (incomingMessage == "SUCCESS")
                                    {
                                        connectButton.Enabled = false;
                                        disconnectButton.Enabled = true;
                                        ipTextBox.Enabled = false;
                                        portTextBox.Enabled = false;
                                        sendButton.Enabled = true;
                                        allPostsButton.Enabled = true;
                                        postTextBox.Enabled = true;
                                        usernameTextBox.Enabled = false;

                                        connected = true;
                                        logTextBox.AppendText("Hello " + username + "! You are connected to the server.\n");

                                        logTextBox.ScrollToCaret();
                                        Thread receiveThread = new Thread(Receive);
                                        receiveThread.Start();
                                    }
                                    else
                                    {
                                        logTextBox.AppendText("Could not connect!\n");
                                        logTextBox.ScrollToCaret();
                                        usernameTextBox.Clear();
                                    }
                                }
                                else
                                {
                                    logTextBox.AppendText("You are already connected!\n");
                                    logTextBox.ScrollToCaret();
                                    usernameTextBox.Clear();
                                }
                            }
                            else
                            {
                                logTextBox.AppendText("Please enter a valid username!\n");
                                logTextBox.ScrollToCaret();
                                usernameTextBox.Clear();
                            }

                        }
                        catch
                        {
                            logTextBox.AppendText("Could not connect to the server!\n");
                            logTextBox.ScrollToCaret();
                        }
                    }
                    else
                    {
                        logTextBox.AppendText("Check the IP address!\n");
                        logTextBox.ScrollToCaret();
                    }
                }
                else
                {
                    logTextBox.AppendText("Please enter a valid username!\n");
                    logTextBox.ScrollToCaret();
                    usernameTextBox.Clear();
                }
            }
            else
            {
                logTextBox.AppendText("Check the port number!\n");
                logTextBox.ScrollToCaret();
            }
        }

        private void Receive()
        {
            while (connected)
            {
                try
                {
                    Byte[] buffer = new Byte[10000000];
                    clientSocket.Receive(buffer);

                    string incomingMessage = Encoding.Default.GetString(buffer);
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));

                    if (incomingMessage.Split('/')[0] == "DISCONNECT")
                    {
                        if (!terminating)
                            logTextBox.AppendText("The server has disconnected\n");
                        logTextBox.ScrollToCaret();
                        Disconnect();
                    }
                    if (incomingMessage.Split('/')[0] == "SUCCESS_POST")
                    {
                        string post = incomingMessage.Split('/')[1];
                        logTextBox.AppendText("You have successfuly sent a post!\n");
                        logTextBox.AppendText(usernameTextBox.Text+ ": " + post +  "\n\n");
                        logTextBox.ScrollToCaret();
                        postTextBox.Clear();
                    }
                    if(incomingMessage.Split('/')[0] == "ALL_POSTS")
                    {
                        string all = incomingMessage.Split('/')[1];
                        logTextBox.AppendText(all + "\n");
                        logTextBox.ScrollToCaret();
                    }

                }
                catch
                {
                    Disconnect();
                }
            }
        }
        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Disconnect();
            terminating = true;
            Environment.Exit(0);
        }
        
        private void sendButton_Click(object sender, EventArgs e)
        {
            if (checkEmpty())
            { 
                return;
            }
          
            string post = postTextBox.Text;
            
            string message = "SEND_POST/"+ usernameTextBox.Text + "/" + post;
            if (post != "")
            {
                try
                { 
                    Byte[] buffer = Encoding.Default.GetBytes(message);
                    clientSocket.Send(buffer);
                }
                catch
                {

                }
            }
        }

        private bool checkEmpty()
        {
            bool flag = false;
            
            if (usernameTextBox.Text == "")
            {
                logTextBox.AppendText("Please enter your username!\n");
                logTextBox.ScrollToCaret();
                flag = true;
            }
          
            return flag;
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            Disconnect();
            logTextBox.AppendText("Successfully disconnected\n");
            logTextBox.ScrollToCaret();

        }

        private void Disconnect()
        {
            try
            {
                Byte[] buffer = Encoding.Default.GetBytes("DISCONNECT/" + usernameTextBox.Text);
                clientSocket.Send(buffer);

            }
            catch
            {
                //logTextBox.AppendText("The server has disconnected\n");
            }
            if (!terminating)
            {
                usernameTextBox.Clear();
                usernameTextBox.Enabled = true;
                ipTextBox.Clear();
                ipTextBox.Enabled = true;
                portTextBox.Clear();
                portTextBox.Enabled = true;
                connectButton.Enabled = true;
                disconnectButton.Enabled = false;
                postTextBox.Enabled = false;
                sendButton.Enabled = false;
                allPostsButton.Enabled = false;
                /*
                connectButton.Enabled = true;
                disconnectButton.Enabled = false;
                
                usernameTextBox.Enabled = false;
    
                sendButton.Enabled = false;
                */
            }
            if (connected) clientSocket.Close();
            connected = false;
        }

        private void logTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void allPostsButton_Click(object sender, EventArgs e)
        {
            Byte[] buffer = new Byte[10000000];

            buffer = Encoding.Default.GetBytes("GET_ALL_POSTS/"+usernameTextBox.Text);
            clientSocket.Send(buffer);
        }

        private void addFriendButton_Click(object sender, EventArgs e)
        {
            String friendName = addFriendTextBox.Text;

            Byte[] buffer = new Byte[10000000];

            buffer = Encoding.Default.GetBytes("ADD_FRIEND/" + friendName);
            clientSocket.Send(buffer);
        }

        private void removeFriendButton_Click(object sender, EventArgs e)
        {
            String friendName = removeFriendTextBox.Text;
            Byte[] buffer = new Byte[10000000];

            buffer = Encoding.Default.GetBytes("REMOVE_FRIEND/" + friendName);
            clientSocket.Send(buffer);
        }

        private void seeFriendsButton_Click(object sender, EventArgs e)
        {
            Byte[] buffer = new Byte[10000000];

            buffer = Encoding.Default.GetBytes("GET_FRIENDS/");
            clientSocket.Send(buffer);
        }

        private void friendsPostsButton_Click(object sender, EventArgs e)
        {
            Byte[] buffer = new Byte[10000000];

            buffer = Encoding.Default.GetBytes("GET_FRIENDS_POSTS/");
            clientSocket.Send(buffer);
        }

        private void deletePostButton_Click(object sender, EventArgs e)
        {
            String postID = deletePostTextBox.Text;

            Byte[] buffer = new Byte[10000000];

            buffer = Encoding.Default.GetBytes("DELETE_POST/" + postID);
            clientSocket.Send(buffer);
        }
    }
}
