using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DEV_Form; // 캡슐화

namespace ApplicationDev
{
    public partial class FM_Main : Form
    {
        public FM_Main()
        {
            InitializeComponent();
            FM_Login2 login = new FM_Login2();
            login.ShowDialog();
            tssUserName.Text = login.Tag.ToString();
            if (login.Tag.ToString() == "FAIL")
            {
                System.Environment.Exit(0); // 로그인 못한 경우 종료
            }
            // 버튼에 이벤트 추가
            this.stbExit.Click += new System.EventHandler(this.stbExit_Click);

            // 메뉴 클릭 이벤트 추가
            this.M_SYSTEM.DropDownItemClicked +=
                new System.Windows.Forms.ToolStripItemClickedEventHandler(this.drp);
        }
        private void stbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tssNowDate.Text = DateTime.Now.ToString();
        }

        private void drp(object sender, ToolStripItemClickedEventArgs e)
        {
            // 1. 단순히 폼을 호출하는 경우
            //DEV_Form.MDI_TEST Form = new DEV_Form.MDI_TEST();
            //Form.MdiParent = this;
            //Form.Show();

            // 2. 프로그램 호출(DEV_Form의 MIDI_TEST1, 2를 불러오는 과정)
            // (1) Assembly 객체 생성하여 파일위치를 assemb에 삽입
            Assembly assemb = Assembly.LoadFrom(Application.StartupPath + @"\" + "DEV_Form.DLL");
            // (2) e.ClickedItem.Name(=클릭한 메뉴 이름(MDI_TEST))의 타입을 typeForm에 넣음
            Type typeForm = assemb.GetType("DEV_Form." + e.ClickedItem.Name.ToString(), true);
            // (3) 불러온 타입을 폼형식으로 변환한 뒤 호출시키는 메소드를 ShowForm에 넣음
            Form ShowForm = (Form)Activator.CreateInstance(typeForm);

            ShowForm.MdiParent = this;
            ShowForm.Show();
        }
    }
}