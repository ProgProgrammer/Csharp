using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApp
{
    internal class StudentData : ADataBase
    {
        private const string name_table = "students";

        public StudentData(MySqlConnection connection) : base(connection)
        {
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
