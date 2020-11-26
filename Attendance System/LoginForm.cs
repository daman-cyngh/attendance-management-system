using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Attendance_System
{
    public partial class LoginForm : Form
    {
        public bool loginFlag { get; set; }
        public int UserID { set; get; }
        public LoginForm()
        {
            InitializeComponent();
            loginFlag = false;
        }

        private void metroTextBox2_Click(object sender, EventArgs e)
        {

        }

        private void metroButtonLogin_Click(object sender, EventArgs e)
        {
            DataSet1TableAdapters.UsersTableAdapter userAda = new DataSet1TableAdapters.UsersTableAdapter();
            DataTable dt = userAda.GetDataByUserIDAndPassword(metroTextBoxUser.Text, metroTextBoxPassword.Text);
            if(dt.Rows.Count > 0)
            {
                //login is valid
                loginFlag = true;
                UserID = int.Parse(dt.Rows[0]["UserID"].ToString());
                MessageBox.Show("Login Successful!");
            }
            else
            {
                //login is invalid
                MessageBox.Show("Invalid Credentials!");
                loginFlag = false;
                return;
                
            }
            Close();
        }
    }
}
