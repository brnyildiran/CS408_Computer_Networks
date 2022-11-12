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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace server
{
    public partial class Form1 : Form
    {

        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<Socket> clientSockets = new List<Socket>();
        List<string> clientUsernames = new List<string>(); //List for checking the username uniqueness

        bool terminating = false;
        bool listening = false;

        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }

        private void button_listen_Click(object sender, EventArgs e)
        {
            int serverPort;

            if(Int32.TryParse(textBox_port.Text, out serverPort))
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, serverPort);
                serverSocket.Bind(endPoint);
                serverSocket.Listen(3);

                listening = true;
                button_listen.Enabled = false;

                Thread acceptThread = new Thread(Accept);
                acceptThread.Start();

                logs.AppendText("Started listening on port: " + serverPort + "\n");

            }
            else
            {
                logs.AppendText("Please check port number! \n");
            }
        }

        private void Accept()
        {
            while(listening)
            {
                try
                {
                    Socket newClient = serverSocket.Accept();
                    clientSockets.Add(newClient);
                    logs.AppendText("A client is connected!\n");

                    Thread receiveThread = new Thread(() => Receive(newClient)); // updated
                    receiveThread.Start();
                }
                catch
                {
                    if (terminating)
                    {
                        listening = false;
                    }
                    else
                    {
                        logs.AppendText("The socket stopped working.\n");
                    }

                }
            }
        }

        private void Receive(Socket thisClient) // updated
        {
            bool connected = true;

            while(connected && !terminating)
            {
                try
                {
                    Byte[] buffer_AccountInfo = new Byte[64];
                    thisClient.Receive(buffer_AccountInfo);

                    string incomingMessage = Encoding.Default.GetString(buffer_AccountInfo);
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));
                                        
                    string[] words = incomingMessage.Split('#');

                    
                   

                    if (clientUsernames.Contains(words[2]))
                    {
                        logs.AppendText(words[2] + " cannot create an account since this username is used!\n");
                        
                        //Inform the client, this username is taken
                        string usernameTakenMessage = "There is already an account with this username!\n";
                        Byte[] buffer_UsernameTaken = new Byte[usernameTakenMessage.Length];
                        buffer_UsernameTaken = Encoding.Default.GetBytes(usernameTakenMessage);
                        thisClient.Send(buffer_UsernameTaken);
                    }

                    else
                    {
                        clientSockets.Add(thisClient);  //Add client to the client list
                        clientUsernames.Add(words[2]);

                        logs.AppendText(words[2] + " has created an account.\n");

                        //Inform the client, account created
                        string usernameAvailable = "You have created an account!\n";
                        Byte[] buffer_UsernameAvailable = new Byte[usernameAvailable.Length];
                        buffer_UsernameAvailable = Encoding.Default.GetBytes(usernameAvailable);
                        thisClient.Send(buffer_UsernameAvailable);

                        using (StreamWriter file = new StreamWriter("database.txt", append: true))
                        {
                            file.WriteLine(words[0] + " " + words[1] + " - " + words[2] + " - " + words[3]);
                        }
                    }
                                                          
                }
                catch
                {
                    if(!terminating)
                    {
                        logs.AppendText("A client has disconnected.\n");
                    }
                    thisClient.Close();
                    clientSockets.Remove(thisClient);
                    connected = false;
                }
            }
        }

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            listening = false;
            terminating = true;
            Environment.Exit(0);
        }
    }
}


/* Helpful and useful for assignments or projects:

             var lines = File.ReadLines(@"../../database.txt");



            using (StreamWriter file = new StreamWriter("../../database.txt", append: true))
            {
               file.WriteLine(x + "-" + y );
            }
*/
