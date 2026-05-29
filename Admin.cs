using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseAppGroup
{
    public class Admin:Account
    {

        //METHODS


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
        }//end of Admin Login method-------------------------------------------------




        //Admin Home-----------------------------------------------------------------
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
                        Expenses.ViewExpenses();
                        break;

                    case 2:
                        Console.WriteLine("Viewing all savings");
                        break;

                    case 3:
                        Console.WriteLine("Manage users");
                        ManageUsers();
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

                }//end of switch-------------------------------------

            } while (adminHomeLoop == true); //do while loop to re-run admin home menu


        }//end of AdminHome-------------------------------------------------------------------------------------




        //Manage users------------------------------------------------------------------------------------------
        public static void ManageUsers()
        {

            bool mngUserLoop = false;

            Console.WriteLine("Administrator panel - Manage users");
            Console.WriteLine();

            do
            {
                Console.Clear() ;

                Console.WriteLine("1. View all users");
                Console.WriteLine("2. Add new user");
                Console.WriteLine("3. Update user");
                Console.WriteLine("4. Remove user");
                Console.WriteLine("5. Back to admin home");
                int mngUserChoice = Convert.ToInt32(Console.ReadLine());

                switch (mngUserChoice)
                {
                    case 1:
                        ViewUsers();
                        break;

                    case 2:
                        Console.WriteLine("Adding new user");
                        AdminAddUser();
                        break;

                    case 3:
                        Console.WriteLine("Updating user details");
                        AdminUpdateUser();
                        break;

                    case 4:
                        Console.WriteLine("Remove user");
                        RemoveUser();
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
        }//end of Manage users----------------------------------------------



        //View all users

        public static void ViewUsers()
        {
            Console.Clear();

            Console.WriteLine("Viewing all users");

            foreach (User user in User.users)
            {
                user.DisplayUserDetails();
            }


        }//end of View User class-----------------------------------





        //Admin add user--------------------------------------------
        public static void AdminAddUser()                                                               //NEED TO CHANGE THIS SECTION TO MATCH REGISTER(); METHOD
        {

            Console.Clear();

            bool pwVerify = false;

            Console.WriteLine("Enter the user's first name:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter the user's last name:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Enter the user's date of birth:");
            string dob = Console.ReadLine();

            Console.WriteLine("Enter their username:");
            string userName = Console.ReadLine();

            //Do-While loop for confirming password
            do
            {

                Console.WriteLine("Enter their password:");
                string password = Console.ReadLine();

                Console.WriteLine("Re-enter their password:");
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

            ManageUsers();

        }//end of Admin Add User ------------------------------------------------------------------




        //Update user------------------------------------------------------

        public static void AdminUpdateUser()
        {
            Console.WriteLine("This will let the admin update user details");

        }//end of Admin Update User ----------------------------------------





        //Remove user-------------------------------------------------------

        public static void RemoveUser()
        {
            Console.WriteLine("This will let the admin remove a user");
        }//end of Remove User-----------------------------------------------





    }//end of Admin-----------------------------------------------------------------------------------------------------------------------------------------------------
}
