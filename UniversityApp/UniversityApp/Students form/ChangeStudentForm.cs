using MySql.Data.MySqlClient;
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

namespace UniversityApp
{
    public partial class ChangeStudentForm : Form
    {
        private List<string[]> list_faculties = new List<string[]>();
        private List<string[]> data_groups;
        private MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=itproger");
        public string index;
        public bool change_result = false;
        public List<string> data;

        public ChangeStudentForm()
        {
            InitializeComponent();
            loadData();
        }

        public string StudentID         // для установки значений в текстовые поля
        {
            get { return numberStudent.Text; }
            set { numberStudent.Text = value; }
        }

        public string NameStudent      // для установки значений в текстовые поля
        {
            get { return nameStudent.Text; }
            set { nameStudent.Text = value; }
        }

        public string SurnameStudent  // для установки значений в текстовые поля
        {
            get { return surnameStudent.Text; }
            set { surnameStudent.Text = value; }
        }

        public string FacultyStudent  // для установки значений в текстовые поля
        {
            get { return facultyCombo.Text; }
            set { facultyCombo.Text = value; }
        }

        public string GroupCombo     // для установки значений в текстовые поля
        {
            get { return groupCombo.Text; }
            set { groupCombo.Text = value; }
        }

        private void loadData()
        {
            this.numberStudent.ReadOnly = true;

            FacyltiesGroupsData db = new FacyltiesGroupsData(connection);

            this.data_groups = db.getAllData();

            for (int i = 0; i < data_groups.Count; ++i)
            {
                this.list_faculties.Add(new string[2]);
                this.list_faculties[i][0] = this.data_groups[i][0];
                this.list_faculties[i][1] = this.data_groups[i][1];
            }

            for (int i = 0; i < this.list_faculties.Count; ++i)
            {
                for (int a = i + 1; a < this.list_faculties.Count; ++a)
                {
                    if (this.list_faculties[i][1] == this.list_faculties[a][1])
                    {
                        this.list_faculties.RemoveAt(a);
                    }
                }
            }

            for (int i = 0; i < list_faculties.Count(); ++i)
            {
                this.facultyCombo.Items.Add(list_faculties[i][1]);
            }
        }

        private void facultyCombo_Enter(object sender, EventArgs e)
        {
            this.groupCombo.Text = "";
        }

        private void groupCombo_Enter(object sender, EventArgs e)
        {
            this.groupCombo.Items.Clear();
            string faculty = facultyCombo.Text;

            for (int i = 0; i < data_groups.Count; ++i)
            {
                if (data_groups[i][1] == faculty)
                {
                    this.groupCombo.Items.Add(this.data_groups[i][3]);
                }
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void closeButton_MouseHover(object sender, EventArgs e)
        {
            this.closeButton.ForeColor = Color.Cyan;
        }

        private void closeButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.closeButton.ForeColor = Color.FromArgb(243, 0, 33);
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            this.closeButton.ForeColor = Color.FromArgb(239, 239, 239);
        }

        Point lastPoint;

        private void topLabelPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void topLabelPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void changeStudent_Click(object sender, EventArgs e)
        {
            String faculty_combo = this.facultyCombo.Text;
            String group_combo = this.groupCombo.Text;

            List<string> data = new List<string>() { this.nameStudent.Text, this.surnameStudent.Text, "", "" };

            if (data[0].Length > 1 && data[1].Length > 1
                && faculty_combo.Length > 10 && group_combo.Length > 3)
            {
                this.nameStudent.BackColor = Color.White;
                this.surnameStudent.BackColor = Color.White;
                this.facultyCombo.BackColor = Color.White;
                this.groupCombo.BackColor = Color.White;

                for (int i = 0; i < list_faculties.Count; ++i)
                {
                    if (list_faculties[i][1] == faculty_combo)
                    {
                        data[2] = list_faculties[i][0];
                        break;
                    }
                }

                for (int i = 0; i < data_groups.Count; ++i)
                {
                    if (data_groups[i][3] == group_combo)
                    {
                        data[3] = data_groups[i][2];
                        break;
                    }
                }

                StudentData db = new StudentData(connection);
                if (db.change(this.index, data))
                {
                    int count = data.Count - 1;
                    data[count] = group_combo;
                    --count;
                    data[count] = faculty_combo;
                    this.data = data;
                    change_result = true;
                }
            }

            if (data[1].Length > 1)
            {
                this.nameStudent.BackColor = Color.White;
            }

            if (data[2].Length > 1)
            {
                this.surnameStudent.BackColor = Color.White;
            }

            if (faculty_combo.Length > 10)
            {
                this.facultyCombo.BackColor = Color.White;
            }

            if (group_combo.Length > 3)
            {
                this.groupCombo.BackColor = Color.White;
            }

            if (data[0].Length < 2)
            {
                this.nameStudent.BackColor = Color.FromArgb(243, 0, 33);
            }

            if (data[1].Length < 2)
            {
                this.surnameStudent.BackColor = Color.FromArgb(243, 0, 33);
            }

            if (faculty_combo.Length <= 10)
            {
                this.facultyCombo.BackColor = Color.FromArgb(243, 0, 33);
            }

            if (group_combo.Length <= 2)
            {
                this.groupCombo.BackColor = Color.FromArgb(243, 0, 33);
            }
        }
    }
}
