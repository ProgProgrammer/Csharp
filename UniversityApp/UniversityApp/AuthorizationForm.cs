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

namespace UniversityApp
{
    public partial class AuthorizationForm : Form
    {
        private MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=itproger");
        private bool close_button = true;
        public AuthorizationForm()
        {
            InitializeComponent();

            this.passwordField.AutoSize = false;
            this.passwordField.Size = new System.Drawing.Size(246, 40);
        }
        public bool CloseButton
        {
            get { return close_button; }
            set { close_button = value; }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            if (close_button)
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

                UserData db = new UserData(connection);

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

                    StudentsForm studentsForm = new StudentsForm();
                    studentsForm.Show();
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
