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
using UniversityApp.Users_form;

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

        private void changeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserData db = new UserData(connection);

            if (db.checkAccess(2))
            {
                int index = dataGridView1.CurrentCell.RowIndex;             // номер строки
                int rows = dataGridView1.Rows.Count - 1;                    // запрос количества строк


                ChangeUserForm form = new ChangeUserForm();
                int num_column = dataGridView1.Columns.Count - 1;         // номер колонки

                if (rows > index)
                {
                    form.AccessFacultiesGroups = dataGridView1[num_column, index].Value.ToString();
                    --num_column;
                    form.AccessStudent = dataGridView1[num_column, index].Value.ToString();
                    --num_column;
                    form.AccessUser = dataGridView1[num_column, index].Value.ToString();
                    --num_column;
                    --num_column;
                    form.Surname = dataGridView1[num_column, index].Value.ToString();
                    --num_column;
                    form.Name = dataGridView1[num_column, index].Value.ToString();
                    --num_column;
                    form.Password = dataGridView1[num_column, index].Value.ToString();
                    --num_column;
                    form.Login = dataGridView1[num_column, index].Value.ToString();
                    form.index = dataGridView1[num_column, index].Value.ToString();
                    form.ShowDialog();

                    if (form.change_result)
                    {
                        List<string> data = form.data;
                        int column = data.Count + 1;
                        int count = data.Count - 1;

                        dataGridView1[column, index].Value = data[count];
                        --count;
                        --column;
                        dataGridView1[column, index].Value = data[count];
                        --count;
                        --column;
                        dataGridView1[column, index].Value = data[count];
                        --count;
                        --column;
                        dataGridView1[column, index].Value = "0";
                        --column;
                        dataGridView1[column, index].Value = data[count];
                        --count;
                        --column;
                        dataGridView1[column, index].Value = data[count];
                        --count;
                        --column;
                        dataGridView1[column, index].Value = data[count];
                    }
                }
                else
                {
                    MessageBox.Show("Вы применили изменение к пустой строке.");
                }
            }
            else
            {
                MessageBox.Show("Нет доступа к изменению пользователей.");
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserRemovalConfirmationForm form = new UserRemovalConfirmationForm();
            form.ShowDialog();

            if (form.result)
            {
                UserData db = new UserData(connection);

                if (db.checkAccess(3))
                {
                    int column = dataGridView1.CurrentCell.ColumnIndex;         // номер выделенной пользователем колонки
                    int index = dataGridView1.CurrentCell.RowIndex;             // номер выделенной пользователем строки
                    int rows = dataGridView1.Rows.Count - 1;                    // запрос количества строк

                    if (rows > index)
                    {
                        string id = dataGridView1[column, index].Value.ToString();  // логин

                        if (db.delete(id))                       // метод удаления пользователя из базы данных
                        {
                            dataGridView1.Rows.RemoveAt(index);       // удаление пользователя из таблицы
                        }
                        else
                        {
                            MessageBox.Show("Удаление не удалось.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Вы применили удаление к пустой строке.");
                    }
                }
                else
                {
                    MessageBox.Show("Нет доступа к удалению пользователей.");
                }
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
