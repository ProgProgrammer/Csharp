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
using UniversityApp.Forms.FacyltiesGroups_form;
using UniversityApp.Forms.Groups;

namespace UniversityApp.Forms.Main_form
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void studentsButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentsForm studentsForm = new StudentsForm();
            studentsForm.Show();
        }

        private void usersButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            UsersForm usersForm = new UsersForm();
            usersForm.Show();
        }

        private void facyltiesGroupsButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            FacyltiesGroupsForm facyltiesGroupsForm = new FacyltiesGroupsForm();
            facyltiesGroupsForm.Show();
        }

        private void facyltiesButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            FacyltiesForm form = new FacyltiesForm();
            form.Show();
        }

        private void groupsButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            GroupsForm form = new GroupsForm();
            form.Show();
        }
    }
}
