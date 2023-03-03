using Controller.ControllerClasses;
using Controller.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Controller.Tests
{
    [TestClass]
    public class ControllerTests
    {
        private string faculties = "faculties";
        private string faculties_groups = "faculties_groups";
        private string groups = "groups";
        private string students = "students";
        private string users = "users";

        [TestMethod]
        public void authorizationReturn()
        {
            // arrage
            List<string[]> arr = new List<string[]>();
            List<string> autotification = new List<string>();
            autotification.Add("admin");
            autotification.Add("12345");
            autotification.Add("admin1");
            autotification.Add("12345");
            autotification.Add("admin123");
            autotification.Add("12345");
            autotification.Add("dgfgrg");
            autotification.Add("12345A");
            autotification.Add("admin_f");
            autotification.Add("12345");

            int num = 0;

            for (int i = 0; i < 5; ++i)
            {
                arr.Add(new string[2]);

                for (int a = 0; a < 2; ++a)
                {
                    arr[i][a] = autotification[num];
                    ++num;
                }
            }

            // act
            IControl db = new Controler(users);
            bool result = false;

            for (int i = 0; i < 5; ++i)
            {
                if (!db.authorization(arr[i][0], arr[i][1]))
                {
                    result = false;
                    break;
                }
                else if (i == 5 - 1)
                {
                    result = true;
                    break;
                }
            }

            // assert
            Assert.AreEqual(true, result);
        }
    }
}
