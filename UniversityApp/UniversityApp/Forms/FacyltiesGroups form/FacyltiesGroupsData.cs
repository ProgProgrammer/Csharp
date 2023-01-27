using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversityApp
{
    internal class FacyltiesGroupsData : ADataBase
    {
        private const string name_table = "faculties_groups";
        private const string access_column = "access_facylties_groups";

        public FacyltiesGroupsData(MySqlConnection connection) : base(connection)
        {
            access_column_abs_class = access_column;
        }

        public List<string[]> getAllData()
        {
            UserData db = new UserData(connection);

            if (readFile())
            {
                if (db.authorization(login, password))
                {
                    if (accessCheck(login, 0))
                    {
                        MySqlCommand command_groups_num = new MySqlCommand("SELECT COUNT(*) FROM groups", connection);

                        openConnection();
                        int numRowsGroups = Convert.ToInt32(command_groups_num.ExecuteScalar());
                        closeConnection();

                        List<string[]> data = new List<string[]>();
                        MySqlCommand command = new MySqlCommand("SELECT faculties_groups.id, faculties.name, groups.name FROM faculties_groups JOIN faculties ON faculties_groups.num_faculty = faculties.id JOIN groups ON faculties_groups.num_group = groups.id", connection);

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
            return false;
        }
        public override bool change(string index, List<string> data)
        {
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

            return false;
        }
    }
}
