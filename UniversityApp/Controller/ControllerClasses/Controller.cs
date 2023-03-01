using Controller.Interfaces;
using System.Collections.Generic;

namespace Controller.ControllerClasses
{
    public class Controler : IControl
    {
        private IControllerInternal controller_obj;
        private string faculties = "faculties";
        private string faculties_groups = "faculties_groups";
        private string groups = "groups";
        private string students = "students";
        private string users = "users";

        public Controler(string name_table)
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

        public bool authorization(string login, string password)
        {
            return false;
        }

        public bool accessCheck(int id)
        {
            return controller_obj.accessCheck(id);
        }

        public List<string[]> getAllData()
        {
            return controller_obj.getAllData();
        }

        public bool add(List<string> data)
        {
            return controller_obj.add(data);
        }

        public bool change(string index, List<string> data)
        {
            return controller_obj.change(index, data);
        }

        public bool delete(string index)
        {
            return controller_obj.delete(index);
        }
    }
}
