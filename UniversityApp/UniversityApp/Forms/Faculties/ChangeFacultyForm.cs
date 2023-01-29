using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversityApp.Forms.Facylties;

namespace UniversityApp.Forms.Faculties
{
    public partial class ChangeFacultyForm : Form
    {
        private MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=itproger");
        private string id_faculty;
        public List<string> data_result = new List<string>();
        public bool change_result = false;

        public ChangeFacultyForm()
        {
            InitializeComponent();
        }

        public string IdFaculty         // для установки значений в текстовое поле
        {
            get { return id_faculty; }
            set { id_faculty = value; }
        }

        public string NameFaculty         // для установки значений в текстовое поле
        {
            get { return nameFaculty.Text; }
            set { nameFaculty.Text = value; }
        }

        private void changeFaculty_Click(object sender, EventArgs e)
        {
            List<string> name_faculty = new List<string>() { nameFaculty.Text };

            if (name_faculty[0].Length > 12)
            {
                this.nameFaculty.BackColor = Color.White;

                FacultiesData db = new FacultiesData(connection);
                List<string[]> data_faculties = db.getAllData();

                for (int i = 0; i < data_faculties.Count(); ++i)
                {
                    if (data_faculties[i][1] == name_faculty[0])
                    {
                        MessageBox.Show("Такой факультет уже существует.");
                        break;
                    }

                    if (i == data_faculties.Count() - 1)
                    {
                        if (db.change(id_faculty, name_faculty))
                        {
                            data_result.Add(name_faculty[0]);
                            change_result = true;
                        }
                    }
                }
            }

            if (name_faculty[0].Length > 12)
            {
                this.nameFaculty.BackColor = Color.White;
            }

            if (name_faculty[0].Length <= 12)
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
