using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseAppGroup //Katie was responsible for this class
{
    public class Admin:Account
    {
        //variables

        //passing name of user to multiple methods - this is used to display the username on the home screen
        public static string name = "";
        
        

        //constructor

        public Admin(string username, string password) 
        { 
            Username = username;
            Password = password;
        }


        //List of admin accounts 

        public static List<Admin> admins = new List<Admin>();




        //METHODS


        //Admin login screen--------------------------------------------------------------------- Katie
        public static void AdminLogin()
        {
            Console.Clear();

            bool adminLoginMenu = false;

            do//do-while to run administrator login menu
            {
                Console.WriteLine("\t\tAdministrator Login");
                Console.WriteLine("---------------------------------------------------------\n");

                //username
                Console.WriteLine("Enter your username:");
                string adminNameEntered = Console.ReadLine();

                //passes username from login to other methods
                Admin.name = adminNameEntered;

                //password
                Console.WriteLine("Enter your password:");
                string passwordEntered = null;

                        while (true) //while loop obfuscates password when the user is typing it
                        {

                            ConsoleKeyInfo ck = Console.ReadKey(true);
                            if (ck.Key != ConsoleKey.Enter)
                            {
                                if (ck.Key != ConsoleKey.Backspace)
                                {
                                    passwordEntered += ck.KeyChar.ToString();
                                    Console.Write("*");
                                }
                                else
                                {
                                    Console.Write("\b \b");
                                }//end of if else
                            }
                            else
                            {
                                Console.WriteLine();

                                break;
                            }//end of if else

                        }//end of while


                //searches admin list for matching username and password
                Admin adminFound = admins.Find(a => a.Username.Equals(adminNameEntered, StringComparison.Ordinal));

                if (adminFound != null && adminFound.Password == passwordEntered) //login successful
                {
                    Console.WriteLine("\nLogin Success! \nPress any key to continue...");
                    Console.ReadKey();
                    adminLoginMenu = false;
                    AdminHome();
                }
                else //wrong password or username
                {
                    Console.WriteLine("\nWrong username or password. Try again.");

                    adminLoginMenu = true;
                }


            } while (adminLoginMenu == true); //will keep looping until correct credentials are entered


        }//end of Admin Login method-----------------------------------------------------------




        //Admin Home---------------------------------------------------------------------------- Katie
        public static void AdminHome()
        {

            bool adminHomeLoop = false;

            //sorts lists alphabetically by username
            User.users.Sort((s1, s2) => s1.Username.CompareTo(s2.Username));
            Expenses._expenses.Sort((s1, s2) => s1.UserName.CompareTo(s2.UserName));
            Savings._savings.Sort((s1, s2) => s1.UserName.CompareTo(s2.UserName));
            Savings._goals.Sort((s1, s2) => s1.UserName.CompareTo(s2.UserName));

            Console.Clear();

            do //do-while runs admin home page
            {
                try
                {

                    Console.WriteLine("\t\tAdministrator Home");
                    Console.WriteLine("---------------------------------------------------------\n");
                    Console.WriteLine("Welcome " + Admin.name + "!\n");


                    Console.WriteLine("1. View all expenses");
                    Console.WriteLine("2. View all savings");
                    Console.WriteLine("3. Manage users");
                    Console.WriteLine("4. Logout");
                    Console.WriteLine("99. Exit");

                    Console.WriteLine("\nPlease select an option:");
                    int adminHomeChoice = Convert.ToInt32(Console.ReadLine());

                    switch (adminHomeChoice) //switch case that runs methods based on the admin's choice
                    {
                        case 1:
                            ViewExpenses();
                            break;

                        case 2:
                            ViewSavings();
                            break;

                        case 3:
                            ManageUsers();
                            break;

                        case 4:
                            Program.LandingPage();
                            break;
                        case 99:
                            Environment.Exit(0);
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("\nEnter a valid option!\n");
                            Console.WriteLine("Press any key to return to admin home...");
                            Console.ReadKey();
                            Console.Clear();
                            adminHomeLoop = true;
                            break;

                    }//end of switch-------------------------------------

                }
                catch (FormatException ex)
                {
                    Console.WriteLine();
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please enter a valid number.\n");
                    Console.WriteLine("Press any key to contine...");
                    Console.ReadKey();
                    AdminHome();
                }


            } while (adminHomeLoop == true); //do while loop to re-run admin home menu


        }//end of AdminHome-------------------------------------------------------------------------------------




        //Manage users------------------------------------------------------------------------------------------ Katie
        public static void ManageUsers()
        {

            bool mngUserLoop = false;

            //sorts lists alphabetically by username
            User.users.Sort((s1, s2) => s1.Username.CompareTo(s2.Username));
            Expenses._expenses.Sort((s1, s2) => s1.UserName.CompareTo(s2.UserName));
            Savings._savings.Sort((s1, s2) => s1.UserName.CompareTo(s2.UserName));
            Savings._goals.Sort((s1, s2) => s1.UserName.CompareTo(s2.UserName));

            do //do-while loop to run manage user menu
            {
                try 
                { 

                    Console.Clear();
                    Console.WriteLine("\t\tAdministrator panel - Manage users\n");

                    Console.WriteLine("1. View all users");
                    Console.WriteLine("2. Add new user");
                    Console.WriteLine("3. Update user");
                    Console.WriteLine("4. Remove user");
                    Console.WriteLine("5. Back to admin home");
                    int mngUserChoice = Convert.ToInt32(Console.ReadLine());

                    switch (mngUserChoice) //switch menu for admin manage user choice
                    {
                        case 1:
                            ViewUsers();
                            break;

                        case 2:
                            AdminAddUser();
                            break;

                        case 3:
                            AdminUpdateUser();
                            break;

                        case 4:
                            AdminRemoveUser();
                            break;

                        case 5:
                            AdminHome();
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("\nEnter a valid option!\n");
                            Console.WriteLine("Press any key to return to Admin Home...");
                            Console.ReadKey();
                            Console.Clear();
                            mngUserLoop = true;
                            break;

                    }//end of switch

                }//end of try
                catch (FormatException ex)
                {
                    Console.WriteLine();
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please enter a valid number.\n");
                    Console.WriteLine("Press any key to contine...");
                    Console.ReadKey();
                    ManageUsers();
                }

            } while (mngUserLoop == true); //keeps looping if admin does not enter a valid choice

        }//end of Manage users----------------------------------------------





        //View all users----------------------------------------------------------- Katie

        public static void ViewUsers()
        {
            //runs a for each loop that displays all of the user accounts in the application

            Console.Clear();

            Console.WriteLine("\t\tAdministrator panel - Viewing all users\n");

            foreach (User users in User.users) //traverses through entire user list
            {
                //method called from user class
                users.DisplayUserDetails();
            }

            Console.WriteLine("\nPress any key to return to Manage Users");
            Console.ReadKey();
            ManageUsers();

        }//end of View User class-----------------------------------------------


        //View all users-----------------------------------------------------------

        public static void ViewExpenses()
        {
            //runs a for each loop that displays all of the user accounts in the application

            Console.Clear();

            Console.WriteLine("\t\tAdministrator panel - Viewing all users\n");

            foreach (Expenses Exp in Expenses._expenses) //traverses through entire user list
            {
                //method called from user class
                Exp.AdminViewExpenses();
            }

            Console.WriteLine("\nPress any key to return to Manage Users");
            Console.ReadKey();
            ManageUsers();

        }//end of View Expenses class-----------------------------------------------



        //View all savings-------------------------------------------------------------- Katie
        public static void ViewSavings()
        {
            //runs a for each loop that displays all of the user savings in the application

            Console.Clear();

            Console.WriteLine("\t\tAdministrator panel - Viewing all savings\n");

            foreach (Savings sav in Savings._savings) //traverses through entire savings list
            {
                //method called from savings class
                sav.AdminViewSavings();
            }

            Console.WriteLine("\nPress any key to return to Manage Users");
            Console.ReadKey();
            ManageUsers();

        }//end of View Savings class-----------------------------------------------



        //Admin add user-------------------------------------------- Katie
        public static void AdminAddUser()
        {
            //lets admin add a new user account

            Console.Clear();

            Console.WriteLine("\t\tAdministrator panel - Adding new user\n");

            bool pwVerify = false;

            Console.WriteLine("Enter the user's first name:");
            string firstNameEntered = Console.ReadLine();

            Console.WriteLine("Enter the user's last name:");
            string lastNameEntered = Console.ReadLine();

            Console.WriteLine("Enter their username:");
            string userNameEntered = Console.ReadLine();

            Console.WriteLine("Enter their password:");
            string passwordEntered = null;

            while (true) //while loop obfuscates password when the user is typing it
            {

                ConsoleKeyInfo ck = Console.ReadKey(true);
                if (ck.Key != ConsoleKey.Enter)
                {
                    if (ck.Key != ConsoleKey.Backspace)
                    {
                        passwordEntered += ck.KeyChar.ToString();
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write("\b \b");
                    }//end of if else
                }
                else
                {
                    Console.WriteLine();

                    break;
                }//end of if else

            }//end of while


            //Do-While loop for confirming password
            do
            {

                Console.WriteLine("Re-enter password:");
                string reEnteredPasswordEntered = null;

                while (true) //while loop obfuscates password when the user is typing it
                {

                    ConsoleKeyInfo ck = Console.ReadKey(true);
                    if (ck.Key != ConsoleKey.Enter)
                    {
                        if (ck.Key != ConsoleKey.Backspace)
                        {
                            reEnteredPasswordEntered += ck.KeyChar.ToString();
                            Console.Write("*");
                        }
                        else
                        {
                            Console.Write("\b \b");
                        }//end of if else
                    }
                    else
                    {
                        Console.WriteLine();

                        break;
                    }//end of if else

                }//end of while

                if (passwordEntered == reEnteredPasswordEntered)
                {
                    Console.WriteLine("\nAccount successfully created!\n");

                    pwVerify = true;
                }
                else
                {
 
                    Console.WriteLine("\nPasswords do not match, please re-enter password.\n");

                }//end of if-else

            } while (pwVerify == false);
            //end of do-while

            //asks admin to enter an amount into savings for the user
            Console.WriteLine("Enter savings amount");
            double savings = Convert.ToDouble(Console.ReadLine());

            //adds a new object to the user list with the entered details
            User newUser = new User(firstNameEntered, lastNameEntered, userNameEntered, passwordEntered);
            User.users.Add(newUser);

            Savings newSavings = new Savings(savings, userNameEntered);
            Savings._savings.Add(newSavings);

            Console.WriteLine("\nPress any key to return to Manage Users");
            Console.ReadKey();

            ManageUsers();

        }//end of Admin Add User ------------------------------------------------------------------




        //Update user------------------------------------------------------ Katie

        public static void AdminUpdateUser()
        {
            //lets admin update user details of existing users
            Console.Clear();

            Console.WriteLine("\t\tAdministrator panel - Update user details\n");

            //calls method from user class
            User.UpdateDetails();

            Console.WriteLine("\nPress any key to return to Manage Users.");

            Console.ReadKey();

            ManageUsers();


        }//end of Admin Update User ----------------------------------------





        //Remove user------------------------------------------------------- Katie

        public static void AdminRemoveUser()
        {
            //lets admin remove existing users from the application

            Console.Clear();

            Console.WriteLine("\t\tAdministrator panel - Remove user\n");

            //calls method from user class
            User.RemoveUser();

            Console.WriteLine("\nPress any key to return to Manage Users.");

            Console.ReadKey();

            ManageUsers();


        }//end of Remove User-----------------------------------------------





        //Method to pre-load admin accounts into program--------------------- Katie
        public static void PreLoadAdmins()
        {
            Admin admin1 = new Admin("admin", "password");
            Admin admin2 = new Admin("a", "pw");

            admins.Add(admin1);
            admins.Add(admin2);
        }//end of PreLoad Admins----------------------------------------------





    }//end of Admin-----------------------------------------------------------------------------------------------------------------------------------------------------
}
