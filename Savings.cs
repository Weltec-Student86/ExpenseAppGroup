using Microsoft.VisualBasic;
using System;
using System.Collections;
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
        private double totalAmountGoals;
        //private static double amtSavings;
        public string savGoals { get; set; }
        public double amtGoals { get; set; }
        public double amtSavings { get; set; }
        public string UserName { get; set; }
        public double amountToAdd { get; set; }
      

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
            savings = amtSavings;
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


                var userSavings = _savings.Where(e => e.UserName == currentLoggedInUser).ToList();
                var userGoals = _goals.Where(e => e.UserName == currentLoggedInUser).ToList();
                Console.WriteLine($"\t Display Savings\n");
                Console.WriteLine();
                Console.WriteLine($"\tWelcome {currentLoggedInUser}\n");
                //users savings displayed on home page
                if (_savings.Count == 0)
                {
                    Console.WriteLine($"No savings added");
                }
                else
                {
                    foreach (var e in userSavings)
                        Console.WriteLine($"\tCurrent Samings: {e.savings}");

                }

                if (_goals.Count == 0)
                {
                    Console.WriteLine($"No goals added");
                }
                else
                {
                    foreach (var e in userGoals)
                        Console.WriteLine($"Saving goal: {e.savGoals}\nSavings goal amount: {e.amtGoals}\n");

                }
                Console.WriteLine("1. Add new goal");
                Console.WriteLine("2. Update savings total");
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
                        Console.WriteLine("Update to savings");
                        UpdateSavings(currentLoggedInUser);
                        Console.WriteLine();
                        
                        break;

                    case 3:
                        Console.WriteLine("Update Goals");
                        Savings.UpdateGoals();
                        break;

                    case 4:
                        Console.WriteLine("Remove Goals");
                        Savings.RemoveGoals(currentLoggedInUser);
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
                Console.WriteLine("\t Add New Goal\n");

                Console.WriteLine("Add Goal name:");
                string savGoals = Console.ReadLine();

                Console.WriteLine("Add Goal amount:");
                double amtGoals = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("1. Back to savings menu");
                exitAddGoalsChoice1 = Convert.ToInt32(Console.ReadLine());

                Savings newGoal = new Savings(savGoals, amtGoals, User.CurrentLoggedInUser);
                _goals.Add(newGoal);

            } while (exitAddGoalsChoice1 == 0);
            Savings.SavingsMenu(User.CurrentLoggedInUser);

        }//end of Method for Adding goals---------------------------------------2


        //method for updating savings --------------------------------------3
        public static void UpdateSavings(string currentLoggedInUser)
        {
            int exitUpdateSavingChoice1 = 1;
            
            do
            {
                var userSavings = _savings.Where(e => e.UserName == currentLoggedInUser);
                var savingsEntry = _savings.FindIndex(s => s.UserName == currentLoggedInUser);
                
                if (savingsEntry > -1)
                {
                    Console.WriteLine("Enter your new total savings amount:");
                    double amountToAdd = Convert.ToDouble(Console.ReadLine());

                    _savings.RemoveAt(savingsEntry);

                    //Console.WriteLine(savingsEntry);

                    Savings updatedSavings = new Savings(amountToAdd, currentLoggedInUser);
                    _savings.Insert(savingsEntry, updatedSavings);

                }
                else
                {
                    Console.WriteLine("No savings found. Press any key to continue...");
                    exitUpdateSavingChoice1 = 0;
                }


                foreach (var e in userSavings)
                {
                    Console.WriteLine($"\tCurrent Savings: {e.savings}");
                }

            }//end of do
            while (exitUpdateSavingChoice1 == 0);

        }//end of update savings --------------------------------------3





        //Method for Removing goals-----------------------------4
        public static void RemoveGoals(string currentLoggedInUser)
        {
            Console.Clear();

            int exitRemoveGoalsChoice1 = 1;
            //do while loop to exit to home
            do
            {

                //searches the name of the user they wish to remove
                Console.WriteLine("Enter the Goal you want to remove:");
                string removeGoal = Console.ReadLine();

                //the variable is then passed through the list to find a matching account
                Savings removeGoalfound= _goals.Find(e => e.savGoals.Equals(removeGoal, StringComparison.Ordinal));

                //if-else statement to confirm if admin wants to remove the user account
                if (removeGoalfound != null)
                {
                    Console.WriteLine($"\nThe goal {removeGoalfound.goals} will be removed.");
                    Console.WriteLine("\nAre you sure you want to remove this goal? (y/n)\n");

                    char removeConfirm = Convert.ToChar(Console.ReadLine());


                    if (removeConfirm == 'y') //removes user
                    {
                        _goals.Remove(removeGoalfound);
                        Console.WriteLine("\nGoal removed.\n");

                    }
                    else //cancels removal
                    {
                        Console.WriteLine("\nRemove canceled.\n");
                    }

                }
                else //displays if the name entered is not on the list
                {
                    Console.WriteLine("\nGoal does not exist.\n");

                }




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
            ("trip", 250, "johnsmith7")
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
            (100.000000, "mrbeast")
            );

        }//end of PreAddeded users savings method--------------------------7


    }//end of class savings---------------------------------------
}//end of namespace-----------------------------------------------
