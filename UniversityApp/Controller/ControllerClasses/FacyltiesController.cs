using Controller.Interfaces;
using System.Collections.Generic;
using System.Windows.Forms;
using Model.ModelClasses;
using Model.Interface;

namespace Controller.ControllerClasses
{
    internal class FacyltiesController : AControllerInternal
    {
        private IDataBase cont_internal = new FacultiesData();

        public override bool accessCheck(int id)
        {
            return false;
        }
        public override List<string[]> getAllData()
        {
            /*if (cont_internal.authorization(this.login, password))
            {
                if (accessCheck(0))
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
                else
                {
                    MessageBox.Show("Нет прав доступа на чтение.");

                    return new List<string[]>();
                }
            }*/

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
