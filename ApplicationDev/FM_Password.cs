﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace ApplicationDev
{
    public partial class FM_Password : Form
    {
        private SqlConnection Connect = null;      // 데이터베이스 접속 정보 
        private SqlTransaction Tran;               // 데이터베이스 관리 권한(BEGIN TRAN)
        private SqlCommand cmd = new SqlCommand(); // 데이터베이스 명령 전달

        public FM_Password()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 비밀번호를 변경한다
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
            string sLoginid = string.Empty; // 로그인 ID
            string sPerPw = string.Empty; // 이전 비밀번호
            string sNewPw = string.Empty; // 신규 비밀번호

            sLoginid = textBox2.Text;
            sPerPw = textBox1.Text;
            sNewPw = textBox3.Text;

            // SQL 조회문을 실행시키기 위한 어댑터
            SqlDataAdapter Adapter = new SqlDataAdapter("SELECT PW FROM TB_USER_LJH WHERE USERID = '" + sLoginid + "'",Connect);

            // 데이터를 담을 그릇
            DataTable DtTemp = new DataTable();

            // 어댑터 실행 후 그릇에 데이터 담기
            Adapter.Fill(DtTemp);

            // 데이터가 없는 경우 사용자가 없다고 메세지 및 리턴
            if (DtTemp.Rows.Count == 0)
            {
                MessageBox.Show("등록되지 않은 사용자 입니다.");
                return;
            }

            // 2. 이전 비밀번호가 일치하는지 확인
            if (DtTemp.Rows[0]["Pw"].ToString() != sPerPw)
            {
                MessageBox.Show("이전 비밀번호가 일치하지 않습니다");
                return;
            }

            // 3. 바뀔 비밀번호로 등록
            else
            {
                // 메세지 박스 Y/N 선택후 N일경우 리턴
                if (MessageBox.Show("해당 비밀번호로 변경 하시겠습니까?", "비밀번호 변경", MessageBoxButtons.YesNo)
                    == DialogResult.No)
                {
                    return;
                }

                Tran = Connect.BeginTransaction("TEST_Tran"); // 트랜잭션 선언
                cmd.Transaction = Tran;   // 커멘드에 트랜젝션 사용여부 등록
                cmd.Connection = Connect; // 커맨드에 접속 정보 입력
                cmd.CommandText = "UPDATE TB_USER_LJH SET PW = '" + sNewPw + "' WHERE USERID = '" + sLoginid + "'";
                cmd.ExecuteNonQuery(); // C,U,D 실행 함수 실행

                Tran.Commit(); // 변경 내용 승인
                MessageBox.Show("정상적으로 변경 하였습니다.");
                this.Close();
                // 4. 변경여부 메세지 에러
            }
        }
    }
}
