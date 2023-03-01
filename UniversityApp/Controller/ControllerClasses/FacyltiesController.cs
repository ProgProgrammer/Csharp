using Controller.Interfaces;
using System.Collections.Generic;
using System.Windows.Forms;
using Model.ModelClasses;
using Model.Interface;
using System.Diagnostics.Eventing.Reader;
using System.Xml;

namespace Controller.ControllerClasses
{
    internal class FacyltiesController : AControllerInternal
    {
        private IDataBase model_obj = new FacultiesData();

        public override bool authorization(string login, string password)
        {
            return model_obj.authorizationCheck(login, password);
        }

        public override bool accessCheck(int id)
        {
            if (model_obj.authorizationCheck(login, password))
            {
                return model_obj.userAccessCheck(login, id);
            }

            return false;
        }

        public override List<string[]> getAllData()
        {
            if (accessCheck(0))
            {
                return model_obj.getAllData();
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
                return model_obj.add(data);
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
                return model_obj.change(index, data);
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
                return model_obj.delete(index);
            }
            else
            {
                MessageBox.Show("Нет прав доступа на удаление.");
            }

            return false;
        }
    }
}
