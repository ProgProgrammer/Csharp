using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversityApp.Forms.Facylties
{
    internal class FacultiesData : ADataBase
    {
        private const string name_table = "faculties";
        private const string access_column = "access_faculties_groups";

        public FacultiesData(MySqlConnection connection) : base(connection)
        {
            access_column_abs_class = access_column;
        }

        public override List<string[]> getAllData()
        {
            UserData db = new UserData(connection);

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
            /*UserData db = new UserData(connection);

            if (readFile())
            {
                if (db.authorization(login, password))
                {
                    if (accessCheck(login, 1))
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
            }*/

            return false;
        }

        public override bool change(string index, List<string> data)   // изменение данных о студенте
        {
            /*UserData db = new UserData(connection);

            if (readFile())
            {
                if (db.authorization(login, password))
                {
                    if (accessCheck(login, 2))
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
            }*/

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
