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
using UniversityApp.Forms.Facylties;
using UniversityApp.Forms.Groups;
using UniversityApp.Users_form;

namespace UniversityApp.Forms.FacyltiesGroups_form
{
    public partial class FacultiesGroupsForm : Form
    {
        private MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=itproger");
        private List<string[]> data_faculty_groups;

        public FacultiesGroupsForm()
        {
            InitializeComponent();
            loadData();
        }
        private void loadData()
        {
            FacultiesGroupsData db_fac_gr = new FacultiesGroupsData(connection);
            data_faculty_groups = db_fac_gr.getAllData();
            List<string[]> data = new List<string[]>();

            for (int i = 0; i < data_faculty_groups.Count; ++i)
            {
                data.Add(new string[2]);

                for (int a = 0; a < data[i].Length; ++a)
                {
                    data[i][a] = data_faculty_groups[i][a + 1];
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

        private void changeUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AuthorizationForm form = new AuthorizationForm();
            form.NameForm = form.facylties_groups_line;  // не закрывать приложение при закрытии окна авторизации
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

        private void facultiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FacultiesForm form = new FacultiesForm();
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

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FacultiesGroupsRemovalConfirmationForm form = new FacultiesGroupsRemovalConfirmationForm();
            form.ShowDialog();

            if (form.result)
            {
                int index = dataGridView1.CurrentCell.RowIndex;             // номер выделенной пользователем строки
                int rows = dataGridView1.Rows.Count - 1;                    // запрос количества строк

                if (rows > index)
                {
                    FacultiesGroupsData db = new FacultiesGroupsData(connection);

                    if (db.checkAccess(3))
                    {
                        string id = data_faculty_groups[index][0];  // id

                        if (db.delete(id))                            // метод удаления пользователя из базы данных
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
                        MessageBox.Show("Нет доступа к удалению связи.");
                    }
                }
                else
                {
                    MessageBox.Show("Вы применили удаление к пустой строке.");
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
