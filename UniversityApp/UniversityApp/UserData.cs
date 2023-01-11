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
            return new List<string[]>();
        }
        public override bool add(List<string> data)
        {
            return false;
        }
        public override bool change(string index, List<string> data)
        {
            return false;
        }
        public override bool delete(string index)
        {
            return false;
        }
    }
}
