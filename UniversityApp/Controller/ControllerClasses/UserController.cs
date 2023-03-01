using Controller.Interfaces;
using Model.Interface;
using Model.ModelClasses;
using System.Collections.Generic;

namespace Controller.ControllerClasses
{
    internal class UserController : AControllerInternal
    {
        private IDataBase model_obj = new UserData();

        public override bool authorization(string login, string password)
        {
            return model_obj.authorizationCheck(login, password);
        }

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
