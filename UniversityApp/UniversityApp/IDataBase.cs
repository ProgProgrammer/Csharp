using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApp
{
    internal interface IDataBase
    {
        List<string[]> getData();
        bool add(List<string[]> data_user);
        bool change(List<int> arr_index, string[] arr_data);
        bool delete(int index);
    }
}
