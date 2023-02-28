using System.Collections.Generic;

namespace Controller.Interfaces
{
    internal interface IControllerInternal
    {
        bool accessCheck(int id);
        List<string[]> getAllData();
        bool add(List<string> data);
        bool change(string index, List<string> data);
        bool delete(string index);
    }
}
