using Controller.Interfaces;
using System.Collections.Generic;

namespace Controller.ControllerClasses
{
    public class Controler : IControl
    {
        private IControllerInternal db_controller;
        private string faculties = "faculties";
        private string faculties_groups = "faculties_groups";
        private string groups = "groups";
        private string students = "students";
        private string users = "users";

        public Controler(string name_table)
        {
            if (name_table == faculties)
            {
                db_controller = new FacyltiesController();
            }
            else if (name_table == faculties_groups)
            {
                db_controller = new FacyltiesGroupsController();
            }
            else if (name_table == groups)
            {
                db_controller = new GroupsController();
            }
            else if (name_table == students)
            {
                db_controller = new StudentController();
            }
            else if (name_table == users)
            {
                db_controller = new UserController();
            }
        }

        public List<string[]> getFGData()
        {
            return db_controller.getFGData();
        }

        public bool authorization(string login, string password)
        {
            return db_controller.authorization(login, password);
        }

        public bool accessCheck(int id)
        {
            return db_controller.accessCheck(id);
        }

        public List<string[]> getAllData()
        {
            return db_controller.getAllData();
        }

        public bool add(List<string> data)
        {
            return db_controller.add(data);
        }

        public bool change(string index, List<string> data)
        {
            return db_controller.change(index, data);
        }

        public bool delete(string index)
        {
            return db_controller.delete(index);
        }
    }
}
