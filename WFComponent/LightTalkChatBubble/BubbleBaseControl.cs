﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightTalkChatBubble
{
    public class BubbleBaseControl:UserControl
    {
        public delegate void ProfileRightClickHandle(string senderID, object sender, MouseEventArgs e);
        public event ProfileRightClickHandle OnProfileRightClickHandle;
        protected string senderID;

        public BubbleBaseControl()
        {
        }
        public BubbleBaseControl(Control parent) {
            this.Parent = parent;
        }

        protected void on_profile_picture_box_clicked(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                OnProfileRightClickHandle?.Invoke(this.senderID, sender, e);
            }
        }
    }

    //public class BubbleBase : BubbleBaseControl
    //{
    //    public BubbleBase(Control parent) : base(parent)
    //    {
    //        this.Parent = parent;
            
    //    }
    //}
}
