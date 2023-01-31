using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UniversityApp.Forms.Faculties;
using UniversityApp.Forms.FacyltiesGroups_form;
using UniversityApp.Forms.Groups;
using DataUniversity.DataClasses;

namespace UniversityApp.Forms.Facylties
{
    public partial class FacultiesForm : Form
    {
        private MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=itproger");
        List<string[]> data_faculties = new List<string[]>();

        public FacultiesForm()
        {
            InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            FacultiesData db_faculty = new FacultiesData(connection);
            data_faculties = db_faculty.getAllData();

            for (int i = 0; i < data_faculties.Count(); ++i)
            {
                dataGridView1.Rows.Add(data_faculties[i][1]);
            }
        }

        private void addFaculty_Click(object sender, EventArgs e)
        {
            UserData db = new UserData(connection);

            if (db.checkAccess(1))
            {
                AddFacultyForm form = new AddFacultyForm();
                form.ShowDialog();

                if (form.add_result)
                {
                    List<string> data = form.data_result;

                    foreach (string s in data)
                    {
                        dataGridView1.Rows.Add(s);
                    }

                    FacultiesData db_faculty = new FacultiesData(connection);
                    data_faculties = db_faculty.getAllData();
                }
            }
            else
            {
                MessageBox.Show("Нет прав доступа на добавление факультетов.");
            }
        }

        private void changeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserData db = new UserData(connection);

            if (db.checkAccess(2))
            {
                int index = dataGridView1.CurrentCell.RowIndex;             // номер строки
                int rows = dataGridView1.Rows.Count - 1;                    // запрос количества строк

                if (rows > index)
                {
                    ChangeFacultyForm form = new ChangeFacultyForm();
                    int num_column = dataGridView1.Columns.Count - 1;
                    form.NameFaculty = dataGridView1[num_column, index].Value.ToString();

                    for (int i = 0; i < data_faculties.Count(); ++i)
                    {
                        if (data_faculties[i][1] == form.NameFaculty)
                        {
                            form.IdFaculty = data_faculties[i][0];
                        }
                    }

                    form.ShowDialog();

                    if (form.change_result)
                    {
                        List<string> data = form.data_result;
                        dataGridView1[0, index].Value = data[0];

                        FacultiesData db_faculty = new FacultiesData(connection);
                        data_faculties = db_faculty.getAllData();
                    }
                }
                else
                {
                    MessageBox.Show("Вы применили изменение к пустой строке.");
                }
            }
            else
            {
                MessageBox.Show("Нет прав доступа на изменение факультетов.");
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FacultyRemovalConfirmationForm form = new FacultyRemovalConfirmationForm();
            form.ShowDialog();

            if (form.result)
            {
                int index = dataGridView1.CurrentCell.RowIndex;                  // номер выделенной пользователем строки
                int rows = dataGridView1.Rows.Count - 1;                         // запрос количества строк

                if (rows > index)
                {
                    FacultiesData db = new FacultiesData(connection);
                    string faculty_name = dataGridView1[0, index].Value.ToString();  // название факультета

                    if (db.checkAccess(3))
                    {
                        string id = "";

                        for (int i = 0; i < data_faculties.Count(); ++i)
                        {
                            if (faculty_name == data_faculties[i][1])
                            {
                                id = data_faculties[i][0];
                                break;
                            }
                        }

                        if (db.delete(id))                            // метод удаления факультета из базы данных
                        {
                            dataGridView1.Rows.RemoveAt(index);       // удаление факультета из таблицы
                        }
                        else
                        {
                            MessageBox.Show("Удаление не удалось.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Нет прав доступа на удаление факультетов.");
                    }
                }
                else
                {
                    MessageBox.Show("Вы применили удаление к пустой строке.");
                }
            }
        }

        private void updateFaculties_Click(object sender, EventArgs e)
        {
            int rows_count = dataGridView1.Rows.Count - 2;

            for (int i = rows_count; i >= 0; --i)
            {
                dataGridView1.Rows.RemoveAt(i);
            }

            loadData();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void changeUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AuthorizationForm form = new AuthorizationForm();
            form.NameForm = form.faculties_line;  // не закрывать приложение при закрытии окна авторизации
            form.ShowDialog();
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentsForm form = new StudentsForm();
            this.Close();
            form.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsersForm form = new UsersForm();
            this.Close();
            form.Show();
        }

        private void facultiesAndGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FacultiesGroupsForm form = new FacultiesGroupsForm();
            this.Close();
            form.Show();
        }

        private void groupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GroupsForm form = new GroupsForm();
            this.Close();
            form.Show();
        }

        private void aboutProgram_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа создана Андреевым Владимиром Александровичем, студентом группы ВМ-20, ВолгГТУ. 2023 год.");
        }
    }
}
