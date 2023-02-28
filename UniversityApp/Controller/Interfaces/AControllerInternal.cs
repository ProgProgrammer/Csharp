using System.Collections.Generic;

namespace Controller.Interfaces
{
    internal abstract class AControllerInternal : IControllerInternal
    {
        protected string login;
        protected string password;

        protected List<string[]> getFacultiesGroupsData()
        {
            return new List<string[]>();
        }

        public AControllerInternal()
        {
            
        }

        public abstract bool accessCheck(int id);
        public abstract List<string[]> getAllData();
        public abstract bool add(List<string> data);
        public abstract bool change(string index, List<string> data);
        public abstract bool delete(string index);
    }
}
