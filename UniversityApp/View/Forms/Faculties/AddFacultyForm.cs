using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Model.ModelClasses;
using Controller.ControllerClasses;
using Controller.Interfaces;
using System.Xml;

namespace UniversityApp.Forms.Faculties
{
    public partial class AddFacultyForm : Form
    {
        private MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=itproger");
        public bool add_result = false;
        public List<string> data_result = new List<string>();
        private const string name_table = "faculties";

        public AddFacultyForm()
        {
            InitializeComponent();
        }

        private void addFaculty_Click(object sender, EventArgs e)
        {
            List<string> faculty_name = new List<string>();
            faculty_name.Add(this.nameFaculty.Text);

            if (faculty_name[0].Length > 12)
            {
                this.nameFaculty.BackColor = Color.White;

                IControl db_faculty = new Controler(name_table);
                List<string[]> data_faculties = db_faculty.getAllData();

                for (int i = 0; i < data_faculties.Count(); ++i)
                {
                    if (data_faculties[i][1] == faculty_name[0])
                    {
                        MessageBox.Show("Такой факультет уже существует.");
                        break;
                    }

                    if (i == data_faculties.Count() - 1)
                    {
                        if (db_faculty.add(faculty_name))
                        {
                            data_result.Add(faculty_name[0]);
                            add_result = true;
                        }
                    }
                }
            }

            if (faculty_name[0].Length > 12)
            {
                this.nameFaculty.BackColor = Color.White;
            }

            if (faculty_name[0].Length <= 12)
            {
                this.nameFaculty.BackColor = Color.FromArgb(243, 0, 33);
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
