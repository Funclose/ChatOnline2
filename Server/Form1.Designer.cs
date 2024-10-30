namespace Server
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
            txtLog = new TextBox();
            btnStartServer = new Button();
            SuspendLayout();
            // 
            // txtLog
            // 
            txtLog.Location = new Point(29, 69);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.Size = new Size(263, 184);
            txtLog.TabIndex = 0;
            // 
            // btnStartServer
            // 
            btnStartServer.Location = new Point(29, 12);
            btnStartServer.Name = "btnStartServer";
            btnStartServer.Size = new Size(75, 23);
            btnStartServer.TabIndex = 1;
            btnStartServer.Text = "StartServer";
            btnStartServer.UseVisualStyleBackColor = true;
            btnStartServer.Click += btnStartServer_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnStartServer);
            Controls.Add(txtLog);
            Name = "Form1";
            Text = "Form1";
            FormClosed += Form1_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtLog;
        private Button btnStartServer;
    }
}
