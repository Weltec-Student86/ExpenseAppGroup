using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ExpenseAppGroup
{
    public class Savings
    {
        //fields
        private string userName;
        private string goals;
        private double amountGoals;
        private double savings;

        public string savGoals { get; set; }
        public double amtGoals { get; set; }
        public double savingsAmt { get; set; }
        public string UserName { get; set; }


        public static List<Savings> _savings = new List<Savings>();
        public static List<Savings> _goals = new List<Savings>();

        //Construtor for pre added user goals
        public Savings(string name, double amount, string user)
        {
            savGoals = name;
            amtGoals = amount;
            UserName = user;

        }
        //Construtor for pre added user savings
        public Savings(double amtSavings, string user)
        {
            amtSavings = savings;
            UserName = user;

        }

        //Method for Savings menu-----------------------------------1
        public static void SavingsMenu(string currentLoggedInUser)
        {

            bool savingsMenuLoop = false;
            Console.Clear();
            //do while loop incase user enters wrong number
            do
            {
                //menu options for savings

                Console.WriteLine("\t View Savings");
                Console.WriteLine();

                Console.WriteLine("Savings: {Users Savings}");
                Console.WriteLine();

                Console.WriteLine("Goals:");
                Console.WriteLine("{Users goals}");
                Console.WriteLine("{Users goals}");
                Console.WriteLine();

                Console.WriteLine("1. Add new goal");
                Console.WriteLine("2. Add to savings");
                Console.WriteLine("3. Update to goals");
                Console.WriteLine("4. Remove goal");
                Console.WriteLine("5. Back home");
                Console.WriteLine("99. Exit");

                Console.WriteLine("Please select an option:");
                int savingsChoice = Convert.ToInt32(Console.ReadLine());


                switch (savingsChoice) 
                {
                    case 1:
                        Console.WriteLine("Add new goal");
                        Savings.AddGoals();
                        Console.WriteLine();

                        break; 

                    case 2:
                        Console.WriteLine("Add to savings");
                        Savings.AddSavings();
                        Console.WriteLine();
                        
                        break;

                    case 3:
                        Console.WriteLine("Update Goals");
                        Savings.UpdateGoals();
                        break;

                    case 4:
                        Console.WriteLine("Remove Goals");
                        Savings.RemoveGoals();
                        break;

                    case 5:
                        Console.WriteLine("Back home");
                        User.UserHome();
                        break;

                    case 99:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Enter a valid option!\n");
                        Console.WriteLine("Press any key to return to savings menu...");
                        Console.ReadKey();
                        Console.Clear();
                        savingsMenuLoop = true;
                     break;


                }//end of switch---------------------------------------

            }while (savingsMenuLoop == true);

        }//end of savings menu method---------------------------------------1


        //Method for Adding goals-------------------------------------------2
        public static void AddGoals()
        {
            Console.Clear();

            int exitAddGoalsChoice1 = 1;
            //do while loop to exit to home
            do
            {


                //users goals and savings they have created this will need to be changed
                Console.WriteLine("Add Goal");
                double goal = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine();

                Console.WriteLine("Goals:");
                string goals = Console.ReadLine();

                Console.WriteLine("1. Back to savings menu");
                exitAddGoalsChoice1 = Convert.ToInt32(Console.ReadLine());



            } while (exitAddGoalsChoice1 == 0);
            Savings.SavingsMenu(User.CurrentLoggedInUser);

        }//end of Method for Adding goals---------------------------------------2

        //Method for adding to savings ---------------------------------------3
        public static void AddSavings()
        {
            Console.Clear();

            int exitAddSavingChoice1 = 1;
            //do while loop to exit to home
            do
            {


                //users goals and savings they have created this will need to be changed
                Console.WriteLine("Add savings");
                double savings = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine();

                string goals = Console.ReadLine();

                Console.WriteLine("1. Back to savings menu");
                exitAddSavingChoice1 = Convert.ToInt32(Console.ReadLine());



            } while (exitAddSavingChoice1 == 0);
            Savings.SavingsMenu(User.CurrentLoggedInUser);

        }//end of Method for adding to savings-------------------------------3

        //Method for Removing goals-----------------------------4
        public static void RemoveGoals()
        {
            Console.Clear();

            int exitRemoveGoalsChoice1 = 1;
            //do while loop to exit to home
            do
            {


                //users goals and savings they have created this will need to be changed
                Console.WriteLine("Remove Goal");
                double goal = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine();

                Console.WriteLine("1. Back to savings menu");
                exitRemoveGoalsChoice1 = Convert.ToInt32(Console.ReadLine());



            } while (exitRemoveGoalsChoice1 == 0);
            Savings.SavingsMenu(User.CurrentLoggedInUser);

        }//end of Method for Removing goals-------------------------4

        //Method for updating goals -----------------------------------------------5
        public static void UpdateGoals()
        {
            Console.Clear();

            int exitUpdateGoalsChoice1 = 1;
            //do while loop to exit to home
            do
            {


                //users goals and savings they have created this will need to be changed
                Console.WriteLine("Update you goals");
                double savings = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine();

                Console.WriteLine("Goals:");
                Console.WriteLine("place holders {Users goals}");
                Console.WriteLine("place holders {Users goals}");
                Console.WriteLine();
                Console.WriteLine("Select the goal you would like to update");
                string goals = Console.ReadLine();

                Console.WriteLine("1. Back to savings menu");
                exitUpdateGoalsChoice1 = Convert.ToInt32(Console.ReadLine());



            } while (exitUpdateGoalsChoice1 == 0);
            Savings.SavingsMenu(User.CurrentLoggedInUser);

        }//end of Method for updating goals----------------------------------------5

        //method for PreaAdded users goals----------------------------------------6
        public static void PreaddedUserGoals()
        {
            //adds objects to the list

            _goals.Add(new Savings
            ("trip", 1400, "johnsmith7")
            );

            _goals.Add(new Savings
            ("trip", 11, "lj1978")
            );

            _goals.Add(new Savings
            ("trip", 666, "p_man")
            );

            _goals.Add(new Savings
            ("trip", 14, "mrs_michelle")
            );

            _goals.Add(new Savings
            ("trip", 25, "mrbeast")
            );

        }//end of PreAddeded users Goals method--------------------------6


        //method for PreaAdded users savings----------------------------------------7
        public static void PreaddedUserSavings()
        {
            //adds objects to the list

            _savings.Add(new Savings
            ( 1400, "johnsmith7")
            );

            _savings.Add(new Savings
            ( 11, "lj1978")
            );

            _savings.Add(new Savings
            ( 666, "p_man")
            );

            _savings.Add(new Savings
            ( 14, "mrs_michelle")
            );

            _savings.Add(new Savings
            (11, "mrbeast")
            );

        }//end of PreAddeded users savings method--------------------------7


    }//end of class savings---------------------------------------
}//end of namespace-----------------------------------------------
