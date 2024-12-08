namespace WFAI
{
    partial class MainForm
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
            uiAvatar_Icon = new Sunny.UI.UIAvatar();
            Header.SuspendLayout();
            SuspendLayout();
            // 
            // Header
            // 
            Header.Controls.Add(uiAvatar_Icon);
            Header.Size = new Size(1301, 72);
            // 
            // Aside
            // 
            Aside.Size = new Size(250, 884);
            Aside.MenuItemClick += Aside_MenuItemClick;
            // 
            // uiAvatar_Icon
            // 
            uiAvatar_Icon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            uiAvatar_Icon.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiAvatar_Icon.Location = new Point(1210, 4);
            uiAvatar_Icon.MinimumSize = new Size(1, 1);
            uiAvatar_Icon.Name = "uiAvatar_Icon";
            uiAvatar_Icon.Size = new Size(75, 62);
            uiAvatar_Icon.TabIndex = 0;
            uiAvatar_Icon.Text = "uiAvatar1";
            uiAvatar_Icon.Click += uiAvatar_Icon_Click;
            // 
            // MainForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1551, 919);
            Name = "MainForm";
            Text = "Form1";
            ZoomScaleRect = new Rectangle(22, 22, 800, 450);
            Header.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIAvatar uiAvatar_Icon;
    }
}
