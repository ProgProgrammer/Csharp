using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Model.ModelClasses;

namespace UniversityApp.Forms.Groups
{
    public partial class ChangeGroupForm : Form
    {
        private MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=itproger");
        private string id_group;
        public List<string> data_result = new List<string>();
        public bool change_result = false;

        public ChangeGroupForm()
        {
            InitializeComponent();
        }

        public string IdGroup         // для установки значений в текстовое поле
        {
            get { return id_group; }
            set { id_group = value; }
        }

        public string NameGroup         // для установки значений в текстовое поле
        {
            get { return nameGroup.Text; }
            set { nameGroup.Text = value; }
        }

        private void changeGroup_Click(object sender, EventArgs e)
        {
            List<string> name_group = new List<string>() { nameGroup.Text };

            if (name_group[0].Length > 4)
            {
                this.nameGroup.BackColor = Color.White;

                GroupsData db = new GroupsData(connection);
                List<string[]> data_faculties = db.getAllData();

                for (int i = 0; i < data_faculties.Count(); ++i)
                {
                    if (data_faculties[i][1] == name_group[0])
                    {
                        MessageBox.Show("Такая группа уже существует.");
                        break;
                    }

                    if (i == data_faculties.Count() - 1)
                    {
                        if (db.change(id_group, name_group))
                        {
                            data_result.Add(name_group[0]);
                            change_result = true;
                        }
                    }
                }
            }

            if (name_group[0].Length > 4)
            {
                this.nameGroup.BackColor = Color.White;
            }

            if (name_group[0].Length <= 4)
            {
                this.nameGroup.BackColor = Color.FromArgb(243, 0, 33);
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
