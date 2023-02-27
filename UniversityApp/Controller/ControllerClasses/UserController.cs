using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.ControllerClasses
{
    internal class UserController
    {
        public UserController() { }

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
