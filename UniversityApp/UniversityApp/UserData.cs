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

        public UserData(MySqlConnection connection) : base(connection)
        {
        }
        public bool authorization(string login, string password)
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand($"SELECT * FROM `{name_table}` WHERE login = @login AND password = @password", connection);  // создание команды
            command.Parameters.Add("@table", MySqlDbType.VarChar).Value = name_table;    // присвоение значения псевдониму
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;         // присвоение значения псевдониму
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;   // присвоение значения псевдониму

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
                MessageBox.Show("Нет такого пользователя в базе данных.");

                return false;
            }
        }
        public override List<string[]> getData()
        {
            return new List<string[]>();
        }
        public override bool add(List<string[]> data_user)
        {
            return false;
        }
        public override bool change(List<int> arr_index, string[] arr_data)
        {
            return false;
        }
        public override bool delete(int index)
        {
            return false;
        }
    }
}
