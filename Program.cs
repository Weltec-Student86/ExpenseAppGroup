namespace ExpenseAppGroup
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //this method pre-loads users into the list upon the program starting
            User.PreLoadUsers();

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

            do {
                

                Console.WriteLine("\t******Welcome to the Expense App*******");
                Console.WriteLine("\t Login or Register for an account");
                Console.WriteLine();
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Administrator Login");
                Console.WriteLine("99. Exit");
                Console.WriteLine("Please select a choice");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Login");
                        Console.WriteLine();
                        User.UserLogin();
                        break;

                    case 2:
                        Console.WriteLine("Register");
                        Console.WriteLine();
                        User.Register();
                        break;

                    case 3:
                        Console.WriteLine("Admin login");
                        Admin.AdminLogin();
                        break;

                    case 99:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Enter a valid option!\n");
                        Console.WriteLine("Press any key to return to login page...");
                        Console.ReadKey();
                        Console.Clear();
                        landingPageLoop = true;
                        break;
                }
          
            }
            while (landingPageLoop == true);

        }//end of Landing Page----------------------------------






    }//end of class program---------------------------------------------------------------------------------------------------------------------------------------------------

}//end of namespace------------------------------------------------------------------------------------------------------------------------------
