using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversityApp
{
    public partial class StudentsForm : Form
    {
        private MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=itproger");

        public StudentsForm()
        {
            InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            StudentData db_student = new StudentData(connection);
            List<string[]> data_students = db_student.getAllData();

            FacyltiesGroupsData db_fac_gr = new FacyltiesGroupsData(connection);
            List<string[]> data_faculty_groups = db_fac_gr.getAllData();
            List<string[]> data = new List<string[]>();

            for (int i = 0; i < data_students.Count; ++i)
            {
                data.Add(new string[5]);

                for (int a = 0; a < data[i].Length; ++a)
                {
                    data[i][a] = data_students[i][a];
                }
            }

            for (int i = 0; i < data.Count; ++i)
            {
                for (int a = 0; a < data_faculty_groups.Count; ++a)
                {
                    if (data[i][3] == data_faculty_groups[a][0])
                    {
                        data[i][3] = data_faculty_groups[a][1];
                    }

                    if (data[i][4] == data_faculty_groups[a][2])
                    {
                        data[i][4] = data_faculty_groups[a][3];
                    }
                }
            }

            foreach (string[] s in data)
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void changeUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AuthorizationForm form = new AuthorizationForm();
            form.NameForm = form.students_line;  // не закрывать приложение при закрытии окна авторизации
            form.ShowDialog();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentData db = new StudentData(connection);

            if (db.checkAccess(1))
            {
                AddStudentForm form = new AddStudentForm();
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
                MessageBox.Show("Нет доступа к добавлению студентов.");
            }
        }

        private void changeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentData db = new StudentData(connection);

            if (db.checkAccess(2))
            {
                int index = dataGridView1.CurrentCell.RowIndex;             // номер строки
                int rows = dataGridView1.Rows.Count - 1;                    // запрос количества строк


                ChangeStudentForm form = new ChangeStudentForm();
                int num_column = dataGridView1.Columns.Count - 1;         // номер колонки

                if (rows > index)
                {
                    form.GroupCombo = dataGridView1[num_column, index].Value.ToString();
                    --num_column;
                    form.FacultyStudent = dataGridView1[num_column, index].Value.ToString();
                    --num_column;
                    form.SurnameStudent = dataGridView1[num_column, index].Value.ToString();
                    --num_column;
                    form.NameStudent = dataGridView1[num_column, index].Value.ToString();
                    --num_column;
                    form.StudentID = dataGridView1[num_column, index].Value.ToString();
                    form.index = dataGridView1[num_column, index].Value.ToString();
                    form.ShowDialog();

                    if (form.change_result)
                    {
                        List<string> data = form.data;
                        int column = data.Count;
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
                MessageBox.Show("Нет доступа к изменению студентов.");
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentRemovalConfirmationForm form = new StudentRemovalConfirmationForm();
            form.ShowDialog();

            if (form.result)
            {
                StudentData db = new StudentData(connection);

                if (db.checkAccess(3))
                {
                    int column = dataGridView1.CurrentCell.ColumnIndex;         // номер выделенной пользователем колонки
                    int index = dataGridView1.CurrentCell.RowIndex;             // номер выделенной пользователем строки
                    int rows = dataGridView1.Rows.Count - 1;                    // запрос количества строк

                    if (rows > index)
                    {
                        string id = dataGridView1[column, index].Value.ToString();  // номер студенческого билета

                        StudentData stud_db = new StudentData(connection);

                        if (stud_db.delete(id))                       // метод удаления студента из базы данных
                        {
                            dataGridView1.Rows.RemoveAt(index);       // удаление студента из таблицы
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
                    MessageBox.Show("Нет доступа к удалению студентов.");
                }
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rows_count = dataGridView1.Rows.Count - 2;

            for (int i = rows_count; i >= 0; --i)
            {
                dataGridView1.Rows.RemoveAt(i);
            }

            loadData();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsersForm form = new UsersForm();
            this.Close();
            form.Show();
        }

        private void aboutProgram_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа создана Андреевым Владимиром Александровичем, студентом группы ВМ-20, ВолгГТУ. 2023 год.");
        }
    }
}
