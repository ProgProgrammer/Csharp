using Controller.Interfaces;
using System.Collections.Generic;

namespace Controller.ControllerClasses
{
    public class Controller : IControl
    {
        private IControllerInternal controller_obj;
        private string faculties = "faculties";
        private string faculties_groups = "faculties_groups";
        private string groups = "groups";
        private string students = "students";
        private string users = "users";

        public Controller(string name_table)
        {
            if (name_table == faculties)
            {
                controller_obj = new FacyltiesController();
            }
            else if (name_table == faculties_groups)
            {
                controller_obj = new FacyltiesGroupsController();
            }
            else if (name_table == groups)
            {
                controller_obj = new GroupsController();
            }
            else if (name_table == students)
            {
                controller_obj = new StudentController();
            }
            else if (name_table == users)
            {
                controller_obj = new UserController();
            }
        }

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
