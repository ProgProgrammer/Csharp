using Controller.Interfaces;
using System.Collections.Generic;
using System.Windows.Forms;
using Model.ModelClasses;
using Model.Interface;
using System.Diagnostics.Eventing.Reader;

namespace Controller.ControllerClasses
{
    internal class FacyltiesController : AControllerInternal
    {
        private IDataBase model_obj = new FacultiesData();

        public override bool accessCheck(int id)
        {
            return model_obj.userAccessCheck(login, id);
        }

        public override List<string[]> getAllData()
        {
            if (model_obj.authorizationCheck(login, password))
            {
                if (accessCheck(0))
                {
                    return model_obj.getAllData();
                }
                else
                {
                    MessageBox.Show("Нет прав доступа на чтение.");
                }
            }

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
