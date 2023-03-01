using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System;

namespace Controller.Interfaces
{
    internal abstract class AControllerInternal : IControllerInternal
    {
        private const string file_path = @"authorization_data.txt";
        private const string file_name = "authorization_data.txt";
        public string login;
        public string password;

        private bool readFile()
        {
            if (File.Exists(file_path))
            {
                int i = 0;

                using (StreamReader fs = new StreamReader(file_path))
                {
                    while (true)
                    {
                        string temp = fs.ReadLine();  // Читаем строку из файла во временную переменную.                    
                        if (temp == null) break;      // Если достигнут конец файла, прерываем считывание.

                        if (i == 0)
                        {
                            login = temp;             // Пишем считанную строку в итоговую переменную.
                        }
                        else
                        {
                            password = temp;          // Пишем считанную строку в итоговую переменную.
                            break;
                        }

                        ++i;
                    }
                }

                return true;
            }
            else
            {
                throw new Exception("Нет файла '" + file_name + "' с логином и паролем по адресу: " + file_path + ".");
            }
        }

        protected List<string[]> getFacultiesGroupsData()
        {
            return new List<string[]>();
        }

        public AControllerInternal()
        {
            try
            {
                readFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        public abstract bool authorization(string login, string password);
        public abstract bool accessCheck(int id);
        public abstract List<string[]> getAllData();
        public abstract bool add(List<string> data);
        public abstract bool change(string index, List<string> data);
        public abstract bool delete(string index);
    }
}
