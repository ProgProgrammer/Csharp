using MySql.Data.MySqlClient;
using Model.Interface;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Model.ModelClasses
{
    public class UserData : ADataBase
    {
        private const string name_table = "users";
        private const string access_column = "access_user";

        public UserData()
        {
            access_column_abs_class = access_column;
        }

        public string getSuperAdmin(string login)
        {
            MySqlCommand command = new MySqlCommand($"SELECT super_admin FROM `{name_table}` WHERE login = @login", connection);
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;

            openConnection();

            MySqlDataReader reader = command.ExecuteReader();
            string super_admin = "";

            if (reader.Read())
            {
                super_admin = reader[0].ToString();
            }

            reader.Close();
            closeConnection();

            return super_admin;
        }

        public bool checkUser(List<string> data)
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand($"SELECT * FROM `{name_table}` WHERE login = @login", connection);
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = data[0];

            if (userExistCheck(table, adapter, command))
            {
                return false;
            }

            return true;
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
        public override bool add(List<string> data)
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
                closeConnection();
                return true;
            }
            else
            {
                closeConnection();
                return false;
            }
        }
        public override bool change(string index, List<string> data)
        {
            MySqlCommand command = new MySqlCommand($"UPDATE `{name_table}` SET password = @password, " +
                $"name = @name, surname = @surname, access_user = @access_user, " +
                $"access_student = @access_student, access_faculties_groups = @access_faculties_groups WHERE login = @index", connection);
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = data[0];
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = data[1];
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = data[2];
            command.Parameters.Add("@access_user", MySqlDbType.VarChar).Value = data[3];
            command.Parameters.Add("@access_student", MySqlDbType.VarChar).Value = data[4];
            command.Parameters.Add("@access_faculties_groups", MySqlDbType.VarChar).Value = data[5];
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
                closeConnection();
                return false;
            }
        }
    }
}
