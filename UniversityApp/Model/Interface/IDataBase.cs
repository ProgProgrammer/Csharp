using System.Collections.Generic;

namespace Model.Interface
{
    public interface IDataBase
    {
        bool userAccessCheck(string login, int id);
        bool authorizationCheck(string login, string password);
        List<string[]> getAllData();
        bool add(List<string> data);
        bool change(string index, List<string> data);
        bool delete(string index);
    }
}
