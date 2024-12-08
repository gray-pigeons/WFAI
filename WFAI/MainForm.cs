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
            //Aside.Nodes.Add("����");
            //Aside.Nodes.Add("����");
            //Aside.Nodes.Add("����");
            //Aside.SetNodeSymbol(Aside.Nodes[0], 61451);
            //Aside.SetNodePageIndex(Aside.Nodes[0], pageIndex);
            TreeNode parent = Aside.CreateNode("����", 61451, 24, pageIndex);
            //ͨ������PageIndex�������ڵ����֡�ͼ������Ӧ��Page��Text��Symbol�ṩ
            Aside.CreateChildNode(parent, AddPage(new UserChatPage(), ++pageIndex));
            //ѡ�е�һ���ڵ�
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
