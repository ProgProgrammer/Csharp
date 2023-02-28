using Controller.Interfaces;
using System.Collections.Generic;

namespace Controller.ControllerClasses
{
    internal class FacyltiesGroupsController : AControllerInternal
    {
        public FacyltiesGroupsController() { }

        public override bool accessCheck(int id)
        {
            return false;
        }

        public override List<string[]> getAllData()
        {
            return new List<string[]>();
        }

        public override bool add(List<string> data)
        {
            return false;
        }

        public override bool change(string index, List<string> data)
        {
            return false;
        }

        public override bool delete(string index)
        {
            return false;
        }
    }
}
