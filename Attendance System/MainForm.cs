using Attendance_System.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Attendance_System
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        public bool isLoggedIn { get; set; }
        public int UserID { set; get; }
        public MainForm()
        {
            InitializeComponent();
        }

        SqlConnection conn;
        SqlCommand cmd;
        private void MainForm_Load(object sender, EventArgs e)
        {
            


        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            if(isLoggedIn == false)
            {
                //open login form 
                LoginForm newLogin = new LoginForm();
                newLogin.ShowDialog();

                if (newLogin.loginFlag == false)
                {
                    Close();
                }
                else
                {
                    isLoggedIn = true;
                    UserID = newLogin.UserID;
                    statusLabelUser.Text = UserID.ToString();

                    // TODO: This line of code loads data into the 'dataSet1.ClassesTBL' table. You can move, or remove it, as needed.
                    this.classesTBLTableAdapter.Fill(this.dataSet1.ClassesTBL);
                    classesTBLBindingSource.Filter = "UserID = '" + UserID.ToString() + "'";
                }
            }
           
        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }

        private void metroButtonAddClass_Click(object sender, EventArgs e)
        {
            FormAddClass addClass = new FormAddClass();
            addClass.UserID = this.UserID;
            addClass.ShowDialog();

        }

        private void metroButtonAddStudents_Click(object sender, EventArgs e)
        {
            StudentsAddForm addStudent = new StudentsAddForm();
            addStudent.ClassID = Convert.ToInt32(metroComboBox1.SelectedValue);
            addStudent.ClassName = metroComboBox1.Text;
            addStudent.ShowDialog();
        }

        private void metroButtonGetValues_Click(object sender, EventArgs e)
        {
            //check if records exist and if not create a record for each student and load for edit

            AttendanceRecordsTBLTableAdapter ada = new AttendanceRecordsTBLTableAdapter();
            DataTable dt = ada.GetDataBy((int)metroComboBox1.SelectedValue, dateTimePicker1.Text);

            if(dt.Rows.Count > 0)
            {
                //we have records, so we can edit
                DataTable dt_new = ada.GetDataBy((int)metroComboBox1.SelectedValue, dateTimePicker1.Text);
                dataGridView1.DataSource = dt_new;
            }
            else
            {
                //create a record for each student
                //Get the class students list
                StudentsTBLTableAdapter students_adapter = new StudentsTBLTableAdapter();
                DataTable dt_Students = students_adapter.GetDataByClassID((int)metroComboBox1.SelectedValue);
                foreach(DataRow row in dt_Students.Rows)
                {
                    //Insert a new Record for this student
                    ada.InsertQuery((int)row[0], (int)metroComboBox1.SelectedValue, dateTimePicker1.Text, row[1].ToString(), metroComboBox1.Text, "");
                }

                DataTable dt_new = ada.GetDataBy((int)metroComboBox1.SelectedValue, dateTimePicker1.Text);
                dataGridView1.DataSource = dt_new;
            }
        }

        private void metroButtonSave_Click(object sender, EventArgs e)
        {
            AttendanceRecordsTBLTableAdapter ada = new AttendanceRecordsTBLTableAdapter();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if(row.Cells[1].Value != null)
                {
                    ada.UpdateQuery(row.Cells[1].Value.ToString(), row.Cells[0].Value.ToString(), (int)metroComboBox1.SelectedValue, dateTimePicker1.Text);
                }
            }
            DataTable dt_new = ada.GetDataBy((int)metroComboBox1.SelectedValue, dateTimePicker1.Text);
            dataGridView1.DataSource = dt_new;
        }

        private void metroButtonClear_Click(object sender, EventArgs e)
        {
            AttendanceRecordsTBLTableAdapter ada = new AttendanceRecordsTBLTableAdapter();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[1].Value != null)
                {
                    ada.UpdateQuery("", row.Cells[0].Value.ToString(), (int)metroComboBox1.SelectedValue, dateTimePicker1.Text);
                }
            }
            DataTable dt_new = ada.GetDataBy((int)metroComboBox1.SelectedValue, dateTimePicker1.Text);
            dataGridView1.DataSource = dt_new;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            //get students
            StudentsTBLTableAdapter students_adapter = new StudentsTBLTableAdapter();
            DataTable dt_Students = students_adapter.GetDataByClassID((int)metroComboBox2.SelectedValue);

            AttendanceRecordsTBLTableAdapter ada = new AttendanceRecordsTBLTableAdapter();

            int p = 0;
            int a = 0;
            int l = 0;
            int ex = 0;

            string connectionString = @"Data Source=LAPTOP-1QRG78IU; Initial Catalog=AttendanceDB;integrated security=SSPI";
            conn = new SqlConnection(connectionString);
            
            //loop through students and get the values
            foreach (DataRow row in dt_Students.Rows)
            {
               
                string query = string.Format("SELECT COUNT(Status) FROM AttendanceRecordsTBL WHERE MONTH(DateAttendance) = {0} AND StudentName = '{1}' AND Status = 'p'", dateTimePicker2.Value.Month, row[1].ToString());
                cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    p = Convert.ToInt32(dr[0].ToString());

                }
                conn.Close();

                query = string.Format("SELECT COUNT(Status) FROM AttendanceRecordsTBL WHERE MONTH(DateAttendance) = {0} AND StudentName = '{1}' AND Status = 'a'", dateTimePicker2.Value.Month, row[1].ToString());
                cmd = new SqlCommand(query, conn);
                conn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    a = Convert.ToInt32(dr[0].ToString());

                }
                conn.Close();

                query = string.Format("SELECT COUNT(Status) FROM AttendanceRecordsTBL WHERE MONTH(DateAttendance) = {0} AND StudentName = '{1}' AND Status = 'l'", dateTimePicker2.Value.Month, row[1].ToString());
                cmd = new SqlCommand(query, conn);
                conn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    l = Convert.ToInt32(dr[0].ToString());

                }
                conn.Close();

                query = string.Format("SELECT COUNT(Status) FROM AttendanceRecordsTBL WHERE MONTH(DateAttendance) = {0} AND StudentName = '{1}' AND Status = 'e'", dateTimePicker2.Value.Month, row[1].ToString());
                cmd = new SqlCommand(query, conn);
                conn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    ex = Convert.ToInt32(dr[0].ToString());

                }
                conn.Close();


                ListViewItem litem = new ListViewItem();
                litem.Text = row[1].ToString();
                litem.SubItems.Add(p.ToString());
                litem.SubItems.Add(a.ToString());
                litem.SubItems.Add(l.ToString());
                litem.SubItems.Add(ex.ToString());
                listView1.Items.Add(litem);
            }

            
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            RegisterFrm reg = new RegisterFrm();
            reg.ShowDialog();
        }
    }
}
