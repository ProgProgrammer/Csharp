using Controller.Interfaces;
using Model.Interface;
using Model.ModelClasses;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Controller.ControllerClasses
{
    internal class StudentController : AControllerInternal
    {
        private IDataBase db_model = new StudentData();
        private const string file_path = @"authorization_data.txt";

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
                StudentData db_student = new StudentData();

                if (db_student.checkStudent(data))
                {
                    List<string[]> list_faculties_groups = db_student.getFacultiesGroupsData();

                    for (int i = 0; i < list_faculties_groups.Count; ++i)
                    {
                        if (list_faculties_groups[i][0] == data[3]
                            && list_faculties_groups[i][2] == data[4])  // проверка на то, есть ли переданная группа в переданном факультете или нет
                        {
                            if (db_model.add(data))
                            {
                                MessageBox.Show("Студент добавлен.");
                                return true;
                            }
                            else
                            {
                                MessageBox.Show("Студент не добавлен.");
                                return false;
                            }
                        }
                    }

                    MessageBox.Show("На этом факультете нет такой группы.");
                }
                else
                {
                    MessageBox.Show("Студент с таким номером студенческого билета уже существует в базе данных.");
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
                StudentData db_student = new StudentData();

                if (db_student.checkStudent(data))
                {
                    List<string[]> list_faculties_groups = db_student.getFacultiesGroupsData();

                    for (int i = 0; i < list_faculties_groups.Count; ++i)
                    {
                        if (list_faculties_groups[i][0] == data[2]
                        && list_faculties_groups[i][2] == data[3])  // проверка на то, есть ли переданная группа в переданном факультете или нет
                        {
                            if (db_model.change(index, data))
                            {
                                MessageBox.Show("Студент изменен.");
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
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
                if (db_model.delete(index))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Студент не был удален.");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Нет прав доступа на удаление.");
                return false;
            }
        }
    }
}
