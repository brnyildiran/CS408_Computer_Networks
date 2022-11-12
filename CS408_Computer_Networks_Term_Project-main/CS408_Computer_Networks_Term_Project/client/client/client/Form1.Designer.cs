namespace client
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
            this.ipLabel = new System.Windows.Forms.Label();
            this.portLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.ipTextBox = new System.Windows.Forms.TextBox();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.connectButton = new System.Windows.Forms.Button();
            this.logTextBox = new System.Windows.Forms.RichTextBox();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.postTextBox = new System.Windows.Forms.TextBox();
            this.postLabel = new System.Windows.Forms.Label();
            this.allPostsButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.seeFriendsButton = new System.Windows.Forms.Button();
            this.removeFriendTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.removeFriendButton = new System.Windows.Forms.Button();
            this.friendsPostsButton = new System.Windows.Forms.Button();
            this.addFriendButton = new System.Windows.Forms.Button();
            this.addFriendTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.deletePostButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.deletePostTextBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ipLabel
            // 
            this.ipLabel.AutoSize = true;
            this.ipLabel.Location = new System.Drawing.Point(112, 409);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(24, 17);
            this.ipLabel.TabIndex = 0;
            this.ipLabel.Text = "IP:";
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(99, 438);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(38, 17);
            this.portLabel.TabIndex = 1;
            this.portLabel.Text = "Port:";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(62, 379);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(77, 17);
            this.usernameLabel.TabIndex = 4;
            this.usernameLabel.Text = "Username:";
            // 
            // ipTextBox
            // 
            this.ipTextBox.Location = new System.Drawing.Point(161, 407);
            this.ipTextBox.Name = "ipTextBox";
            this.ipTextBox.Size = new System.Drawing.Size(123, 22);
            this.ipTextBox.TabIndex = 6;
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(161, 435);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(123, 22);
            this.portTextBox.TabIndex = 7;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(161, 379);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(123, 22);
            this.usernameTextBox.TabIndex = 10;
            // 
            // sendButton
            // 
            this.sendButton.Enabled = false;
            this.sendButton.Location = new System.Drawing.Point(274, 34);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(100, 25);
            this.sendButton.TabIndex = 12;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(308, 406);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(94, 23);
            this.connectButton.TabIndex = 13;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // logTextBox
            // 
            this.logTextBox.Location = new System.Drawing.Point(447, 24);
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.Size = new System.Drawing.Size(303, 437);
            this.logTextBox.TabIndex = 14;
            this.logTextBox.Text = "";
            this.logTextBox.TextChanged += new System.EventHandler(this.logTextBox_TextChanged);
            // 
            // disconnectButton
            // 
            this.disconnectButton.Enabled = false;
            this.disconnectButton.Location = new System.Drawing.Point(308, 438);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(94, 23);
            this.disconnectButton.TabIndex = 15;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // postTextBox
            // 
            this.postTextBox.Enabled = false;
            this.postTextBox.Location = new System.Drawing.Point(65, 38);
            this.postTextBox.Name = "postTextBox";
            this.postTextBox.Size = new System.Drawing.Size(156, 22);
            this.postTextBox.TabIndex = 16;
            // 
            // postLabel
            // 
            this.postLabel.AutoSize = true;
            this.postLabel.Location = new System.Drawing.Point(8, 41);
            this.postLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.postLabel.Name = "postLabel";
            this.postLabel.Size = new System.Drawing.Size(36, 17);
            this.postLabel.TabIndex = 17;
            this.postLabel.Text = "Post";
            // 
            // allPostsButton
            // 
            this.allPostsButton.Enabled = false;
            this.allPostsButton.Location = new System.Drawing.Point(274, 277);
            this.allPostsButton.Margin = new System.Windows.Forms.Padding(2);
            this.allPostsButton.Name = "allPostsButton";
            this.allPostsButton.Size = new System.Drawing.Size(100, 46);
            this.allPostsButton.TabIndex = 18;
            this.allPostsButton.Text = "See all posts";
            this.allPostsButton.UseVisualStyleBackColor = true;
            this.allPostsButton.Click += new System.EventHandler(this.allPostsButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.seeFriendsButton);
            this.panel1.Controls.Add(this.removeFriendTextBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.removeFriendButton);
            this.panel1.Controls.Add(this.friendsPostsButton);
            this.panel1.Controls.Add(this.addFriendButton);
            this.panel1.Controls.Add(this.addFriendTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.deletePostButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.deletePostTextBox);
            this.panel1.Controls.Add(this.sendButton);
            this.panel1.Controls.Add(this.allPostsButton);
            this.panel1.Controls.Add(this.postTextBox);
            this.panel1.Controls.Add(this.postLabel);
            this.panel1.Location = new System.Drawing.Point(28, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 339);
            this.panel1.TabIndex = 19;
            // 
            // seeFriendsButton
            // 
            this.seeFriendsButton.Location = new System.Drawing.Point(15, 277);
            this.seeFriendsButton.Name = "seeFriendsButton";
            this.seeFriendsButton.Size = new System.Drawing.Size(100, 46);
            this.seeFriendsButton.TabIndex = 29;
            this.seeFriendsButton.Text = "See all friends";
            this.seeFriendsButton.UseVisualStyleBackColor = true;
            this.seeFriendsButton.Click += new System.EventHandler(this.seeFriendsButton_Click);
            // 
            // removeFriendTextBox
            // 
            this.removeFriendTextBox.Location = new System.Drawing.Point(240, 206);
            this.removeFriendTextBox.Name = "removeFriendTextBox";
            this.removeFriendTextBox.Size = new System.Drawing.Size(134, 22);
            this.removeFriendTextBox.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(220, 17);
            this.label3.TabIndex = 27;
            this.label3.Text = "Enter username to remove friend:";
            // 
            // removeFriendButton
            // 
            this.removeFriendButton.Location = new System.Drawing.Point(299, 234);
            this.removeFriendButton.Name = "removeFriendButton";
            this.removeFriendButton.Size = new System.Drawing.Size(75, 23);
            this.removeFriendButton.TabIndex = 26;
            this.removeFriendButton.Text = "Remove";
            this.removeFriendButton.UseVisualStyleBackColor = true;
            this.removeFriendButton.Click += new System.EventHandler(this.removeFriendButton_Click);
            // 
            // friendsPostsButton
            // 
            this.friendsPostsButton.Location = new System.Drawing.Point(149, 277);
            this.friendsPostsButton.Name = "friendsPostsButton";
            this.friendsPostsButton.Size = new System.Drawing.Size(96, 46);
            this.friendsPostsButton.TabIndex = 25;
            this.friendsPostsButton.Text = "See posts from friends";
            this.friendsPostsButton.UseVisualStyleBackColor = true;
            this.friendsPostsButton.Click += new System.EventHandler(this.friendsPostsButton_Click);
            // 
            // addFriendButton
            // 
            this.addFriendButton.Location = new System.Drawing.Point(333, 177);
            this.addFriendButton.Name = "addFriendButton";
            this.addFriendButton.Size = new System.Drawing.Size(41, 23);
            this.addFriendButton.TabIndex = 24;
            this.addFriendButton.Text = "Add";
            this.addFriendButton.UseVisualStyleBackColor = true;
            this.addFriendButton.Click += new System.EventHandler(this.addFriendButton_Click);
            // 
            // addFriendTextBox
            // 
            this.addFriendTextBox.Location = new System.Drawing.Point(236, 149);
            this.addFriendTextBox.Name = "addFriendTextBox";
            this.addFriendTextBox.Size = new System.Drawing.Size(138, 22);
            this.addFriendTextBox.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 17);
            this.label2.TabIndex = 22;
            this.label2.Text = "Enter username to add friend:";
            // 
            // deletePostButton
            // 
            this.deletePostButton.Location = new System.Drawing.Point(274, 69);
            this.deletePostButton.Name = "deletePostButton";
            this.deletePostButton.Size = new System.Drawing.Size(100, 23);
            this.deletePostButton.TabIndex = 21;
            this.deletePostButton.Text = "Delete";
            this.deletePostButton.UseVisualStyleBackColor = true;
            this.deletePostButton.Click += new System.EventHandler(this.deletePostButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "Enter Post ID to delete:";
            // 
            // deletePostTextBox
            // 
            this.deletePostTextBox.Location = new System.Drawing.Point(164, 66);
            this.deletePostTextBox.Name = "deletePostTextBox";
            this.deletePostTextBox.Size = new System.Drawing.Size(57, 22);
            this.deletePostTextBox.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 505);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.ipTextBox);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.ipLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox ipTextBox;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.RichTextBox logTextBox;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.TextBox postTextBox;
        private System.Windows.Forms.Label postLabel;
        private System.Windows.Forms.Button allPostsButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox deletePostTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button deletePostButton;
        private System.Windows.Forms.TextBox addFriendTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button removeFriendButton;
        private System.Windows.Forms.Button friendsPostsButton;
        private System.Windows.Forms.Button addFriendButton;
        private System.Windows.Forms.TextBox removeFriendTextBox;
        private System.Windows.Forms.Button seeFriendsButton;
    }
}

