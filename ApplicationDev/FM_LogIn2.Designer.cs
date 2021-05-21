
namespace ApplicationDev
{
    partial class FM_Login2
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
            this.userID = new System.Windows.Forms.Label();
            this.UserPW = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtPW = new System.Windows.Forms.TextBox();
            this.btnPassword = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userID
            // 
            this.userID.AutoSize = true;
            this.userID.Location = new System.Drawing.Point(34, 48);
            this.userID.Name = "userID";
            this.userID.Size = new System.Drawing.Size(74, 20);
            this.userID.TabIndex = 0;
            this.userID.Text = "사용자 ID";
            // 
            // UserPW
            // 
            this.UserPW.AutoSize = true;
            this.UserPW.Location = new System.Drawing.Point(34, 105);
            this.UserPW.Name = "UserPW";
            this.UserPW.Size = new System.Drawing.Size(82, 20);
            this.UserPW.TabIndex = 1;
            this.UserPW.Text = "사용자 PW";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(132, 45);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(225, 27);
            this.txtID.TabIndex = 2;
            // 
            // txtPW
            // 
            this.txtPW.Location = new System.Drawing.Point(132, 102);
            this.txtPW.Name = "txtPW";
            this.txtPW.PasswordChar = '*';
            this.txtPW.Size = new System.Drawing.Size(225, 27);
            this.txtPW.TabIndex = 3;
            this.txtPW.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPW_KeyDown);
            // 
            // btnPassword
            // 
            this.btnPassword.Location = new System.Drawing.Point(115, 171);
            this.btnPassword.Name = "btnPassword";
            this.btnPassword.Size = new System.Drawing.Size(117, 47);
            this.btnPassword.TabIndex = 4;
            this.btnPassword.Text = "비밀번호 변경";
            this.btnPassword.UseVisualStyleBackColor = true;
            this.btnPassword.Click += new System.EventHandler(this.btnPassword_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(248, 171);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(109, 47);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "로그인";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click_1);
            // 
            // FM_Login2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 263);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnPassword);
            this.Controls.Add(this.txtPW);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.UserPW);
            this.Controls.Add(this.userID);
            this.Name = "FM_Login2";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userID;
        private System.Windows.Forms.Label UserPW;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtPW;
        private System.Windows.Forms.Button btnPassword;
        private System.Windows.Forms.Button btnLogin;
    }
}

