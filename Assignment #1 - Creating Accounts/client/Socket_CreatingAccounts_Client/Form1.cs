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

namespace Socket_CreatingAccounts_Client
{
    public partial class Form1 : Form
    {
        //Showing the will of the client who disconnected from the server
        bool terminating = false;
        bool connected = false;
        Socket clientSocket;

        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
        }

        private void button2_Connect_Click(object sender, EventArgs e)
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string IP = textBox1_IP.Text;
            int portNum;
            if(Int32.TryParse(textBox2_Port.Text, out portNum))
            {
                try
                {
                    clientSocket.Connect(IP, portNum);
                    button2_Connect.Enabled = false;
                    textBox3_Name.Enabled = true;
                    textBox4_Surname.Enabled = true;
                    textBox5_Username.Enabled = true;
                    textBox6_Password.Enabled = true;
                    button1_CreateAccount.Enabled = true;
                    button3_Disconnect.Enabled = true;

                    connected = true;
                    client_logs.AppendText("Hello! You are connected to the server.\n");

                    Thread receivethread = new Thread(Receive);
                    receivethread.Start();
                }
                catch
                {
                    client_logs.AppendText("Could not connect to the server!\n");
                }
                
            }
            else
            {
                client_logs.AppendText("Check your port number!\n");
            }
        }

        private void Receive()
        {
            while(connected)
            {
                try
                {
                    Byte[] buffer = new Byte[64];
                    clientSocket.Receive(buffer);

                    string incoming_Message = Encoding.Default.GetString(buffer);
                    incoming_Message = incoming_Message.Substring(0, incoming_Message.IndexOf("\0"));

                    client_logs.AppendText(incoming_Message);

                    if(incoming_Message == "There is already an account with this username!\n")
                    {
                        textBox5_Username.Clear();
                    }
                    else
                    {
                        textBox3_Name.Clear();
                        textBox4_Surname.Clear();
                        textBox5_Username.Clear();
                        textBox6_Password.Clear();
                    }


                }
                catch
                {
                    if(!terminating)
                    {
                        client_logs.AppendText("The server has disconnected!!!\n");
                        button2_Connect.Enabled = true;
                        textBox3_Name.Enabled = false;
                        textBox4_Surname.Enabled = false;
                        textBox5_Username.Enabled = false;
                        textBox6_Password.Enabled = false;
                        button1_CreateAccount.Enabled = false;
                        button3_Disconnect.Enabled = false;
                        connected = false;
                    }

                    clientSocket.Close();
                }
            }
        }

        private void button1_CreateAccount_Click(object sender, EventArgs e)
        {
            if (textBox3_Name.Text != "" && textBox4_Surname.Text != "" && textBox5_Username.Text != "" && textBox6_Password.Text != "")
            {

                string message = textBox3_Name.Text + "#" + textBox4_Surname.Text + "#" + textBox5_Username.Text + "#" + textBox6_Password.Text;
                if (message != "" && message.Length <= 100000)
                {
                    Byte[] buffer_AccountInfo = Encoding.Default.GetBytes(message);
                    clientSocket.Send(buffer_AccountInfo);
                }
                
                
            }
            else if(textBox3_Name.Text == "")
            {
                client_logs.AppendText("Please enter your name!\n");
            }
            else if (textBox4_Surname.Text == "")
            {
                client_logs.AppendText("Please enter your surname!\n");
            }
            else if (textBox5_Username.Text == "")
            {
                client_logs.AppendText("Please enter your username!\n");
            }
            else if (textBox6_Password.Text == "")
            {
                client_logs.AppendText("Please enter your password!\n");
            }

        }
                   

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            connected = false;
            terminating = true;
            Environment.Exit(0);
        }

        private void button3_Disconnect_Click(object sender, EventArgs e)
        {
            button3_Disconnect.Enabled = false;
            button2_Connect.Enabled = true;
            textBox3_Name.Enabled = false;
            textBox4_Surname.Enabled = false;
            textBox5_Username.Enabled = false;
            textBox6_Password.Enabled = false;
            button1_CreateAccount.Enabled = false;

            connected = false;
            terminating = true;

            client_logs.AppendText("Successfuly disconnected.\n");

            clientSocket.Close();
        }
    }
}
