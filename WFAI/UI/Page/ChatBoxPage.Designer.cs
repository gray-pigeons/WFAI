

namespace WFAI.Page
{
    partial class ChatBoxPage
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
            lvChatMsgList = new AntdUI.Chat.ChatList();
            uiTitlePanel1 = new Sunny.UI.UITitlePanel();
            txtInputMsg = new AntdUI.Input();
            lbSetting = new Sunny.UI.UILabel();
            btnSendMsg = new Sunny.UI.UIButton();
            userChatPanel.SuspendLayout();
            uiTitlePanel1.SuspendLayout();
            SuspendLayout();
            // 
            // userChatPanel
            // 
            userChatPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            userChatPanel.Controls.Add(lvChatMsgList);
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
            // lvChatMsgList
            // 
            lvChatMsgList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvChatMsgList.Location = new Point(4, 36);
            lvChatMsgList.Name = "lvChatMsgList";
            lvChatMsgList.Size = new Size(1516, 617);
            lvChatMsgList.TabIndex = 2;
            lvChatMsgList.Text = "chatList1";
            // 
            // uiTitlePanel1
            // 
            uiTitlePanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            uiTitlePanel1.Controls.Add(txtInputMsg);
            uiTitlePanel1.Controls.Add(lbSetting);
            uiTitlePanel1.Controls.Add(btnSendMsg);
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
            // txtInputMsg
            // 
            txtInputMsg.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtInputMsg.Location = new Point(4, 42);
            txtInputMsg.Multiline = true;
            txtInputMsg.Name = "txtInputMsg";
            txtInputMsg.PlaceholderText = "请输入内容";
            txtInputMsg.Size = new Size(1516, 142);
            txtInputMsg.TabIndex = 3;
            txtInputMsg.KeyDown += TxtInputMsg_KeyDown;
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
            // ChatBoxPage
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1550, 936);
            Controls.Add(userChatPanel);
            Name = "ChatBoxPage";
            Text = "聊天2号";
            userChatPanel.ResumeLayout(false);
            uiTitlePanel1.ResumeLayout(false);
            ResumeLayout(false);
        }


        #endregion


        private Sunny.UI.UITitlePanel userChatPanel;
        private Sunny.UI.UITitlePanel uiTitlePanel1;
        private Sunny.UI.UIButton btnSendMsg;
        private Sunny.UI.UILabel lbSetting;
        private AntdUI.Chat.ChatList lvChatMsgList;
        private AntdUI.Input txtInputMsg;
    }
}