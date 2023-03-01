using System.Collections.Generic;

namespace Controller.Interfaces
{
    public interface IControl
    {
        bool authorization(string login, string password);
        bool accessCheck(int id);
        List<string[]> getAllData();
        bool add(List<string> data);
        bool change(string index, List<string> data);
        bool delete(string index);
    }
}
