using Controller.Interfaces;
using Model.Interface;
using Model.ModelClasses;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Controller.ControllerClasses
{
    internal class GroupsController : AControllerInternal
    {
        private IDataBase db_model = new GroupsData();

        public override List<string[]> getFGData()
        {
            StudentData db = new StudentData();

            if (accessCheck(0))
            {
                return db.getFacultiesGroupsData();
            }

            return new List<string[]>();
        }

        public override bool authorization(string login, string password)
        {
            return db_model.authorizationCheck(login, password);
        }

        public override bool accessCheck(int id)
        {
            if (db_model.authorizationCheck(login, password))
            {
                return db_model.userAccessCheck(login, id);
            }

            return false;
        }

        public override List<string[]> getAllData()
        {
            if (accessCheck(0))
            {
                return db_model.getAllData();
            }
            else
            {
                MessageBox.Show("Нет прав доступа на чтение.");
            }

            return new List<string[]>();
        }

        public override bool add(List<string> data)
        {
            if (accessCheck(1))
            {
                if (db_model.add(data))
                {
                    MessageBox.Show("Группа добавлена.");
                    return true;
                }
                else
                {
                    MessageBox.Show("Группа не добавлена.");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Нет прав доступа на добавление.");
            }

            return false;
        }

        public override bool change(string index, List<string> data)
        {
            if (accessCheck(2))
            {
                if (db_model.change(index, data))
                {
                    MessageBox.Show("Группа изменена.");
                    return true;
                }
                else
                {
                    MessageBox.Show("Группа не изменена.");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Нет прав доступа на изменение.");
            }

            return false;
        }

        public override bool delete(string index)
        {
            if (accessCheck(3))
            {
                if (!db_model.delete(index))
                {
                    MessageBox.Show("Группа не удалена.");
                }
            }
            else
            {
                MessageBox.Show("Нет прав доступа на удаление.");
            }

            return false;
        }
    }
}
