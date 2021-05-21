using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ApplicationDev
{
    public partial class FM_Login2 : Form
    {
        private int PWFailCount = 0;
        private SqlConnection Connect = null;      // 데이터베이스 접속 정보 
        private SqlTransaction Tran;               // 데이터베이스 관리 권한(BEGIN TRAN)
        private SqlCommand cmd = new SqlCommand(); // 데이터베이스 명령 전달
        public FM_Login2()
        {
            InitializeComponent();
        }


        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            try
            {
                //this.Visible = false; // 로그인 화면을 보이지 않게 한다.
                //FM_Password fm = new FM_Password(); // 비밀번호 변경 화면 협업을 호출한다
                //fm.ShowDialog(); // Show()랑은 다르다(둘다 띄워서 작업 가능). SD는 비밀번호 변경화면을 닫지않은 이상 작업 불가능!
                this.Visible = true;
                string strCon = "Data Source=61.105.9.203; Initial Catalog=AppDev; User ID=kfqs;Password=1234";
                Connect = new SqlConnection(strCon);

                Connect.Open(); // 데이터베이스에 접속한다

                // DB 접속이 되지 않았을 경우 메세지 리턴후 이벤트 종료
                if (Connect.State != System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("데이터베이스 연결에 실패하였습니다.");
                    return;
                }

                // 1. ID존재 여부 확인
                string Loginid = string.Empty; // 로그인 ID
                string NewPw = string.Empty; // 신규 비밀번호

                Loginid = txtID.Text;
                NewPw = txtPW.Text;

                // SQL 조회문을 실행시키기 위한 어댑터
                SqlDataAdapter Adapter = new SqlDataAdapter("SELECT PW, USERNAME FROM TB_USER_LJH WHERE USERID = '" + Loginid + "'", Connect);

                // 데이터를 담을 그릇
                DataTable DtTemp = new DataTable();

                // 어댑터 실행 후 그릇에 데이터 담기
                Adapter.Fill(DtTemp);

                // 데이터가 없는 경우 사용자가 없다고 메세지 및 리턴
                if (DtTemp.Rows.Count == 0)
                {
                    MessageBox.Show("아이디가 잘못되었습니다.");
                    txtID.Text = "";
                    return;
                }

                // 2. 비밀번호가 일치하는지 확인
                else if (DtTemp.Rows[0]["Pw"].ToString() != NewPw)
                {
                    while (PWFailCount < 2)
                    {
                        PWFailCount += 1;
                        MessageBox.Show("비밀번호가 잘못 되었습니다. 누적 횟수 : " + PWFailCount.ToString());
                        txtPW.Text = "";
                        return;
                    }
                    MessageBox.Show("비밀번호가 3회 이상 틀렸습니다");
                    txtPW.Text = "";
                    this.Close();
                }

                else
                {
                    this.Tag = DtTemp.Rows[0]["USERNAME"].ToString(); // 유저명을 테그에 집어넣음
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("로그인 작업중 오류가 발생하였습니다." + ex.ToString());
            }
            finally
            {
                Connect.Close();
            }
        }
    }
}
