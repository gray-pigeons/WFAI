using Sunny.UI;
using WFAI.Page;
using WFAI.Utils.Net;
using WFAI.Utils.Net.HttpEx;
using WFAI.Utils.Tools.IniEx;

namespace WFAI
{
    public partial class MainForm : UIAsideHeaderMainFrame
    {
        public MainForm()
        {
            InitializeComponent();
            InitAddLeftMuenCom();
            //HttpEx.Init();
            IniEx.Init();
            DifyChatClientEx.Init();
        }

        private void InitAddLeftMuenCom()
        {
            int pageIndex = 1000;
            //Aside.Nodes.Add("聊天");
            //Aside.Nodes.Add("工控");
            //Aside.Nodes.Add("主题");
            //Aside.SetNodeSymbol(Aside.Nodes[0], 61451);
            //Aside.SetNodePageIndex(Aside.Nodes[0], pageIndex);
            TreeNode parent = Aside.CreateNode("聊天", 61451, 24, pageIndex);
            //通过设置PageIndex关联，节点文字、图标由相应的Page的Text、Symbol提供
            Aside.CreateChildNode(parent, AddPage(new UserChatPage(), ++pageIndex));
            //选中第一个节点
            Aside.SelectPage(pageIndex);

        }

        public override void Init()
        {
            
        }

        private void uiAvatar_Icon_Click(object sender, EventArgs e)
        {

        }

        private void Aside_MenuItemClick(TreeNode node, NavMenuItem item, int pageIndex)
        {

        }
    }
}
