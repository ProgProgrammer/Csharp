using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MySql.Data.MySqlClient;

namespace UniversityApp
{
    public partial class AddStudentForm : Form
    {
        private List<string[]> list_faculties = new List<string[]>();
        private List<string[]> data_groups;
        private MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=itproger");
        public bool add_result = false;
        public List<string[]> data_result = new List<string[]>();

        public AddStudentForm()
        {
            InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            StudentData db = new StudentData(connection);
            data_groups = db.getFGData();

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
                facultyCombo.Items.Add(list_faculties[i][1]);
            }
        }

        private void addStudent_Click(object sender, EventArgs e)
        {
            String faculty_combo = this.facultyCombo.Text;
            String group_combo = this.groupCombo.Text;

            List<string> data = new List<string>() { this.numberStudent.Text, this.nameStudent.Text, this.surnameStudent.Text, "", "" };

            if (data[0].Length >= 8 && data[1].Length > 1
                && data[2].Length > 1 && faculty_combo.Length > 10
                && group_combo.Length > 3)
            {
                this.numberStudent.BackColor = Color.White;
                this.nameStudent.BackColor = Color.White;
                this.surnameStudent.BackColor = Color.White;
                this.facultyCombo.BackColor = Color.White;
                this.groupCombo.BackColor = Color.White;

                for (int i = 0; i < list_faculties.Count; ++i)
                {
                    if (list_faculties[i][1] == faculty_combo)
                    {
                        data[3] = list_faculties[i][0];
                        break;
                    }
                }

                for (int i = 0; i < data_groups.Count; ++i)
                {
                    if (data_groups[i][3] == group_combo)
                    {
                        data[4] = data_groups[i][2];
                        break;
                    }
                }

                StudentData db = new StudentData(connection);
                if (db.add(data))
                {
                    int count = data.Count - 1;
                    this.data_result.Add(new string[data.Count]);
                    int count_result = data_result.Count - 1;
                    data[count] = group_combo;
                    data[count - 1] = faculty_combo;

                    for (int i = 0; i <= count; ++i)
                    {
                        this.data_result[count_result][i] = data[i];
                    }

                    add_result = true;
                }
            }


            if (data[0].Length >= 8)
            {
                this.numberStudent.BackColor = Color.White;
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


            if (data[0].Length < 8)
            {
                this.numberStudent.BackColor = Color.FromArgb(243, 0, 33);
            }

            if (data[1].Length < 2)
            {
                this.nameStudent.BackColor = Color.FromArgb(243, 0, 33);
            }

            if (data[2].Length < 2)
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
    }
}
