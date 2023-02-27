using System.Collections.Generic;

namespace Model.Interface
{
    public interface IDataBase
    {
        List<string[]> getAllData();
        bool add(List<string> data);
        bool change(string index, List<string> data);
        bool delete(string index);
    }
}
