namespace WFComponent
{
    partial class ChatBox
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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";

            this.chatPanel = new CCWin.SkinControl.SkinPanel();
            this.SuspendLayout();
            //// 
            //// chatPanel
            //// 
            this.chatPanel.AutoScroll = true;
            this.chatPanel.BackColor = System.Drawing.Color.White;
            this.chatPanel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.chatPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatPanel.DownBack = null;
            this.chatPanel.Location = new System.Drawing.Point(0, 0);
            this.chatPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chatPanel.MouseBack = null;
            this.chatPanel.Name = "chatPanel";
            this.chatPanel.NormlBack = null;
            this.chatPanel.Size = new System.Drawing.Size(1098, 628);
            this.chatPanel.TabIndex = 0;
            this.chatPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.chatPanel_Paint);
            // 
            // ChatBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.chatPanel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ChatBox";
            this.Size = new System.Drawing.Size(1098, 628);
            this.Load += new System.EventHandler(this.ChatBox_Load);
            this.ResumeLayout(false);
        }

        #endregion
        private CCWin.SkinControl.SkinPanel chatPanel;
    }
}
