using System.Collections.Generic;

namespace Controller.Interfaces
{
    public interface IControl
    {
        bool accessCheck(int id);
        List<string[]> getAllData(string nameTable);
        bool add(List<string> data, string nameTable);
        bool change(string index, List<string> data, string nameTable);
        bool delete(string index, string nameTable);
    }
}
