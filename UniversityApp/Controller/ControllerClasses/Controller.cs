using Controller.Interfaces;
using System.Collections.Generic;

namespace Controller.ControllerClasses
{
    public class Controller : IControl
    {
        private IControllerInternal controller_obj;

        public bool accessCheck(int id)
        {
            return false;
        }

        public List<string[]> getAllData(string nameTable)
        {
            return new List<string[]>();
        }

        public bool add(List<string> data, string nameTable)
        {
            return false;
        }

        public bool change(string index, List<string> data, string nameTable)
        {
            return false;
        }

        public bool delete(string index, string nameTable)
        {
            return false;
        }
    }
}
