using MySql.Data.MySqlClient;
using Model.ModelClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace Model.Interface
{
    public abstract class ADataBase : IDataBase
    {
        private const string authorization_table = "users";
        protected string access_column_abs_class;  // название запрашиваемой ячейки с доступом
        protected const string file_path = @"authorization_data.txt";
        protected string login;
        protected string password;
        protected MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=itproger");

        protected bool readFile()
        {
            if (File.Exists(file_path))
            {
                int i = 0;

                using (StreamReader fs = new StreamReader(file_path))
                {
                    while (true)
                    {
                        string temp = fs.ReadLine();  // Читаем строку из файла во временную переменную.                    
                        if (temp == null) break;      // Если достигнут конец файла, прерываем считывание.

                        if (i == 0)
                        {
                            login = temp;             // Пишем считанную строку в итоговую переменную.
                        }
                        else
                        {
                            password = temp;          // Пишем считанную строку в итоговую переменную.
                            break;
                        }

                        ++i;
                    }
                }

                return true;
            }
            else
            {
                MessageBox.Show("Нет файла 'authorization_data.txt' с логином и паролем по адресу: " + file_path + ".");

                return false;
            }
        }

        protected bool authorization(string login, string password)
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand($"SELECT * FROM `{authorization_table}` WHERE login = @login AND password = @password", connection);  // создание команды
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;         // присвоение значения псевдониму
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;   // присвоение значения псевдониму

            if (File.Exists(file_path))
            {
                if (this.userExistCheck(table, adapter, command))
                {
                    using (StreamWriter writer = new StreamWriter(file_path, false))
                    {
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

        protected bool accessCheck(string login, int id)  // проверка доступа конкретного юзера
        {
            MySqlCommand command = new MySqlCommand($"SELECT `{access_column_abs_class}` FROM users WHERE login=@login", this.connection);
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;    // присвоение значения псевдониму

            openConnection();
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                string access = reader[0].ToString();

                if (access[id] == '1')
                {
                    reader.Close();
                    closeConnection();

                    return true;
                }
            }

            reader.Close();
            closeConnection();

            return false;
        }

        protected void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        protected void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        protected bool userExistCheck(DataTable table, MySqlDataAdapter adapter, MySqlCommand command)
        {
            openConnection();                 // открытие соединение с БД
            adapter.SelectCommand = command;  // отправка команды в БД на выполнение
            adapter.Fill(table);              // запись в объект table информации о том, что совпадение найдено / не найдено
            closeConnection();                // закрытие соединения с БД, чтобы не перегружать БД

            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected List<string[]> getFacultiesGroupsData()  // предоставляет список из факультетов и групп таблицы "faculties_groups" (проверки нет для уменьшения нагрузки на БД)
        {
            MySqlCommand command_groups_num = new MySqlCommand("SELECT COUNT(*) FROM groups", connection);

            openConnection();
            int numRowsGroups = Convert.ToInt32(command_groups_num.ExecuteScalar());
            closeConnection();

            List<string[]> data = new List<string[]>();
            MySqlCommand command = new MySqlCommand("SELECT faculties.id, faculties.name, groups.id, groups.name FROM faculties_groups JOIN faculties ON faculties_groups.num_faculty = faculties.id JOIN groups ON faculties_groups.num_group = groups.id", connection);

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

        public bool checkAccess(int id)
        {
            UserData db = new UserData();

            if (readFile())
            {
                if (db.authorization(login, password))
                {
                    if (accessCheck(login, id))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public abstract bool userAccessCheck(string login, int id);
        public abstract bool authorizationCheck(string login, string password);
        public abstract List<string[]> getAllData();
        public abstract bool add(List<string> data);
        public abstract bool change(string index, List<string> data);
        public abstract bool delete(string index);
    }
}
