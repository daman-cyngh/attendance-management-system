﻿using System;
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
    public partial class FormAddClass : Form
    {
        public int UserID { set; get; }
        public FormAddClass()
        {
            InitializeComponent();
        }

        private void metroButtonAddClass_Click(object sender, EventArgs e)
        {
            DataSet1TableAdapters.ClassesTBLTableAdapter ada = new DataSet1TableAdapters.ClassesTBLTableAdapter();
            ada.AddClass(metroTextBoxAddClass.Text, UserID);
            Close();
        }
    }
}
