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
    public partial class RegisterFrm : Form
    {
        public RegisterFrm()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if(metroTextBox2.Text != metroTextBox3.Text)
            {
                MessageBox.Show("Passwords don't match!");
                return;
            }
            DataSet1TableAdapters.UsersTableAdapter ada = new DataSet1TableAdapters.UsersTableAdapter();
            ada.InsertQuery(metroTextBox1.Text, metroTextBox2.Text);
            MessageBox.Show("Registration Successfull!");
            Close();
        }
    }
}
