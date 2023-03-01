using MySql.Data.MySqlClient;
using Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Model.ModelClasses
{
    public class FacultiesGroupsData : ADataBase
    {
        private const string name_table = "faculties_groups";
        private const string access_column = "access_faculties_groups";

        public FacultiesGroupsData()
        {
            access_column_abs_class = access_column;
        }

        private bool checkFacultiesGroups(List<string> data)
        {
            FacultiesGroupsData db_faculties_groups = new FacultiesGroupsData();
            List<string[]> data_faculties_groups = db_faculties_groups.getAllData();

            if (data.Count() > 1)
            {
                for (int i = 0; i < data_faculties_groups.Count(); ++i)
                {
                    if (data_faculties_groups[i][2] == data[1])
                    {
                        return false;
                    }
                }
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
            MySqlCommand command_groups_num = new MySqlCommand("SELECT COUNT(*) FROM groups", connection);

            openConnection();
            int numRowsGroups = Convert.ToInt32(command_groups_num.ExecuteScalar());
            closeConnection();

            List<string[]> data = new List<string[]>();
            MySqlCommand command = new MySqlCommand("SELECT faculties_groups.id, faculties.name, groups.name FROM faculties_groups JOIN faculties ON faculties_groups.num_faculty = faculties.id " +
                "JOIN groups ON faculties_groups.num_group = groups.id", connection);

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

        public override bool add(List<string> data)
        {
            if (checkFacultiesGroups(data))
            {
                MySqlCommand command = new MySqlCommand($"INSERT INTO `{name_table}`(num_faculty, num_group) VALUES(@num_faculty, @num_group)", connection);
                command.Parameters.Add("@num_faculty", MySqlDbType.VarChar).Value = data[0];
                command.Parameters.Add("@num_group", MySqlDbType.VarChar).Value = data[1];

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
            else
            {
                MessageBox.Show("Такая группа есть на другом факультете.");

                return false;
            }
        }
        public override bool change(string index, List<string> data)
        {
            if (checkFacultiesGroups(data))
            {
                MySqlCommand command = new MySqlCommand();

                if (data.Count() > 1)
                {
                    command = new MySqlCommand($"UPDATE `{name_table}` SET num_faculty = @num_faculty, num_group = @num_group WHERE id=@index", connection);
                    command.Parameters.Add("@num_faculty", MySqlDbType.VarChar).Value = data[0];
                    command.Parameters.Add("@num_group", MySqlDbType.VarChar).Value = data[1];
                    command.Parameters.Add("@index", MySqlDbType.VarChar).Value = index;
                }
                else
                {
                    command = new MySqlCommand($"UPDATE `{name_table}` SET num_faculty = @num_faculty WHERE id=@index", connection);
                    command.Parameters.Add("@num_faculty", MySqlDbType.VarChar).Value = data[0];
                    command.Parameters.Add("@index", MySqlDbType.VarChar).Value = index;
                }

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
            else
            {
                MessageBox.Show("Такая группа есть на другом факультете.");

                return false;
            }
        }
        public override bool delete(string index)
        {
            MySqlCommand command = new MySqlCommand($"DELETE FROM `{name_table}` WHERE id = @id", connection);
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = index;

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
