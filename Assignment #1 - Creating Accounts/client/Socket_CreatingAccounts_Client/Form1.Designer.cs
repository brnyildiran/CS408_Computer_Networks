namespace Socket_CreatingAccounts_Client
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1_CreateAccount = new System.Windows.Forms.Button();
            this.textBox1_IP = new System.Windows.Forms.TextBox();
            this.textBox2_Port = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3_Name = new System.Windows.Forms.TextBox();
            this.textBox4_Surname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox5_Username = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox6_Password = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button3_Disconnect = new System.Windows.Forms.Button();
            this.button2_Connect = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.client_logs = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // button1_CreateAccount
            // 
            this.button1_CreateAccount.Enabled = false;
            this.button1_CreateAccount.Location = new System.Drawing.Point(90, 350);
            this.button1_CreateAccount.Name = "button1_CreateAccount";
            this.button1_CreateAccount.Size = new System.Drawing.Size(137, 26);
            this.button1_CreateAccount.TabIndex = 0;
            this.button1_CreateAccount.Text = "Create Account";
            this.button1_CreateAccount.UseVisualStyleBackColor = true;
            this.button1_CreateAccount.Click += new System.EventHandler(this.button1_CreateAccount_Click);
            // 
            // textBox1_IP
            // 
            this.textBox1_IP.Location = new System.Drawing.Point(27, 61);
            this.textBox1_IP.Name = "textBox1_IP";
            this.textBox1_IP.Size = new System.Drawing.Size(200, 22);
            this.textBox1_IP.TabIndex = 3;
            // 
            // textBox2_Port
            // 
            this.textBox2_Port.Location = new System.Drawing.Point(280, 61);
            this.textBox2_Port.Name = "textBox2_Port";
            this.textBox2_Port.Size = new System.Drawing.Size(160, 22);
            this.textBox2_Port.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Surname";
            // 
            // textBox3_Name
            // 
            this.textBox3_Name.Enabled = false;
            this.textBox3_Name.Location = new System.Drawing.Point(27, 120);
            this.textBox3_Name.Name = "textBox3_Name";
            this.textBox3_Name.Size = new System.Drawing.Size(200, 22);
            this.textBox3_Name.TabIndex = 8;
            // 
            // textBox4_Surname
            // 
            this.textBox4_Surname.Enabled = false;
            this.textBox4_Surname.Location = new System.Drawing.Point(27, 179);
            this.textBox4_Surname.Name = "textBox4_Surname";
            this.textBox4_Surname.Size = new System.Drawing.Size(200, 22);
            this.textBox4_Surname.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Username";
            // 
            // textBox5_Username
            // 
            this.textBox5_Username.Enabled = false;
            this.textBox5_Username.Location = new System.Drawing.Point(27, 238);
            this.textBox5_Username.Name = "textBox5_Username";
            this.textBox5_Username.Size = new System.Drawing.Size(200, 22);
            this.textBox5_Username.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 277);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Password";
            // 
            // textBox6_Password
            // 
            this.textBox6_Password.Enabled = false;
            this.textBox6_Password.Location = new System.Drawing.Point(27, 297);
            this.textBox6_Password.Name = "textBox6_Password";
            this.textBox6_Password.Size = new System.Drawing.Size(200, 22);
            this.textBox6_Password.TabIndex = 13;
            this.textBox6_Password.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(277, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "Port";
            // 
            // button3_Disconnect
            // 
            this.button3_Disconnect.Enabled = false;
            this.button3_Disconnect.Location = new System.Drawing.Point(419, 430);
            this.button3_Disconnect.Name = "button3_Disconnect";
            this.button3_Disconnect.Size = new System.Drawing.Size(102, 26);
            this.button3_Disconnect.TabIndex = 15;
            this.button3_Disconnect.Text = "Disconnect";
            this.button3_Disconnect.UseVisualStyleBackColor = true;
            this.button3_Disconnect.Click += new System.EventHandler(this.button3_Disconnect_Click);
            // 
            // button2_Connect
            // 
            this.button2_Connect.Location = new System.Drawing.Point(446, 61);
            this.button2_Connect.Name = "button2_Connect";
            this.button2_Connect.Size = new System.Drawing.Size(75, 26);
            this.button2_Connect.TabIndex = 16;
            this.button2_Connect.Text = "Connect";
            this.button2_Connect.UseVisualStyleBackColor = true;
            this.button2_Connect.Click += new System.EventHandler(this.button2_Connect_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // client_logs
            // 
            this.client_logs.Location = new System.Drawing.Point(280, 100);
            this.client_logs.Name = "client_logs";
            this.client_logs.ReadOnly = true;
            this.client_logs.Size = new System.Drawing.Size(240, 325);
            this.client_logs.TabIndex = 2;
            this.client_logs.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 478);
            this.Controls.Add(this.button2_Connect);
            this.Controls.Add(this.button3_Disconnect);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox6_Password);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox5_Username);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox4_Surname);
            this.Controls.Add(this.textBox3_Name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2_Port);
            this.Controls.Add(this.textBox1_IP);
            this.Controls.Add(this.client_logs);
            this.Controls.Add(this.button1_CreateAccount);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1_CreateAccount;
        private System.Windows.Forms.TextBox textBox1_IP;
        private System.Windows.Forms.TextBox textBox2_Port;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3_Name;
        private System.Windows.Forms.TextBox textBox4_Surname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox5_Username;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox6_Password;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button3_Disconnect;
        private System.Windows.Forms.Button button2_Connect;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.RichTextBox client_logs;
    }
}

