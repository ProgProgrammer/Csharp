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
    public partial class UsersForm : Form
    {
        private MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=itproger");

        public UsersForm()
        {
            InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            UserData db_users = new UserData(connection);
            List<string[]> data_users = db_users.getAllData();

            foreach (string[] s in data_users)
            {
                dataGridView1.Rows.Add(s);
            }
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

        private void changeUserToolStripMenuItem_Click(object sender, EventArgs e)  // открытие формы авторизации
        {
            AuthorizationForm form = new AuthorizationForm();
            form.NameForm = form.users_line;  // не закрывать приложение при закрытии окна авторизации
            form.ShowDialog();
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)    // открытие формы студентов
        {
            StudentsForm form = new StudentsForm();
            this.Close();
            form.Show();
        }

        private void aboutProgram_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа создана Андреевым Владимиром Александровичем, студентом группы ВМ-20, ВолгГТУ. 2023 год.");
        }

        private void addUser_Click(object sender, EventArgs e)
        {
            UserData db = new UserData(connection);

            if (db.checkAccess(1))
            {
                AddUserForm form = new AddUserForm();
                form.ShowDialog();

                if (form.add_result)
                {
                    List<string[]> data = form.data_result;

                    foreach (string[] s in data)
                    {
                        dataGridView1.Rows.Add(s);
                    }
                }
            }
            else
            {
                MessageBox.Show("Нет доступа к добавлению пользователей.");
            }
        }

        private void updateUsers_Click(object sender, EventArgs e)
        {
            int rows_count = dataGridView1.Rows.Count - 2;

            for (int i = rows_count; i >= 0; --i)
            {
                dataGridView1.Rows.RemoveAt(i);
            }

            loadData();
        }
    }
}
