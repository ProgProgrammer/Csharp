﻿using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;
using UniversityApp.Forms.Facylties;
using UniversityApp.Forms.FacyltiesGroups_form;
using UniversityApp.Forms.Groups;
using UniversityApp.Forms.Main_form;
using Model.ModelClasses;
using Controller.ControllerClasses;
using Controller.Interfaces;
using System.Xml;

namespace UniversityApp
{
    public partial class AuthorizationForm : Form
    {
        private MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=itproger");
        private static string empty_line = "";
        private string name_form = empty_line;

        public string users_line = "users";
        public string students_line = "student";
        public string faculties_groups_line = "faculties_groups";
        public string faculties_line = "faculties";
        public string groups_line = "groups";
        public AuthorizationForm()
        {
            InitializeComponent();

            this.passwordField.AutoSize = false;
            this.passwordField.Size = new System.Drawing.Size(246, 40);
        }
        public string NameForm
        {
            get { return name_form; }
            set { name_form = value; }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            if (name_form == empty_line)
            {
                Application.Exit();
            }
            else
            {
                this.Close();
            }
        }

        private void closeButton_MouseHover(object sender, EventArgs e)
        {
            this.closeButton.ForeColor = Color.Cyan;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            this.closeButton.ForeColor = Color.FromArgb(239, 239, 239);
        }

        private void closeButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.closeButton.ForeColor = Color.FromArgb(243, 0, 33);
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

        private void authorizationButton_Click(object sender, EventArgs e)
        {
            string login = this.loginField.Text;
            string password = this.passwordField.Text;

            if (login.Length > 2 && password.Length > 4)
            {
                this.loginField.BackColor = Color.White;
                this.passwordField.BackColor = Color.White;

                IControl db = new Controler(users_line);

                if (db.authorization(login, password))
                {
                    this.Hide();
                    int num = Application.OpenForms.Count;
                    Form form;

                    if (num > 1)
                    {
                        form = Application.OpenForms[num - 2];
                        form.Close();
                    }

                    if (name_form == users_line)
                    {
                        UsersForm usersForm = new UsersForm();
                        usersForm.Show();
                    }
                    else if (name_form == students_line)
                    {
                        StudentsForm studentsForm = new StudentsForm();
                        studentsForm.Show();
                    }
                    else if (name_form == faculties_groups_line)
                    {
                        FacultiesGroupsForm facyltiesGroupsForm = new FacultiesGroupsForm();
                        facyltiesGroupsForm.Show();
                    }
                    else if (name_form == faculties_line)
                    {
                        FacultiesForm facultiesForm = new FacultiesForm();
                        facultiesForm.Show();
                    }
                    else if (name_form == groups_line)
                    {
                        GroupsForm groupsForm = new GroupsForm();
                        groupsForm.Show();
                    }
                    else
                    {
                        MainForm mainForm = new MainForm();
                        mainForm.Show();
                    }
                }
            }

            if (login.Length > 2)
            {
                this.loginField.BackColor = Color.White;
            }

            if (password.Length > 4)
            {
                this.passwordField.BackColor = Color.White;
            }

            if (login.Length < 3)
            {
                this.loginField.BackColor = Color.FromArgb(243, 0, 33);
            }

            if (password.Length < 5)
            {
                this.passwordField.BackColor = Color.FromArgb(243, 0, 33);
            }
        }
    }
}
