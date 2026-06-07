using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Security;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ExpenseAppGroup
{
    public class User : Account
    {
        //variables

        //passing name of user to multiple methods - this is used to display the username on the home screen
        public static string name = "";
        public static int accountIndex;
        private static string password = "";
        

        public static string CurrentLoggedInUser {  get; set; }
        //constructors

        public User(string firstName, string lastName, string username, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;
        }

        //List for user accounts

        public static List<User> users = new List<User>();


    
        
        //METHODS


        //Menu for login --------------------------------------
        public static void UserLogin()
        {
            Console.Clear();

            bool userLoginScreen = false;
            bool loginVerify = false;
            bool usernameVerify = false;

            

            //goes through a do-while loop until correct credentials are entered
            do
            {
                
                    Console.WriteLine("\t\tLogin");
                    Console.WriteLine("---------------------------------------\n");

                    //username
                    Console.WriteLine("Enter your username:");
                    string userNameEntered = Console.ReadLine();

                    //passes username into class name variable so it can be displayed on the home screen

                    User.name = userNameEntered;


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
                        User.CurrentLoggedInUser = userNameEntered;
                    }//end of while


                    //searches user list for correct username

                    User userFound = users.Find(u => u.Username.Equals(userNameEntered, StringComparison.Ordinal));

                    //if else statement checks if the username and password match
                    if (userFound != null && userFound.Password == passwordEntered)
                    {
                        int index = users.FindIndex(a => a.Username.Equals(userNameEntered, StringComparison.Ordinal));
                        User.accountIndex = index;

                        Console.WriteLine("\nLogin Success! \nPress any key to continue...");
                        Console.ReadKey();
                        userLoginScreen = false;
                        UserHome(); //takes user to the Home menu if correct credentials are entered
                    }
                    else
                    {
                        Console.WriteLine("\nWrong username or password. Try again.");

                        userLoginScreen = true; //makes user re-enter details if login is wrong

                    }//end of if-else


            } while (userLoginScreen == true); //end of do-while


        }//end of Login method----------------------------------





        //user Registration method-----------------------------
        public static void Register()
        {

                Console.Clear();

                bool pwVerify = false;

                Console.WriteLine("\t\tRegister");
                Console.WriteLine("---------------------------------------\n");

                //user enters account details for new account

                Console.WriteLine("Enter your first name:");
                string firstNameEntered = Console.ReadLine();

                Console.WriteLine("\nEnter your last name:");
                string lastNameEntered = Console.ReadLine();

                Console.WriteLine("\nEnter your username:");
                string userNameEntered = Console.ReadLine();

                Console.WriteLine("\nEnter your password:");
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

                    Console.WriteLine("\nRe-enter password:");
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
                        //if passwords match, account is successfully created
                    }
                    else
                    {
                        Console.WriteLine("\nPasswords do not match, please re-enter password.\n");
                        //if passwords don't match, the user has to re-enter the password to match
                    }//end of if-else

                } while (pwVerify == false);//end of do-while


                //once account is created, users have to enter an amount into their savings account
                Console.WriteLine("\nEnter savings amount:");
                double savings = Convert.ToDouble(Console.ReadLine());

                //creates new object with user details entered
                User newUser = new User(firstNameEntered, lastNameEntered, userNameEntered, passwordEntered);
                users.Add(newUser);

                Savings newSavings = new Savings(savings, userNameEntered);
                Savings._savings.Add(newSavings);

                Console.WriteLine("\nPress any key to continue...\n");
                Console.ReadKey();

                //takes user to the landing page once account is created, and they need to log in
                Program.LandingPage();

            }//end of Register method---------------------------------------




        //User home-----------------------------------------------------
        public static void UserHome()
        {
            int index = User.accountIndex;
            bool userHomeLoop = false;
            Console.Clear();


            do //do-while loop for user home menu options
            {
                try
                {
                    Console.WriteLine("\t\tHome");
                    Console.WriteLine("---------------------------------------\n");

                    Console.WriteLine("Welcome " + (User.name) + "!\n");
                    Console.WriteLine("Account number: " + (User.accountIndex) + "\n");

                    Console.WriteLine("1. View expenses");
                    Console.WriteLine("2. Add new expense");
                    Console.WriteLine("3. Update existing expense");
                    Console.WriteLine("4. Remove expense");
                    Console.WriteLine("5. View savings");
                    Console.WriteLine("6. Logout");
                    Console.WriteLine("99. Exit");

                    Console.WriteLine("\nPlease select an option:");
                    int homeChoice = Convert.ToInt32(Console.ReadLine());

                    switch (homeChoice) //switch statement that calls methods depending on the user's choice
                    {
                        case 1:
                            Expenses.ViewExpenses(User.CurrentLoggedInUser);
                            break;

                        case 2:
                            Expenses.AddExpense();
                            break;

                        case 3:
                            Expenses.UpdateExpense(User.CurrentLoggedInUser);
                            break;

                        case 4:
                            Expenses.RemoveExpense(User.CurrentLoggedInUser);
                            break;

                        case 5:
                            Savings.SavingsMenu(User.CurrentLoggedInUser);
                            break;

                        case 6:
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

                    }//end of switch

                }//end of try
                catch (FormatException ex)
                {
                    Console.WriteLine();
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please enter a valid number.\n");
                    Console.WriteLine("Press any key to contine...");
                    Console.ReadKey();
                    UserHome();
                }


            } while (userHomeLoop == true) ; //do while loop to re-run user home menu

            
            
        }//end of UserHome-------------------------------------------------------



        //Display user details------------------------------------------------
        public void DisplayUserDetails()
        {
            //displays details from the user list
            Console.WriteLine($"First name: {FirstName}");
            Console.WriteLine($"Last name: {LastName}");
            Console.WriteLine($"Username: {Username}\n");

        }//end of Display user details----------------------------------------






        //Update details functionality for admin---------------------------------------------------
        public static void UpdateDetails()
        {
            bool updateScreen = false;
            do
            {
                //asks admin to search the user they want to update details for
                Console.WriteLine("Enter the username of the user you wish to update details for:");
                string userNameUpdEntered = Console.ReadLine();

                //finds the user's corresponding index in the list
                int index = users.FindIndex(a => a.Username.Equals(userNameUpdEntered, StringComparison.Ordinal));

                if (index > -1) //checks if the user has been found or not (an index of -1 means the user has not been found)
                {
                    Console.WriteLine($"User found at index {index}\n");
                  

                    bool pwVerify = false;

                    Console.WriteLine("Enter their first name:");
                    string firstNameEntered = Console.ReadLine();

                    Console.WriteLine("Enter their last name:");
                    string lastNameEntered = Console.ReadLine();

                    Console.WriteLine("Enter their username:");
                    string userNameEntered = Console.ReadLine();

                    Console.WriteLine("Enter their password:");
                    string passwordEntered = Console.ReadLine();



                    //Do-While loop for confirming password
                    do
                    {

                        Console.WriteLine("Re-enter password:");
                        string reEnteredPasswordEntered = Console.ReadLine();

                        if (passwordEntered == reEnteredPasswordEntered)
                        {
                            Console.WriteLine("\nAccount successfully updated!\n");
                            pwVerify = true;
                        }
                        else
                        {
                            Console.WriteLine("\nPasswords do not match, please re-enter password.\n");
                        }

                    } while (pwVerify == false);

                    //removes old user details at that index
                    users.RemoveAt(index);

                    //adds updated details to same index of the removed user
                    User updatedUser = new User(firstNameEntered, lastNameEntered, userNameEntered, passwordEntered);
                    users.Insert(index, updatedUser);

                    updateScreen = false;
                }
                else //displays if the user does not exist in the list
                {
                    Console.WriteLine("\nUser does not exist. Try again.\n");

                    updateScreen = true;
                }//end of if-else


            } while (updateScreen == true);
            //end of do-while



        }//end of Update Details---------------------------------------------------------






        //Remove user functionality---------------------------------------------------------
        public static void RemoveUser()
        {
            //admin searches the name of the user they wish to remove
            Console.WriteLine("Enter the username of the user you want to remove:");
            string remUserNameEntered = Console.ReadLine();

            //the variable is then passed through the list to find a matching account
            User userRemFound = users.Find(u => u.Username.Equals(remUserNameEntered, StringComparison.Ordinal));
            Expenses userExpRemFound = Expenses._expenses.Find(u => u.UserName.Equals(remUserNameEntered, StringComparison.Ordinal));
            Savings userSavRemFound = Savings._savings.Find(u => u.UserName.Equals(remUserNameEntered, StringComparison.Ordinal));

            //if-else statement to confirm if admin wants to remove the user account
            if (userRemFound != null)
            {
                Console.WriteLine($"\nThe user {userRemFound.Username} will be removed.");
                Console.WriteLine("\nAre you sure you want to remove this user? (y/n)\n");

                char removeConfirm = Convert.ToChar(Console.ReadLine());


                if (removeConfirm == 'y') //removes user
                {
                    bool endRemoveLoop = false;
                    do
                    {
                        User userRemFound1 = users.Find(u => u.Username.Equals(remUserNameEntered, StringComparison.Ordinal));
                        Expenses userExpRemFound1 = Expenses._expenses.Find(u => u.UserName.Equals(remUserNameEntered, StringComparison.Ordinal));
                        Savings userSavRemFound1 = Savings._savings.Find(u => u.UserName.Equals(remUserNameEntered, StringComparison.Ordinal));

                        User.users.Remove(userRemFound1);

                        Savings._savings.Remove(userSavRemFound1);

                        Expenses._expenses.Remove(userExpRemFound1);

                        if (userRemFound1 != null && userExpRemFound1 != null && userSavRemFound1 != null)
                        {
                            endRemoveLoop = true;
                        }
                    }
                    while (endRemoveLoop == false);
                    Console.WriteLine("\nUser removed.\n");

                }
                else //cancels removal
                {
                    Console.WriteLine("\nRemove canceled.\n");
                }

            }
            else //displays if the name entered is not on the list
            {
                Console.WriteLine("\nUser does not exist.\n");

            }

        }//end of Remove User-----------------------------------------------------------------






        //method to Pre-load users into the list upon application startup------------------------

        public static void PreLoadUsers()
        {
           //creates objects
            User exampleUser0 = new User("user", "default", "user", "password");
            User exampleUser1 = new User("John", "Smith", "johnsmith7", "password1");
            User exampleUser2 = new User("Louis", "Jones", "lj1978", "password2");
            User exampleUser3 = new User("Peter", "Jones", "p_man", "password3");
            User exampleUser4 = new User("Michelle", "Peterson", "mrs_michelle", "password4");
            User exampleUser5 = new User("Jimmy", "Donaldson", "mrbeast", "password5");

            //adds objects to the list
            users.Add(exampleUser0);
            users.Add(exampleUser1);
            users.Add(exampleUser2);
            users.Add(exampleUser3);
            users.Add(exampleUser4);
            users.Add(exampleUser5);

        }//end of pre load users--------------------------------------------------------------



    }//end of class------------------------------------------------------------------------------------------------------------------------------------------------------------
}//end of namespace--------------------------------------------------------------------------------------------------------------------------------------
