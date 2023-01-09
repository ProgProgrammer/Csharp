using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApp
{
    internal abstract class ADataBase : IDataBase
    {
        protected const string file_path = @"..\files\authorization_data.txt";
        protected string login;
        protected string password;
        protected MySqlConnection connection;

        public ADataBase(MySqlConnection connection)
        {
            this.connection = connection;
        }

        protected bool accessCheck()
        {
            return true;
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

        public abstract List<string[]> getData();
        public abstract bool add(List<string[]> data_user);
        public abstract bool change(List<int> arr_index, string[] arr_data);
        public abstract bool delete(int index);
    }
}
