using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DataUniversity.DataClasses;

namespace UniversityApp.Forms.Groups
{
    public partial class AddGroupForm : Form
    {
        private MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=itproger");
        public bool add_result = false;
        public List<string> data_result = new List<string>();

        public AddGroupForm()
        {
            InitializeComponent();
        }

        private void addGroup_Click(object sender, EventArgs e)
        {
            List<string> group_name = new List<string>();
            group_name.Add(this.nameFaculty.Text);

            if (group_name[0].Length > 4)
            {
                this.nameFaculty.BackColor = Color.White;

                GroupsData db = new GroupsData(connection);
                List<string[]> data_groups = db.getAllData();

                for (int i = 0; i < data_groups.Count(); ++i)
                {
                    if (data_groups[i][1] == group_name[0])
                    {
                        MessageBox.Show("Такая группа уже существует.");
                        break;
                    }

                    if (i == data_groups.Count() - 1)
                    {
                        if (db.add(group_name))
                        {
                            data_result.Add(group_name[0]);
                            add_result = true;
                        }
                    }
                }
            }

            if (group_name[0].Length > 4)
            {
                this.nameFaculty.BackColor = Color.White;
            }

            if (group_name[0].Length <= 4)
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
