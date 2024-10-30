namespace ChatOnline2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtChat = new TextBox();
            txtMessage = new TextBox();
            btnSend = new Button();
            btnConnect = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // txtChat
            // 
            txtChat.Location = new Point(194, 42);
            txtChat.Multiline = true;
            txtChat.Name = "txtChat";
            txtChat.Size = new Size(196, 256);
            txtChat.TabIndex = 0;
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(24, 42);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(100, 23);
            txtMessage.TabIndex = 1;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(24, 90);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(75, 23);
            btnSend.TabIndex = 2;
            btnSend.Text = "отправить";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(713, 15);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(75, 23);
            btnConnect.TabIndex = 3;
            btnConnect.Text = "Connected";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 19);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 4;
            label1.Text = "Chat";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(btnConnect);
            Controls.Add(btnSend);
            Controls.Add(txtMessage);
            Controls.Add(txtChat);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtChat;
        private TextBox txtMessage;
        private Button btnSend;
        private Button btnConnect;
        private Label label1;
    }
}
