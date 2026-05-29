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

            bool adminLoginMenu = false;

            do
            {

                Console.WriteLine("Enter your admin username:");
                string adminUserName = Console.ReadLine();

                Console.WriteLine("Enter your admin password:");
                string adminPassword = Console.ReadLine();

                if (adminUserName == "admin" && adminPassword == "password")
                {
                    Console.WriteLine("Login success");
                    AdminHome();
                }
                else
                {
                    Console.WriteLine("Wrong login");
                    adminLoginMenu = true;
                }


            }while(adminLoginMenu == true);
        }//end of Admin Login method

        public static void AdminHome()
        {

            bool adminHomeLoop = false;
            Console.Clear();

            do
            {

                Console.WriteLine("\tAdministrator Home");
                Console.WriteLine();
                Console.WriteLine("1. View all expenses");
                Console.WriteLine("2. View all savings");
                Console.WriteLine("3. Manage users");
                Console.WriteLine("4. Logout");
                Console.WriteLine("99. Exit");

                Console.WriteLine("Please select an option:");
                int adminHomeChoice = Convert.ToInt32(Console.ReadLine());

                switch (adminHomeChoice)
                {
                    case 1:
                        Console.WriteLine("Viewing all user expenses");
                        Console.WriteLine();
                        Expenses.ViewExpenses();
                        break;

                    case 2:
                        Console.WriteLine("Viewing all savings");
                        break;

                    case 3:
                        Console.WriteLine("Manage users");
                        break;

                    case 4:
                        Console.WriteLine("Logout");
                        Program.LandingPage();
                        break;
                    case 99:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Enter a valid option!\n");
                        Console.WriteLine("Press any key to return to admin home...");
                        Console.ReadKey();
                        Console.Clear();
                        adminHomeLoop = true;
                        break;

                }//end of switch-----------------------------------------------------------------------------------

            } while (adminHomeLoop == true); //do while loop to re-run user home menu



        }//end of UserHome-------------------------------------------------------------------------------------

        public static void ManageUsers()
        {

            bool mngUserLoop = false;

            Console.WriteLine("Administrator panel - Manage users");
            Console.WriteLine();

            do
            {
                Console.Clear() ;

                Console.WriteLine("1.View all users");
                Console.WriteLine("2. Add new user");
                Console.WriteLine("3. Update user");
                Console.WriteLine("4. Remove user");
                Console.WriteLine("5. Back to admin home");
                int mngUserChoice = Convert.ToInt32(Console.ReadLine());

                switch (mngUserChoice)
                {
                    case 1:
                        Console.WriteLine("Viewing all users");
                        break;

                    case 2:
                        Console.WriteLine("Adding new user");
                        break;

                    case 3:
                        Console.WriteLine("Updating user details");
                        break;

                    case 4:
                        Console.WriteLine("Remove user");
                        break;

                    case 5:
                        Console.WriteLine("Back to admin home");
                        AdminHome();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Enter a valid option!\n");
                        Console.WriteLine("Press any key to return to home...");
                        Console.ReadKey();
                        Console.Clear();
                        mngUserLoop = true;

                        break;

                }

            }while (mngUserLoop == true);
        }




    }//end of Admin------------------------------------------
}
