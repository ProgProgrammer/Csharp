using Controller.Interfaces;
using Model.Interface;
using Model.ModelClasses;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace Controller.ControllerClasses
{
    internal class UserController : AControllerInternal
    {
        private IDataBase db_model = new UserData();
        private const string super_admin = "1";

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
            if (File.Exists(file_path))
            {
                if (db_model.authorizationCheck(login, password))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Нет такого пользователя в базе данных либо не правильный пароль.");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Нет такого файла.");
                return false;
            }
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
                UserData db = new UserData();

                if (db.checkUser(data))
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

                MessageBox.Show("Пользователь с таким логином уже существует.");
                return false;
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
                        string super_admin_value = db.getSuperAdmin(index);

                        if (super_admin_value != super_admin)
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

                        MessageBox.Show("Супер-админа невозможно изменить.");
                        return false;
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
                    UserData db = new UserData();
                    string super_admin_value = db.getSuperAdmin(index);

                    if (super_admin_value != super_admin)
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

                    MessageBox.Show("Супер-админа невозможно удалить.");
                    return false;
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
