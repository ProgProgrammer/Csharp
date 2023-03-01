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
    public partial class ChangeUserForm : Form
    {
        public string index;
        public bool change_result = false;
        public List<string> data = new List<string>();
        private const string name_table = "users";
        private IControl db = new Controler(name_table);

        public ChangeUserForm()
        {
            InitializeComponent();
            this.login.ReadOnly = true;
        }

        public string Login         // для установки значений в текстовые поля
        {
            get { return login.Text; }
            set { login.Text = value; }
        }

        public string Password         // для установки значений в текстовые поля
        {
            get { return password.Text; }
            set { password.Text = value; }
        }

        public string Name         // для установки значений в текстовые поля
        {
            get { return name.Text; }
            set { name.Text = value; }
        }

        public string Surname         // для установки значений в текстовые поля
        {
            get { return surname.Text; }
            set { surname.Text = value; }
        }

        public string AccessUser         // для установки значений в текстовые поля
        {
            get { return accessUser.Text; }
            set { accessUser.Text = value; }
        }

        public string AccessStudent         // для установки значений в текстовые поля
        {
            get { return accessStudent.Text; }
            set { accessStudent.Text = value; }
        }

        public string AccessFacultiesGroups         // для установки значений в текстовые поля
        {
            get { return accessFacultiesGroups.Text; }
            set { accessFacultiesGroups.Text = value; }
        }

        private void changeUser_Click(object sender, EventArgs e)
        {
            List<string> data = new List<string>() { this.password.Text, this.name.Text, this.surname.Text, this.accessUser.Text,
                                                    this.accessStudent.Text, this.accessFacultiesGroups.Text };

            if (this.password.Text.Length > 4 && this.name.Text.Length > 1
                && this.surname.Text.Length > 2 && this.accessUser.Text.Length == 4
                && this.accessStudent.Text.Length == 4 && this.accessFacultiesGroups.Text.Length == 4)
            {
                this.password.BackColor = Color.White;
                this.name.BackColor = Color.White;
                this.surname.BackColor = Color.White;
                this.accessUser.BackColor = Color.White;
                this.accessStudent.BackColor = Color.White;
                this.accessFacultiesGroups.BackColor = Color.White;

                if (db.change(this.index, data))
                {
                    this.data = data;
                    change_result = true;
                }
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
