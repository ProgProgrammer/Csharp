﻿using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversityApp
{
    internal class StudentData : ADataBase
    {
        private const string name_table = "students";
        private const string access_column = "access_student";

        private bool checkStudent(List<string> data)
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand($"SELECT * FROM `{name_table}` WHERE student_number = @student_number", connection);
            command.Parameters.Add("@student_number", MySqlDbType.VarChar).Value = data[0];

            if (userExistCheck(table, adapter, command))
            {
                MessageBox.Show("Студент с таким номером студенческого билета уже существует в базе данных.");

                return false;
            }

            return true;
        }

        public StudentData(MySqlConnection connection) : base(connection)
        {
            access_column_abs_class = access_column;
        }

        public List<string[]> getFGData()  // метод для проверки доступа перед запросом информации о факультетах и группах в БД
        {
            UserData db = new UserData(connection);

            if (readFile())
            {
                if (db.authorization(login, password))
                {
                    if (accessCheck(login, 0))
                    {
                        return getFacultiesGroupsData();
                    }
                }
            }

            return new List<string[]>();
        }

        public List<string[]> getAllData()
        {
            UserData db = new UserData(connection);

            if (readFile())
            {
                if (db.authorization(login, password))
                {
                    if (accessCheck(login, 0))
                    {
                        MySqlCommand command = new MySqlCommand($"SELECT * FROM `{name_table}` ORDER BY id", this.connection);
                        List<string[]> data_students = new List<string[]>();
                        List<string[]> data = new List<string[]>();
                        List<string[]> data_faculty_groups = getFacultiesGroupsData();

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

                        return data;
                    }
                    else
                    {
                        MessageBox.Show("Нет прав доступа на чтение.");

                        return new List<string[]>();
                    }
                }
            }

            return new List<string[]>();
        }

        public override bool add(List<string> data)
        {
            UserData db = new UserData(connection);

            if (readFile())
            {
                if (db.authorization(login, password))
                {
                    if (accessCheck(login, 1))
                    {
                        if (checkStudent(data))
                        {
                            List<string[]> list_faculties_groups = getFacultiesGroupsData();

                            for (int i = 0; i < list_faculties_groups.Count; ++i)
                            {
                                if (list_faculties_groups[i][0] == data[3]
                                    && list_faculties_groups[i][2] == data[4])  // проверка на то, есть ли переданная группа в переданном факультете или нет
                                {
                                    MySqlCommand command = new MySqlCommand($"INSERT INTO `{name_table}`(student_number, name, surname, num_faculty, num_group) VALUES(@student_number, @name, @surname, @num_faculty, @num_group)", connection);
                                    command.Parameters.Add("@student_number", MySqlDbType.VarChar).Value = data[0];
                                    command.Parameters.Add("@name", MySqlDbType.VarChar).Value = data[1];
                                    command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = data[2];
                                    command.Parameters.Add("@num_faculty", MySqlDbType.VarChar).Value = data[3];
                                    command.Parameters.Add("@num_group", MySqlDbType.VarChar).Value = data[4];

                                    openConnection();

                                    if (command.ExecuteNonQuery() == 1)
                                    {
                                        MessageBox.Show("Студент добавлен.");
                                        closeConnection();

                                        return true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Студент не добавлен.");
                                        closeConnection();

                                        return false;
                                    }
                                }
                            }

                            MessageBox.Show("На этом факультете нет такой группы.");

                            return false;
                        }
                    }
                }
            }

            return false;
        }

        public override bool change(string index, List<string> data)   // изменение данных о студенте
        {
            UserData db = new UserData(connection);

            if (readFile())
            {
                if (db.authorization(login, password))
                {
                    if (accessCheck(login, 2))
                    {
                        if (checkStudent(data))
                        {
                            List<string[]> list_faculties_groups = getFacultiesGroupsData();

                            for (int i = 0; i < list_faculties_groups.Count; ++i)
                            {
                                if (list_faculties_groups[i][0] == data[2]
                                    && list_faculties_groups[i][2] == data[3])  // проверка на то, есть ли переданная группа в переданном факультете или нет
                                {
                                    MySqlCommand command = new MySqlCommand($"UPDATE `{name_table}` SET name = @name, surname = @surname, num_faculty = @num_faculty, num_group = @num_group WHERE student_number=@index", connection);
                                    command.Parameters.Add("@name", MySqlDbType.VarChar).Value = data[0];
                                    command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = data[1];
                                    command.Parameters.Add("@num_faculty", MySqlDbType.VarChar).Value = data[2];
                                    command.Parameters.Add("@num_group", MySqlDbType.VarChar).Value = data[3];
                                    command.Parameters.Add("@index", MySqlDbType.VarChar).Value = index;

                                    openConnection();

                                    if (command.ExecuteNonQuery() == 1)
                                    {
                                        MessageBox.Show("Студент изменен.");
                                        closeConnection();

                                        return true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Студент не изменен.");
                                        closeConnection();

                                        return false;
                                    }
                                }
                            }

                            MessageBox.Show("На этом факультете нет такой группы.");

                            return false;
                        }
                    }
                }
            }

            return false;
        }
        public override bool delete(string index)
        {
            UserData db = new UserData(connection);

            if (readFile())
            {
                if (db.authorization(login, password))
                {
                    if (accessCheck(login, 3))
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
                            MessageBox.Show("Студент не был удален.");
                            closeConnection();

                            return false;
                        }
                    }
                }
            }

            return false;
        }
    }
}
