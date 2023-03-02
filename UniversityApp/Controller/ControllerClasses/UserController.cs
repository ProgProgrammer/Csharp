using Controller.Interfaces;
using Model.Interface;
using Model.ModelClasses;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Controller.ControllerClasses
{
    internal class UserController : AControllerInternal
    {
        private IDataBase db_model = new UserData();

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
                return new List<string[]>();
            }
        }

        public override bool add(List<string> data)
        {
            if (accessCheck(1))
            {
                if (db_model.add(data))
                {
                    MessageBox.Show("Пользователь добавлен.");
                    return true;
                }
                else
                {
                    MessageBox.Show("Пользователь не добавлен.");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Нет прав доступа на добавление.");
                return false;
            }
        }

        public override bool change(string index, List<string> data)
        {
            if (index != this.login)
            {
                if (accessCheck(2))
                {
                    UserData db = new UserData();

                    if (db.checkUser(data))
                    {
                        if (db_model.change(index, data))
                        {
                            MessageBox.Show("Пользователь изменен.");
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Пользователь не изменен.");
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пользователь с таким логином уже существует в базе данных.");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Нет прав доступа на изменение.");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Пользователь не может изменить самого себя.");
                return false;
            }
        }

        public override bool delete(string index)
        {
            if (index != this.login)
            {
                if (accessCheck(3))
                {
                    if (db_model.delete(index))
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Пользователь не был удален.");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Нет прав доступа на удаление.");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Пользователь не может удалить самого себя.");
                return false;
            }
        }
    }
}
