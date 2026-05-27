using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ExpenseAppGroup
{
    public class User:Account
    {
        //properties
        public string firstName;
        public string lastName;
        public DateTime birthday = new DateTime();
        public string username;
        public string password;

        //Menu for login 
        public static void UserLogin()
        {
            Console.Clear();

            Console.WriteLine("Enter your username:");
            string userName = Console.ReadLine();

            Console.WriteLine("Enter your password:");
            string password = Console.ReadLine();

            if (userName == "user" && password == "password")
            {
                Console.WriteLine("Login success");
            }
            else
            {
                Console.WriteLine("Wrong login");
            }

            UserHome();

        }//end of Login method

      

        public static void UserHome()
        {
            Console.Clear();

            Console.WriteLine("\tHome");
            Console.WriteLine();
            Console.WriteLine("1. View expenses");
            Console.WriteLine("2. Add new expense");
            Console.WriteLine("3. Update existing expense");
            Console.WriteLine("4. Remove expense");
            Console.WriteLine("5. View savings");
            Console.WriteLine("6. Logout");
            Console.WriteLine("99. Exit");

            Console.WriteLine("Please select an option:");
            int homeChoice = Convert.ToInt32(Console.ReadLine());

            switch (homeChoice)
            {
                case 1:
                    Console.WriteLine("Viewing expenses");
                    Console.WriteLine();
                    Expenses.ViewExpenses();
                    break;

                case 2:
                    Console.WriteLine("Add new expense");
                    break;

                case 3:
                    Console.WriteLine("Update existing expense");
                    break;

                case 4:
                    Console.WriteLine("Remove expense");
                    break;

                case 5:
                    Console.WriteLine("View savings");
                    break;

                case 6:
                    Console.WriteLine("Logout");
                        Program.LandingPage();
                    break;
                case 99:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Please select a valid option.");
                    break;


            }//end of switch-----------------------------------------------------------------------------------

        }//end of UserHome-------------------------------------------------------------------------------------




    }//end of class---------------------------------------------------------------------------------------------
}//end of namespace---------------------------------------------------------------------------------------------
