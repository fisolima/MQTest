namespace WinApp
{
    partial class main
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
            this._messages = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._appName = new System.Windows.Forms.TextBox();
            this._startApp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _messages
            // 
            this._messages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._messages.Location = new System.Drawing.Point(12, 126);
            this._messages.Name = "_messages";
            this._messages.Size = new System.Drawing.Size(537, 96);
            this._messages.TabIndex = 0;
            this._messages.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "App Name:";
            // 
            // _appName
            // 
            this._appName.Location = new System.Drawing.Point(79, 10);
            this._appName.Name = "_appName";
            this._appName.Size = new System.Drawing.Size(140, 20);
            this._appName.TabIndex = 2;
            this._appName.TextChanged += new System.EventHandler(this.AppNameChanged);
            // 
            // _startApp
            // 
            this._startApp.Enabled = false;
            this._startApp.Location = new System.Drawing.Point(226, 9);
            this._startApp.Name = "_startApp";
            this._startApp.Size = new System.Drawing.Size(75, 23);
            this._startApp.TabIndex = 3;
            this._startApp.Text = "Start";
            this._startApp.UseVisualStyleBackColor = true;
            this._startApp.Click += new System.EventHandler(this.StartApp);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 234);
            this.Controls.Add(this._startApp);
            this.Controls.Add(this._appName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._messages);
            this.Name = "main";
            this.Text = "MQ Test WinApp";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.main_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox _messages;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _appName;
        private System.Windows.Forms.Button _startApp;
    }
}

