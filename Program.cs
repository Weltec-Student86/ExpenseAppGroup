namespace ExpenseAppGroup
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //this method pre-loads admins and users into the lists upon the program starting
            Admin.PreLoadAdmins();
            User.PreLoadUsers();
            Savings.PreaddedUserSavings();
            Savings.PreaddedUserGoals();
            Expenses.PreaddedUserExpenses();

            //calling login menus
            LandingPage();

        }//end of main-----------------------------------------------------------------------------------------------------------------------------------


        //Method for Home page
        public static void LandingPage()
        {
            Console.Clear();

           

            //declaring varaibles
            int choice;
            bool landingPageLoop = false;

            //sorts lists alphabetically by username
            
            User.users.Sort((s1, s2) => s1.Username.CompareTo(s2.Username));
            Expenses._expenses.Sort((s1, s2) => s1.UserName.CompareTo(s2.UserName));
            Savings._savings.Sort((s1, s2) => s1.UserName.CompareTo(s2.UserName));
            Savings._goals.Sort((s1, s2) => s1.UserName.CompareTo(s2.UserName));

            do
            {
                    try
                    {

                        Console.WriteLine("\t\t****** Welcome to the Expense App ******");
                        Console.WriteLine("-------------------------------------------------------------------------------\n");
                        Console.WriteLine("\t\tLogin or Register for an account");
                        Console.WriteLine();
                        Console.WriteLine("1. Login");
                        Console.WriteLine("2. Register");
                        Console.WriteLine("3. Administrator Login");
                        Console.WriteLine("99. Exit");
                        Console.WriteLine("\nPlease select a choice");


                        choice = Convert.ToInt32(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                User.UserLogin();
                                break;

                            case 2:
                                User.Register();
                                break;

                            case 3:
                                Admin.AdminLogin();
                                break;

                            case 99:
                                Environment.Exit(0);
                                break;

                            default:
                                Console.Clear();
                                Console.WriteLine("Enter a valid option!\n");
                                Console.WriteLine("Press any key to return to main page...");
                                Console.ReadKey();
                                Console.Clear();
                                landingPageLoop = true;
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
                        LandingPage();
                    }


            }//end of do
            while (landingPageLoop == true);
            

        }//end of Landing Page----------------------------------






    }//end of class program---------------------------------------------------------------------------------------------------------------------------------------------------

}//end of namespace------------------------------------------------------------------------------------------------------------------------------
