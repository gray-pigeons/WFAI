
namespace WFAI.Page
{
    partial class UserChatPage
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
            userChatPanel = new Sunny.UI.UITitlePanel();
            lvMsgData = new ListBox();
            uiTitlePanel1 = new Sunny.UI.UITitlePanel();
            lbSetting = new Sunny.UI.UILabel();
            btnSendMsg = new Sunny.UI.UIButton();
            txtInputMsg = new Sunny.UI.UITextBox();
            userChatPanel.SuspendLayout();
            uiTitlePanel1.SuspendLayout();
            SuspendLayout();
            // 
            // userChatPanel
            // 
            userChatPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            userChatPanel.Controls.Add(lvMsgData);
            userChatPanel.Controls.Add(uiTitlePanel1);
            userChatPanel.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            userChatPanel.Location = new Point(13, 14);
            userChatPanel.Margin = new Padding(4, 5, 4, 5);
            userChatPanel.MinimumSize = new Size(1, 1);
            userChatPanel.Name = "userChatPanel";
            userChatPanel.ShowText = false;
            userChatPanel.Size = new Size(1524, 908);
            userChatPanel.TabIndex = 0;
            userChatPanel.Text = "用户名显示";
            userChatPanel.TextAlignment = ContentAlignment.MiddleLeft;
            // 
            // lvMsgData
            // 
            lvMsgData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvMsgData.FormattingEnabled = true;
            lvMsgData.ItemHeight = 24;
            lvMsgData.Location = new Point(4, 43);
            lvMsgData.Name = "lvMsgData";
            lvMsgData.Size = new Size(1516, 604);
            lvMsgData.TabIndex = 2;
            // 
            // uiTitlePanel1
            // 
            uiTitlePanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            uiTitlePanel1.Controls.Add(lbSetting);
            uiTitlePanel1.Controls.Add(btnSendMsg);
            uiTitlePanel1.Controls.Add(txtInputMsg);
            uiTitlePanel1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiTitlePanel1.Location = new Point(0, 661);
            uiTitlePanel1.Margin = new Padding(4, 5, 4, 5);
            uiTitlePanel1.MinimumSize = new Size(1, 1);
            uiTitlePanel1.Name = "uiTitlePanel1";
            uiTitlePanel1.ShowText = false;
            uiTitlePanel1.Size = new Size(1524, 242);
            uiTitlePanel1.TabIndex = 1;
            uiTitlePanel1.Text = null;
            uiTitlePanel1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // lbSetting
            // 
            lbSetting.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lbSetting.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lbSetting.ForeColor = Color.FromArgb(48, 48, 48);
            lbSetting.Location = new Point(15, 190);
            lbSetting.Name = "lbSetting";
            lbSetting.Size = new Size(109, 48);
            lbSetting.TabIndex = 3;
            lbSetting.Text = "设置";
            lbSetting.TextAlign = ContentAlignment.MiddleCenter;
            lbSetting.Click += lbSetting_Click;
            // 
            // btnSendMsg
            // 
            btnSendMsg.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnSendMsg.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSendMsg.Location = new Point(1370, 190);
            btnSendMsg.MinimumSize = new Size(1, 1);
            btnSendMsg.Name = "btnSendMsg";
            btnSendMsg.Size = new Size(150, 48);
            btnSendMsg.TabIndex = 1;
            btnSendMsg.Text = "发送";
            btnSendMsg.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSendMsg.Click += btnSendMsg_Click;
            // 
            // txtInputMsg
            // 
            txtInputMsg.BackgroundImageLayout = ImageLayout.None;
            txtInputMsg.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtInputMsg.Location = new Point(4, 42);
            txtInputMsg.Margin = new Padding(4, 5, 4, 5);
            txtInputMsg.MinimumSize = new Size(1, 16);
            txtInputMsg.Name = "txtInputMsg";
            txtInputMsg.Padding = new Padding(5);
            txtInputMsg.ShowText = false;
            txtInputMsg.Size = new Size(1516, 140);
            txtInputMsg.TabIndex = 0;
            txtInputMsg.TextAlignment = ContentAlignment.TopLeft;
            txtInputMsg.Watermark = "请输入对话内容";
            txtInputMsg.ZoomScaleDisabled = true;
            txtInputMsg.KeyDown += TxtInputMsg_KeyDown;
            // 
            // UserChatPage
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1550, 936);
            Controls.Add(userChatPanel);
            Name = "UserChatPage";
            Text = "聊天1号";
            userChatPanel.ResumeLayout(false);
            uiTitlePanel1.ResumeLayout(false);
            ResumeLayout(false);
        }





        #endregion

        private Sunny.UI.UITitlePanel userChatPanel;
        private Sunny.UI.UITitlePanel uiTitlePanel1;
        private Sunny.UI.UITextBox txtInputMsg;
        private Sunny.UI.UIButton btnSendMsg;
        private ListBox lvMsgData;
        private Sunny.UI.UILabel lbSetting;
    }
}