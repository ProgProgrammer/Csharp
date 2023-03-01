using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Model.ModelClasses;
using Controller.ControllerClasses;
using Controller.Interfaces;

namespace UniversityApp
{
    public partial class AddUserForm : Form
    {
        public bool add_result = false;
        public List<string[]> data_result = new List<string[]>();
        private const string name_table = "users";
        private IControl db = new Controler(name_table);

        public AddUserForm()
        {
            InitializeComponent();
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

        private void addUser_Click(object sender, EventArgs e)
        {
            List<string> data = new List<string>() { this.login.Text, this.password.Text, this.name.Text, this.surname.Text, "0", 
                                                    this.accessUser.Text, this.accessStudent.Text, this.accessFacultiesGroups.Text };

            if (this.login.Text.Length > 2 && this.password.Text.Length > 4
                && this.name.Text.Length > 1 && this.surname.Text.Length > 2
                && this.accessUser.Text.Length == 4 && this.accessStudent.Text.Length == 4 
                && this.accessFacultiesGroups.Text.Length == 4)
            {
                this.login.BackColor = Color.White;
                this.password.BackColor = Color.White;
                this.name.BackColor = Color.White;
                this.surname.BackColor = Color.White;
                this.accessUser.BackColor = Color.White;
                this.accessStudent.BackColor = Color.White;
                this.accessFacultiesGroups.BackColor = Color.White;

                if (db.add(data))
                {
                    int count = data.Count - 1;
                    this.data_result.Add(new string[data.Count]);
                    int count_result = data_result.Count - 1;

                    for (int i = 0; i <= count; ++i)
                    {
                        this.data_result[count_result][i] = data[i];
                    }

                    add_result = true;
                }
            }


            if (this.login.Text.Length > 2)
            {
                this.login.BackColor = Color.White;
            }

            if (this.password.Text.Length > 4)
            {
                this.password.BackColor = Color.White;
            }

            if (this.name.Text.Length > 1)
            {
                this.name.BackColor = Color.White;
            }

            if (this.surname.Text.Length > 2)
            {
                this.surname.BackColor = Color.White;
            }

            if (this.accessUser.Text.Length == 4)
            {
                this.accessUser.BackColor = Color.White;
            }

            if (this.accessStudent.Text.Length == 4)
            {
                this.accessStudent.BackColor = Color.White;
            }

            if (this.accessFacultiesGroups.Text.Length == 4)
            {
                this.accessFacultiesGroups.BackColor = Color.White;
            }


            if (this.login.Text.Length < 3)
            {
                this.login.BackColor = Color.FromArgb(243, 0, 33);
            }

            if (this.password.Text.Length < 5)
            {
                this.password.BackColor = Color.FromArgb(243, 0, 33);
            }

            if (this.name.Text.Length < 2)
            {
                this.name.BackColor = Color.FromArgb(243, 0, 33);
            }

            if (this.surname.Text.Length < 3)
            {
                this.surname.BackColor = Color.FromArgb(243, 0, 33);
            }

            if (this.accessUser.Text.Length != 4)
            {
                this.accessUser.BackColor = Color.FromArgb(243, 0, 33);
            }

            if (this.accessStudent.Text.Length != 4)
            {
                this.accessStudent.BackColor = Color.FromArgb(243, 0, 33);
            }

            if (this.accessFacultiesGroups.Text.Length != 4)
            {
                this.accessFacultiesGroups.BackColor = Color.FromArgb(243, 0, 33);
            }
        }
    }
}
