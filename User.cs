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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday = new DateTime();
        public string Username { get; set; }
        public string Password { get; set; }

        public User(string FirstName, string LastName, DateTime Birthday, string Username, string Password)
        {

        }

        //Menu for login 
        public static void UserLogin()
        {
            Console.Clear();

            bool userLoginScreen = false;

            do
            {

                Console.WriteLine("Enter your username:");
                string userName = Console.ReadLine();

                Console.WriteLine("Enter your password:");
                string password = Console.ReadLine();

                if (userName == "user" && password == "password")
                {
                    Console.WriteLine("Login success");
                    UserHome();
                }
                else
                {
                    Console.WriteLine("Wrong login");
                    userLoginScreen = true;
                }

            } while (userLoginScreen == true);
          

        }//end of Login method

        //user Registration method
        public static void Register()
        {
            Console.Clear();

            bool pwVerify = false;
              
                Console.WriteLine("Enter your first name:");
                string firstName = Console.ReadLine();

                Console.WriteLine("Enter your last name:");
                string lastName = Console.ReadLine();

                Console.WriteLine("Enter your date of birth:");
                string dob = Console.ReadLine();

                Console.WriteLine("Enter your username:");
                string userName = Console.ReadLine();

            //Do-While loop for confirming password
            do
            {

                Console.WriteLine("Enter your password:");
                string password = Console.ReadLine();

                Console.WriteLine("Re-enter password:");
                string reEnteredPassword = Console.ReadLine();

                if (password == reEnteredPassword)
                {
                    Console.WriteLine();
                    Console.WriteLine("Account successfully created!");
                    Console.WriteLine();
                    pwVerify = true;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Passwords do not match, please re-enter password.");
                    Console.WriteLine();
                }

            } while (pwVerify == false);

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            

            Program.LandingPage();

        }//end of Register method







        public static void UserHome()
        {

            bool userHomeLoop = false;
            Console.Clear();

            do
            {

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
                        Console.Clear();
                        Console.WriteLine("Enter a valid option!\n");
                        Console.WriteLine("Press any key to return to home...");
                        Console.ReadKey();
                        Console.Clear();
                        userHomeLoop = true;
                        break;

                }//end of switch-----------------------------------------------------------------------------------

            } while (userHomeLoop == true) ; //do while loop to re-run user home menu

            
            
        }//end of UserHome-------------------------------------------------------------------------------------




    }//end of class---------------------------------------------------------------------------------------------
}//end of namespace---------------------------------------------------------------------------------------------
