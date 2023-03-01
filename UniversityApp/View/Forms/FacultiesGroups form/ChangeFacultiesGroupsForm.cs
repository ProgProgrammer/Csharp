using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Model.ModelClasses;
using Controller.ControllerClasses;
using Controller.Interfaces;

namespace UniversityApp.Forms.FacultiesGroups_form
{
    public partial class ChangeFacultiesGroupsForm : Form
    {
        private MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=itproger");
        private List<string[]> data_faculties = new List<string[]>();
        private List<string[]> data_groups = new List<string[]>();
        private List<string[]> data_faculties_groups = new List<string[]>();
        private string faculties = "faculties";
        private string faculties_groups = "faculties_groups";
        private string groups = "groups";
        private string index;
        public List<string[]> data_result = new List<string[]>();
        public bool change_result = false;
        public List<string> data;

        public ChangeFacultiesGroupsForm()
        {
            InitializeComponent();
            loadData();
        }

        public string FacultyGroupId  // для установки значений в текстовые поля
        {
            get { return index; }
            set { index = value; }
        }

        public string FacultyCombo  // для установки значений в текстовые поля
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
            IControl db_faculties = new Controler(faculties);
            data_faculties = db_faculties.getAllData();

            IControl db_groups = new Controler(groups);
            data_groups = db_groups.getAllData();

            IControl db_faculties_groups = new Controler(faculties_groups);
            data_faculties_groups = db_faculties_groups.getAllData();

            for (int i = 0; i < data_faculties_groups.Count(); ++i)
            {
                for (int a = 0; a < data_groups.Count(); ++a)
                {
                    if (data_faculties_groups[i][2] == data_groups[a][1])
                    {
                        data_groups.RemoveAt(a);
                    }
                }
            }

            for (int i = 0; i < data_faculties.Count(); ++i)
            {
                facultyCombo.Items.Add(data_faculties[i][1]);
            }

            for (int i = 0; i < data_groups.Count(); ++i)
            {
                groupCombo.Items.Add(data_groups[i][1]);
            }
        }

        private void changeFacultiesGroups_Click(object sender, EventArgs e)
        {
            String faculty_combo = this.facultyCombo.Text;
            String group_combo = this.groupCombo.Text;

            if (faculty_combo.Length > 1 && group_combo.Length > 1)
            {
                List<string> data = new List<string>();

                for (int i = 0; i < data_faculties.Count(); ++i)
                {
                    if (faculty_combo == data_faculties[i][1])
                    {
                        data.Add(data_faculties[i][0]);
                    }
                }

                for (int i = 0; i < data_groups.Count(); ++i)
                {
                    if (group_combo == data_groups[i][1])
                    {
                        data.Add(data_groups[i][0]);
                    }
                }

                this.facultyCombo.BackColor = Color.White;
                this.groupCombo.BackColor = Color.White;

                IControl db = new Controler(faculties_groups);

                if (db.change(index, data))
                {
                    List<string> data_fg = new List<string>();
                    data_fg.Add(faculty_combo);
                    data_fg.Add(group_combo);
                    this.data = data_fg;
                    change_result = true;
                    facultyCombo.Items.Clear(); // очищаем текстовые боксы с выбором факультетов
                    groupCombo.Items.Clear();   // очищаем текстовые боксы с выбором групп
                    loadData();
                }
            }


            if (faculty_combo.Length > 1)
            {
                this.facultyCombo.BackColor = Color.White;
            }

            if (group_combo.Length > 1)
            {
                this.groupCombo.BackColor = Color.White;
            }


            if (faculty_combo.Length < 1)
            {
                this.facultyCombo.BackColor = Color.FromArgb(243, 0, 33);
            }

            if (group_combo.Length < 1)
            {
                this.groupCombo.BackColor = Color.FromArgb(243, 0, 33);
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
