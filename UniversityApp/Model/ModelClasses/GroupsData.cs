﻿using MySql.Data.MySqlClient;
using Model.Interface;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Model.ModelClasses
{
    public class GroupsData : ADataBase
    {
        private const string name_table = "groups";
        private const string access_column = "access_faculties_groups";

        public GroupsData()
        {
            access_column_abs_class = access_column;
        }

        public override List<string[]> getAllData()
        {
            UserData db = new UserData();

            if (readFile())
            {
                if (db.authorization(login, password))
                {
                    if (accessCheck(login, 0))
                    {
                        MySqlCommand command = new MySqlCommand($"SELECT * FROM `{name_table}` ORDER BY id", this.connection);
                        List<string[]> data = new List<string[]>();

                        openConnection();

                        MySqlDataReader reader = command.ExecuteReader();
                        int num_cell_data = reader.FieldCount;

                        while (reader.Read())
                        {
                            data.Add(new string[num_cell_data]);

                            for (int i = 0; i < num_cell_data; ++i)
                            {
                                data[data.Count - 1][i] = reader[i].ToString();
                            }
                        }

                        reader.Close();
                        closeConnection();

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
            UserData db = new UserData();

            if (readFile())
            {
                if (db.authorization(login, password))
                {
                    if (accessCheck(login, 1))
                    {
                        MySqlCommand command = new MySqlCommand($"INSERT INTO `{name_table}`(name) VALUES(@name_faculty)", connection);
                        command.Parameters.Add("@name_faculty", MySqlDbType.VarChar).Value = data[0];

                        openConnection();

                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Группа добавлена.");
                            closeConnection();

                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Группа не добавлена.");
                            closeConnection();

                            return false;
                        }
                    }
                }
            }

            return false;
        }

        public override bool change(string index, List<string> data)   // изменение данных о студенте
        {
            UserData db = new UserData();

            if (readFile())
            {
                if (db.authorization(login, password))
                {
                    if (accessCheck(login, 2))
                    {
                        MySqlCommand command = new MySqlCommand($"UPDATE `{name_table}` SET name = @name WHERE id=@index", connection);
                        command.Parameters.Add("@index", MySqlDbType.VarChar).Value = index;
                        command.Parameters.Add("@name", MySqlDbType.VarChar).Value = data[0];

                        openConnection();

                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Группа изменена.");
                            closeConnection();

                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Группа не изменена.");
                            closeConnection();

                            return false;
                        }
                    }
                }
            }

            return false;
        }
        public override bool delete(string index)
        {
            UserData db = new UserData();

            if (readFile())
            {
                if (db.authorization(login, password))
                {
                    if (accessCheck(login, 3))
                    {
                        MySqlCommand command = new MySqlCommand($"DELETE FROM `{name_table}` WHERE id = @id_faculty", connection);
                        command.Parameters.Add("@id_faculty", MySqlDbType.VarChar).Value = index;

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

            return false;
        }
    }
}
