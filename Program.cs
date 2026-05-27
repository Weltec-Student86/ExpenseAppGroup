namespace ExpenseAppGroup
{
    internal class Program
    {
        static void Main(string[] args)

        {

            LandingPage();




        }//end of main-----------------------------------------------------------------------------------------------------------------------------------


        //Method for Home page
        public static void LandingPage()
        {
            Console.Clear();

            //declaring varaibles
            int choice;

            //do { }

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
                    Register();
                    break;

                case 3:
                    Console.WriteLine("Admin login");
                    AdminLogin();
                    break;

                case 4:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Enter a valid option");
                    break;
            }

            //}
            //  while ()



        }








        public static void Register()
        {
            Console.Clear();

            Console.WriteLine("Enter your first name:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter your last name:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Enter your date of birth:");
            string dob = Console.ReadLine();

            Console.WriteLine("Enter your username:");
            string userName = Console.ReadLine();

            Console.WriteLine("Enter your password:");
            string password = Console.ReadLine();

            Console.WriteLine("Re-enter password:");
            string reEnteredPassword = Console.ReadLine();

            if (password == reEnteredPassword)
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine("Passwords do not match");
            }

        }//end of Register method

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

      




    }//end of class program---------------------------------------------------------------------------------------------------------------------------------------------------

}//end of namespace------------------------------------------------------------------------------------------------------------------------------
