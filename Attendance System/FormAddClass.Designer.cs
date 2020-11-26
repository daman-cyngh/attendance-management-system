namespace Attendance_System
{
    partial class FormAddClass
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBoxAddClass = new MetroFramework.Controls.MetroTextBox();
            this.metroButtonAddClass = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BackColor = System.Drawing.Color.White;
            this.metroLabel1.Location = new System.Drawing.Point(49, 40);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(81, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Class Name:";
            // 
            // metroTextBoxAddClass
            // 
            this.metroTextBoxAddClass.Location = new System.Drawing.Point(147, 40);
            this.metroTextBoxAddClass.Name = "metroTextBoxAddClass";
            this.metroTextBoxAddClass.Size = new System.Drawing.Size(140, 23);
            this.metroTextBoxAddClass.TabIndex = 1;
            // 
            // metroButtonAddClass
            // 
            this.metroButtonAddClass.Location = new System.Drawing.Point(212, 88);
            this.metroButtonAddClass.Name = "metroButtonAddClass";
            this.metroButtonAddClass.Size = new System.Drawing.Size(75, 23);
            this.metroButtonAddClass.TabIndex = 2;
            this.metroButtonAddClass.Text = "Accept";
            this.metroButtonAddClass.Click += new System.EventHandler(this.metroButtonAddClass_Click);
            // 
            // FormAddClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(344, 162);
            this.Controls.Add(this.metroButtonAddClass);
            this.Controls.Add(this.metroTextBoxAddClass);
            this.Controls.Add(this.metroLabel1);
            this.Name = "FormAddClass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAddClass";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox metroTextBoxAddClass;
        private MetroFramework.Controls.MetroButton metroButtonAddClass;
    }
}