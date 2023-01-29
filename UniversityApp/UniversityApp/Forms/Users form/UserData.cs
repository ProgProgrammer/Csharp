using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversityApp
{
    internal class UserData : ADataBase
    {
        private const string name_table = "users";
        private const string access_column = "access_user";
        
        private bool checkUser(List<string> data)
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand($"SELECT * FROM `{name_table}` WHERE login = @login", connection);
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = data[0];

            if (userExistCheck(table, adapter, command))
            {
                MessageBox.Show("Пользователь с таким логином уже существует в базе данных.");

                return false;
            }

            return true;
        }

        public UserData(MySqlConnection connection) : base(connection)
        {
            access_column_abs_class = access_column;
        }

        public bool authorization(string login, string password)
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand($"SELECT * FROM `{name_table}` WHERE login = @login AND password = @password", connection);  // создание команды
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;         // присвоение значения псевдониму
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;   // присвоение значения псевдониму

            if (File.Exists(file_path))
            {
                if (this.userExistCheck(table, adapter, command))
                {
                    using (StreamWriter writer = new StreamWriter(file_path, false))
                    {
                        this.login = login;
                        this.password = password;

                        writer.WriteLineAsync(login);
                        writer.WriteAsync(password);

                        return true;
                    }
                }
                else
                {
                    MessageBox.Show("Нет такого пользователя в базе данных либо не правильный пароль.");

                    return false;
                }
            }

            MessageBox.Show("Нет такого файла.");

            return false;
        }
        public override List<string[]> getAllData()
        {
            if (readFile())
            {
                if (this.authorization(login, password))
                {
                    if (accessCheck(login, 0))
                    {
                        MySqlCommand command = new MySqlCommand($"SELECT * FROM `{name_table}` ORDER BY id", this.connection);
                        List<string[]> data = new List<string[]>();

                        openConnection();

                        MySqlDataReader reader = command.ExecuteReader();
                        int num_cell_data = reader.FieldCount - 1;

                        while (reader.Read())
                        {
                            data.Add(new string[num_cell_data]);

                            for (int i = 0; i < num_cell_data; ++i)
                            {
                                data[data.Count - 1][i] = reader[i + 1].ToString();
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
            if (readFile())
            {
                if (authorization(login, password))
                {
                    if (accessCheck(login, 1))
                    {
                        if (checkUser(data))
                        {
                            MySqlCommand command = 
                                new MySqlCommand($"INSERT INTO `{name_table}`(login, password, name, surname, super_admin, access_user, access_student, access_faculties_groups) " +
                                $"VALUES(@login, @password, @name, @surname, @super_admin, @access_user, @access_student, @access_faculties_groups)", connection);
                            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = data[0];
                            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = data[1];
                            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = data[2];
                            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = data[3];
                            command.Parameters.Add("@super_admin", MySqlDbType.VarChar).Value = data[4];
                            command.Parameters.Add("@access_user", MySqlDbType.VarChar).Value = data[5];
                            command.Parameters.Add("@access_student", MySqlDbType.VarChar).Value = data[6];
                            command.Parameters.Add("@access_faculties_groups", MySqlDbType.VarChar).Value = data[7];

                            openConnection();

                            if (command.ExecuteNonQuery() == 1)
                            {
                                MessageBox.Show("Пользователь добавлен.");
                                closeConnection();

                                return true;
                            }
                            else
                            {
                                MessageBox.Show("Пользователь не добавлен.");
                                closeConnection();

                                return false;
                            }
                        }
                    }
                }
            }

            return false;
        }
        public override bool change(string index, List<string> data)
        {
            if (readFile())
            {
                if (authorization(login, password))
                {
                    if (accessCheck(login, 2))
                    {
                        if (checkUser(data))
                        {
                            MySqlCommand command = new MySqlCommand($"UPDATE `{name_table}` SET password = @password, " +
                                $"name = @name, surname = @surname, super_admin = @super_admin, access_user = @access_user, " +
                                $"access_student = @access_student, access_faculties_groups = @access_faculties_groups WHERE login = @index", connection);
                            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = data[0];
                            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = data[1];
                            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = data[2];
                            command.Parameters.Add("@super_admin", MySqlDbType.VarChar).Value = "0";
                            command.Parameters.Add("@access_user", MySqlDbType.VarChar).Value = data[3];
                            command.Parameters.Add("@access_student", MySqlDbType.VarChar).Value = data[4];
                            command.Parameters.Add("@access_faculties_groups", MySqlDbType.VarChar).Value = data[5];
                            command.Parameters.Add("@index", MySqlDbType.VarChar).Value = index;

                            openConnection();

                            if (command.ExecuteNonQuery() == 1)
                            {
                                MessageBox.Show("Пользователь изменен.");
                                closeConnection();

                                return true;
                            }
                            else
                            {
                                MessageBox.Show("Пользователь не изменен.");
                                closeConnection();

                                return false;
                            }
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
                        MySqlCommand command = new MySqlCommand($"DELETE FROM `{name_table}` WHERE login = @login", connection);
                        command.Parameters.Add("@login", MySqlDbType.VarChar).Value = index;

                        openConnection();

                        if (command.ExecuteNonQuery() == 1)
                        {
                            closeConnection();

                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Пользователь не был удален.");
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
