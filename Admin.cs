using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseAppGroup
{
    public class Admin:Account
    {
        //Admin login screen
        public static void AdminLogin()
        {
            Console.Clear();

            Console.WriteLine("Enter your admin username:");
            string adminUserName = Console.ReadLine();

            Console.WriteLine("Enter your admin password:");
            string adminPassword = Console.ReadLine();

            if (adminUserName == "admin" && adminPassword == "password")
            {
                Console.WriteLine("Login success");
            }
            else
            {
                Console.WriteLine("Wrong login");
            }
        }//end of Login method





    }//end of Admin------------------------------------------
}
