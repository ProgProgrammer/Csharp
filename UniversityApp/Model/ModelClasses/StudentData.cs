using MySql.Data.MySqlClient;
using Model.Interface;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System;

namespace Model.ModelClasses
{
    public class StudentData : ADataBase
    {
        private const string name_table = "students";
        private const string access_column = "access_student";

        public StudentData()
        {
            access_column_abs_class = access_column;
        }

        public bool checkStudent(List<string> data)  // проверка студента на его присутсвие/отсутсвие в БД по номеру зачетки
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand($"SELECT * FROM `{name_table}` WHERE student_number = @student_number", connection);
            command.Parameters.Add("@student_number", MySqlDbType.VarChar).Value = data[0];

            if (userExistCheck(table, adapter, command))
            {
                return false;
            }

            return true;
        }

        public List<string[]> getFacultiesGroupsData()  // предоставляет список из факультетов и групп таблицы "faculties_groups" (проверки нет для уменьшения нагрузки на БД)
        {
            MySqlCommand command_groups_num = new MySqlCommand("SELECT COUNT(*) FROM groups", connection);

            openConnection();
            int numRowsGroups = Convert.ToInt32(command_groups_num.ExecuteScalar());
            closeConnection();

            List<string[]> data = new List<string[]>();
            MySqlCommand command = new MySqlCommand("SELECT faculties.id, faculties.name, groups.id, groups.name FROM faculties_groups " +
                "JOIN faculties ON faculties_groups.num_faculty = faculties.id JOIN groups ON faculties_groups.num_group = groups.id", connection);

            openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            int num_cell_data = reader.FieldCount;

            for (int i = 0; i < numRowsGroups; ++i)
            {
                if (reader.Read())
                {
                    data.Add(new string[num_cell_data]);

                    for (int a = 0; a < num_cell_data; ++a)
                    {
                        data[data.Count - 1][a] = reader[a].ToString();
                    }
                }
            }

            reader.Close();
            closeConnection();

            return data;
        }

        public override bool userAccessCheck(string login, int id)
        {
            return accessCheck(login, id);
        }

        public override bool authorizationCheck(string login, string password)
        {
            return authorization(login, password);
        }

        public override List<string[]> getAllData()
        {
            MySqlCommand command = new MySqlCommand($"SELECT students.id, students.student_number, students.name, students.surname, faculties.name, groups.name " +
                $"FROM `{name_table}` JOIN faculties ON students.num_faculty = faculties.id JOIN groups ON students.num_group = groups.id", this.connection);
            List<string[]> data_students = new List<string[]>();

            openConnection();

            MySqlDataReader reader = command.ExecuteReader();
            int num_cell_data = reader.FieldCount - 1;

            while (reader.Read())
            {
                data_students.Add(new string[num_cell_data]);

                for (int i = 0; i < num_cell_data; ++i)
                {
                    data_students[data_students.Count - 1][i] = reader[i + 1].ToString();
                }
            }

            reader.Close();
            closeConnection();

            return data_students;
        }

        public override bool add(List<string> data)
        {
            MySqlCommand command = new MySqlCommand($"INSERT INTO `{name_table}`(student_number, name, surname, num_faculty, num_group) " +
                $"VALUES(@student_number, @name, @surname, @num_faculty, @num_group)", connection);
            command.Parameters.Add("@student_number", MySqlDbType.VarChar).Value = data[0];
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = data[1];
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = data[2];
            command.Parameters.Add("@num_faculty", MySqlDbType.VarChar).Value = data[3];
            command.Parameters.Add("@num_group", MySqlDbType.VarChar).Value = data[4];

            openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            else
            {
                closeConnection();
                return false;
            }
        }

        public override bool change(string index, List<string> data)   // изменение данных о студенте
        {
            MySqlCommand command = new MySqlCommand($"UPDATE `{name_table}` SET name = @name, surname = @surname, num_faculty = @num_faculty, num_group = @num_group " +
                $"WHERE student_number=@index", connection);
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = data[0];
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = data[1];
            command.Parameters.Add("@num_faculty", MySqlDbType.VarChar).Value = data[2];
            command.Parameters.Add("@num_group", MySqlDbType.VarChar).Value = data[3];
            command.Parameters.Add("@index", MySqlDbType.VarChar).Value = index;

            openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            else
            {
                closeConnection();
                return false;
            }
        }
        public override bool delete(string index)
        {
            MySqlCommand command = new MySqlCommand($"DELETE FROM `{name_table}` WHERE student_number = @student_id", connection);
            command.Parameters.Add("@student_id", MySqlDbType.VarChar).Value = index;

            openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            else
            {
                closeConnection();
                return false;
            }
        }
    }
}
