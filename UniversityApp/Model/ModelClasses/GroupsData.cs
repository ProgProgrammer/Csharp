using MySql.Data.MySqlClient;
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

        public override bool add(List<string> data)
        {
            MySqlCommand command = new MySqlCommand($"INSERT INTO `{name_table}`(name) VALUES(@name_faculty)", connection);
            command.Parameters.Add("@name_faculty", MySqlDbType.VarChar).Value = data[0];

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

        public override bool change(string index, List<string> data)   // изменение данных о студенте
        {
            MySqlCommand command = new MySqlCommand($"UPDATE `{name_table}` SET name = @name WHERE id=@index", connection);
            command.Parameters.Add("@index", MySqlDbType.VarChar).Value = index;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = data[0];

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
