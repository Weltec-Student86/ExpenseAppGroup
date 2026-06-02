using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ExpenseAppGroup
{
    public class User : Account
    {



        //constructors

        public User(string firstName, string lastName, string username, string password)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Username = username;
            this.Password = password;

        }

        //List and objects

        public static List<User> users = new List<User>();


    
        
        //METHODS


        //Menu for login --------------------------------------
        public static void UserLogin()
        {
            Console.Clear();

            bool userLoginScreen = false;
            bool loginVerify = false;
            bool usernameVerify = false;


            do
            {
               
                Console.WriteLine("Enter your username:");
                string userNameEntered = Console.ReadLine();

                Console.WriteLine("Enter your password:");
                string passwordEntered = Console.ReadLine();

               User userFound = users.Find(u => u.Username.Equals(userNameEntered, StringComparison.Ordinal));

                if (userFound != null && userFound.Password == passwordEntered)
                {
                    Console.WriteLine("Login Success! Press any key to continue...");
                    Console.ReadKey();
                    userLoginScreen = false;
                    UserHome();
                }
                else
                {
                    Console.WriteLine("Wrong username or password. Try again.");

                    userLoginScreen = true;
                }

            } while (userLoginScreen == true);
          

        }//end of Login method----------------------------------





        //user Registration method-----------------------------
        public static void Register()
        {
            Console.Clear();

            bool pwVerify = false;
              
                Console.WriteLine("Enter your first name:");
                string firstNameEntered = Console.ReadLine();

                Console.WriteLine("Enter your last name:");
                string lastNameEntered = Console.ReadLine();

                Console.WriteLine("Enter your username:");
                string userNameEntered = Console.ReadLine();

                Console.WriteLine("Enter your password:");
                string passwordEntered = Console.ReadLine();

              

            //Do-While loop for confirming password
            do
            {

                Console.WriteLine("Re-enter password:");
                string reEnteredPasswordEntered = Console.ReadLine();

                if (passwordEntered == reEnteredPasswordEntered)
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

            Console.WriteLine("enter savings amount");
            double savings = Convert.ToDouble(Console.ReadLine());

            User newUser = new User(firstNameEntered, lastNameEntered, userNameEntered, passwordEntered);
            users.Add(newUser);

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            

            Program.LandingPage();

        }//end of Register method---------------------------------------




        //User home-----------------------------------------------------
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
                        Console.WriteLine();
                        Expenses.AddExpense();
                        break;

                    case 3:
                        Console.WriteLine("Update existing expense");
                        break;

                    case 4:
                        Console.WriteLine("Remove expense");
                        break;

                    case 5:
                        Console.WriteLine("View savings");
                        Savings.SavingsMenu();
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

                }//end of switch---------------------------------------

            } while (userHomeLoop == true) ; //do while loop to re-run user home menu

            
            
        }//end of UserHome-------------------------------------------------------






        //Display user details------------------------------------------------
        public void DisplayUserDetails()
        {
           

            Console.WriteLine($"First name: {FirstName}");
            Console.WriteLine($"Last name: {LastName}");
            Console.WriteLine($"Username: {Username}");
            Console.WriteLine();
        }//end of Display user details----------------------------------------


        //method to Pre-load users into the list upon application startup

        public static void PreLoadUsers()
        {
           
            User exampleUser0 = new User("user", "default", "user", "password");
            User exampleUser1 = new User("John", "Smith", "johnsmith7", "password1");
            User exampleUser2 = new User("Louis", "Jones", "lj1978", "password2");
            User exampleUser3 = new User("Peter", "Jones", "p_man", "password3");
            User exampleUser4 = new User("Michelle", "Peterson", "mrs_michelle", "password4");
            User exampleUser5 = new User("Jimmy", "Donaldson", "mrbeast", "password5");

            Console.Clear();


            users.Add(exampleUser1);
            users.Add(exampleUser2);
            users.Add(exampleUser3);
            users.Add(exampleUser4);
            users.Add(exampleUser5);

        }//end of pre load users-----------------------------




    }//end of class---------------------------------------------------------------------------------------------
}//end of namespace---------------------------------------------------------------------------------------------
