using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataUniversity.Interface
{
    public interface IDataBase
    {
        List<string[]> getAllData();
        bool add(List<string> data);
        bool change(string index, List<string> data);
        bool delete(string index);
    }
}
