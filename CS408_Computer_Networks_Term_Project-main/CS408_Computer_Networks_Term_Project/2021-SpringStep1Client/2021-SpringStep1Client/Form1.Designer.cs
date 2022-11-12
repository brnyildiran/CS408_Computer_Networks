namespace _2021_SpringStep1Client
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.button_Disconnect = new System.Windows.Forms.Button();
            this.Button_connect = new System.Windows.Forms.Button();
            this.clientLogs = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPost = new System.Windows.Forms.TextBox();
            this.button_SendPost = new System.Windows.Forms.Button();
            this.button_AllPosts = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_OwnPosts = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxRemoveFriend = new System.Windows.Forms.TextBox();
            this.textBoxAddFriend = new System.Windows.Forms.TextBox();
            this.textBoxDeletePost = new System.Windows.Forms.TextBox();
            this.button_DeletePost = new System.Windows.Forms.Button();
            this.button_RemoveFriend = new System.Windows.Forms.Button();
            this.button_AddFriend = new System.Windows.Forms.Button();
            this.button_FriendsList = new System.Windows.Forms.Button();
            this.button_FriendsPosts = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 123);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 80);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Port:";
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(150, 39);
            this.textBoxIP.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(308, 31);
            this.textBoxIP.TabIndex = 3;
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(150, 80);
            this.textBoxPort.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(308, 31);
            this.textBoxPort.TabIndex = 4;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(150, 123);
            this.textBoxUsername.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(308, 31);
            this.textBoxUsername.TabIndex = 5;
            // 
            // button_Disconnect
            // 
            this.button_Disconnect.Enabled = false;
            this.button_Disconnect.Location = new System.Drawing.Point(538, 109);
            this.button_Disconnect.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_Disconnect.Name = "button_Disconnect";
            this.button_Disconnect.Size = new System.Drawing.Size(152, 62);
            this.button_Disconnect.TabIndex = 7;
            this.button_Disconnect.Text = "Disconnect";
            this.button_Disconnect.UseVisualStyleBackColor = true;
            this.button_Disconnect.Click += new System.EventHandler(this.button_Disconnect_Click);
            // 
            // Button_connect
            // 
            this.Button_connect.Location = new System.Drawing.Point(538, 39);
            this.Button_connect.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Button_connect.Name = "Button_connect";
            this.Button_connect.Size = new System.Drawing.Size(152, 62);
            this.Button_connect.TabIndex = 8;
            this.Button_connect.Text = "Connect";
            this.Button_connect.UseVisualStyleBackColor = true;
            this.Button_connect.Click += new System.EventHandler(this.Button_connect_Click);
            // 
            // clientLogs
            // 
            this.clientLogs.Location = new System.Drawing.Point(752, 39);
            this.clientLogs.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.clientLogs.Name = "clientLogs";
            this.clientLogs.ReadOnly = true;
            this.clientLogs.Size = new System.Drawing.Size(520, 701);
            this.clientLogs.TabIndex = 9;
            this.clientLogs.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 44);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Post:";
            // 
            // textBoxPost
            // 
            this.textBoxPost.Enabled = false;
            this.textBoxPost.Location = new System.Drawing.Point(132, 39);
            this.textBoxPost.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxPost.Name = "textBoxPost";
            this.textBoxPost.Size = new System.Drawing.Size(308, 31);
            this.textBoxPost.TabIndex = 11;
            // 
            // button_SendPost
            // 
            this.button_SendPost.Enabled = false;
            this.button_SendPost.Location = new System.Drawing.Point(522, 17);
            this.button_SendPost.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_SendPost.Name = "button_SendPost";
            this.button_SendPost.Size = new System.Drawing.Size(150, 56);
            this.button_SendPost.TabIndex = 12;
            this.button_SendPost.Text = "Send";
            this.button_SendPost.UseVisualStyleBackColor = true;
            this.button_SendPost.Click += new System.EventHandler(this.button_SendPost_Click);
            // 
            // button_AllPosts
            // 
            this.button_AllPosts.Enabled = false;
            this.button_AllPosts.Location = new System.Drawing.Point(15, 422);
            this.button_AllPosts.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_AllPosts.Name = "button_AllPosts";
            this.button_AllPosts.Size = new System.Drawing.Size(135, 83);
            this.button_AllPosts.TabIndex = 13;
            this.button_AllPosts.Text = "See All Posts";
            this.button_AllPosts.UseVisualStyleBackColor = true;
            this.button_AllPosts.Click += new System.EventHandler(this.button_AllPosts_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_OwnPosts);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.textBoxRemoveFriend);
            this.panel1.Controls.Add(this.textBoxAddFriend);
            this.panel1.Controls.Add(this.textBoxDeletePost);
            this.panel1.Controls.Add(this.button_DeletePost);
            this.panel1.Controls.Add(this.button_RemoveFriend);
            this.panel1.Controls.Add(this.button_AddFriend);
            this.panel1.Controls.Add(this.button_FriendsList);
            this.panel1.Controls.Add(this.button_FriendsPosts);
            this.panel1.Controls.Add(this.button_AllPosts);
            this.panel1.Controls.Add(this.button_SendPost);
            this.panel1.Controls.Add(this.textBoxPost);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(18, 195);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(724, 547);
            this.panel1.TabIndex = 14;
            // 
            // button_OwnPosts
            // 
            this.button_OwnPosts.Enabled = false;
            this.button_OwnPosts.Location = new System.Drawing.Point(355, 422);
            this.button_OwnPosts.Name = "button_OwnPosts";
            this.button_OwnPosts.Size = new System.Drawing.Size(134, 83);
            this.button_OwnPosts.TabIndex = 26;
            this.button_OwnPosts.Text = "See Own Posts";
            this.button_OwnPosts.UseVisualStyleBackColor = true;
            this.button_OwnPosts.Click += new System.EventHandler(this.button_OwnPosts_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(45, 86);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 25);
            this.label8.TabIndex = 25;
            this.label8.Text = "Delete Post:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 305);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(164, 25);
            this.label7.TabIndex = 24;
            this.label7.Text = "Remove Friend:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(51, 261);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 25);
            this.label6.TabIndex = 23;
            this.label6.Text = "Add Friend:";
            // 
            // textBoxRemoveFriend
            // 
            this.textBoxRemoveFriend.Enabled = false;
            this.textBoxRemoveFriend.Location = new System.Drawing.Point(200, 300);
            this.textBoxRemoveFriend.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxRemoveFriend.Name = "textBoxRemoveFriend";
            this.textBoxRemoveFriend.Size = new System.Drawing.Size(241, 31);
            this.textBoxRemoveFriend.TabIndex = 21;
            // 
            // textBoxAddFriend
            // 
            this.textBoxAddFriend.Enabled = false;
            this.textBoxAddFriend.Location = new System.Drawing.Point(200, 256);
            this.textBoxAddFriend.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxAddFriend.Name = "textBoxAddFriend";
            this.textBoxAddFriend.Size = new System.Drawing.Size(241, 31);
            this.textBoxAddFriend.TabIndex = 20;
            // 
            // textBoxDeletePost
            // 
            this.textBoxDeletePost.Enabled = false;
            this.textBoxDeletePost.Location = new System.Drawing.Point(200, 81);
            this.textBoxDeletePost.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxDeletePost.Name = "textBoxDeletePost";
            this.textBoxDeletePost.Size = new System.Drawing.Size(241, 31);
            this.textBoxDeletePost.TabIndex = 19;
            // 
            // button_DeletePost
            // 
            this.button_DeletePost.Enabled = false;
            this.button_DeletePost.Location = new System.Drawing.Point(520, 81);
            this.button_DeletePost.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_DeletePost.Name = "button_DeletePost";
            this.button_DeletePost.Size = new System.Drawing.Size(152, 56);
            this.button_DeletePost.TabIndex = 18;
            this.button_DeletePost.Text = "Delete";
            this.button_DeletePost.UseVisualStyleBackColor = true;
            this.button_DeletePost.Click += new System.EventHandler(this.button_DeletePost_Click);
            // 
            // button_RemoveFriend
            // 
            this.button_RemoveFriend.Enabled = false;
            this.button_RemoveFriend.Location = new System.Drawing.Point(519, 300);
            this.button_RemoveFriend.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_RemoveFriend.Name = "button_RemoveFriend";
            this.button_RemoveFriend.Size = new System.Drawing.Size(142, 66);
            this.button_RemoveFriend.TabIndex = 17;
            this.button_RemoveFriend.Text = "Remove";
            this.button_RemoveFriend.UseVisualStyleBackColor = true;
            this.button_RemoveFriend.Click += new System.EventHandler(this.button_RemoveFriend_Click);
            // 
            // button_AddFriend
            // 
            this.button_AddFriend.Enabled = false;
            this.button_AddFriend.Location = new System.Drawing.Point(520, 225);
            this.button_AddFriend.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_AddFriend.Name = "button_AddFriend";
            this.button_AddFriend.Size = new System.Drawing.Size(142, 66);
            this.button_AddFriend.TabIndex = 16;
            this.button_AddFriend.Text = "Add";
            this.button_AddFriend.UseVisualStyleBackColor = true;
            this.button_AddFriend.Click += new System.EventHandler(this.button_AddFriend_Click);
            // 
            // button_FriendsList
            // 
            this.button_FriendsList.Enabled = false;
            this.button_FriendsList.Location = new System.Drawing.Point(520, 422);
            this.button_FriendsList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_FriendsList.Name = "button_FriendsList";
            this.button_FriendsList.Size = new System.Drawing.Size(144, 83);
            this.button_FriendsList.TabIndex = 15;
            this.button_FriendsList.Text = "See Friends List";
            this.button_FriendsList.UseVisualStyleBackColor = true;
            this.button_FriendsList.Click += new System.EventHandler(this.button_FriendsList_Click);
            // 
            // button_FriendsPosts
            // 
            this.button_FriendsPosts.Enabled = false;
            this.button_FriendsPosts.Location = new System.Drawing.Point(171, 422);
            this.button_FriendsPosts.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_FriendsPosts.Name = "button_FriendsPosts";
            this.button_FriendsPosts.Size = new System.Drawing.Size(152, 83);
            this.button_FriendsPosts.TabIndex = 14;
            this.button_FriendsPosts.Text = "See Friends\' Posts";
            this.button_FriendsPosts.UseVisualStyleBackColor = true;
            this.button_FriendsPosts.Click += new System.EventHandler(this.button_FriendsPosts_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1310, 998);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.clientLogs);
            this.Controls.Add(this.Button_connect);
            this.Controls.Add(this.button_Disconnect);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Button button_Disconnect;
        private System.Windows.Forms.Button Button_connect;
        private System.Windows.Forms.RichTextBox clientLogs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPost;
        private System.Windows.Forms.Button button_SendPost;
        private System.Windows.Forms.Button button_AllPosts;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxRemoveFriend;
        private System.Windows.Forms.TextBox textBoxAddFriend;
        private System.Windows.Forms.TextBox textBoxDeletePost;
        private System.Windows.Forms.Button button_DeletePost;
        private System.Windows.Forms.Button button_RemoveFriend;
        private System.Windows.Forms.Button button_AddFriend;
        private System.Windows.Forms.Button button_FriendsList;
        private System.Windows.Forms.Button button_FriendsPosts;
        private System.Windows.Forms.Button button_OwnPosts;
    }
}

