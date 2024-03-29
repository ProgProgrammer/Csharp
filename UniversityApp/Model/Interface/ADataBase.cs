﻿using MySql.Data.MySqlClient;
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
        protected MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=itproger");

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

        protected bool authorization(string login, string password)
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand($"SELECT * FROM `{authorization_table}` WHERE login = @login AND password = @password", connection);  // создание команды
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;         // присвоение значения псевдониму
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;   // присвоение значения псевдониму

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
                return false;
            }
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

        public abstract bool userAccessCheck(string login, int id);
        public abstract bool authorizationCheck(string login, string password);
        public abstract List<string[]> getAllData();
        public abstract bool add(List<string> data);
        public abstract bool change(string index, List<string> data);
        public abstract bool delete(string index);
    }
}
