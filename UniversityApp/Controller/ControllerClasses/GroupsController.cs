using Controller.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.ControllerClasses
{
    internal class GroupsController : IControllerInternal
    {
        public GroupsController() { }

        public bool accessCheck(int id)
        {
            return false;
        }

        public List<string[]> getAllData()
        {
            return new List<string[]>();
        }

        public bool add(List<string> data)
        {
            return false;
        }

        public bool change(string index, List<string> data)
        {
            return false;
        }

        public bool delete(string index)
        {
            return false;
        }
    }
}
