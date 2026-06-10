using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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
            this.amtSavings = amtSavings;
            this.UserName = user;

        }

     
       
        //Method for Savings menu-----------------------------------1
        public static void SavingsMenu(string currentLoggedInUser)
        {

            bool savingsMenuLoop = false;

            //sorts lists alphabetically by username

            //sorts lists by username so they are always in order
            User.users.Sort((s1, s2) => s1.Username.CompareTo(s2.Username));
            Expenses._expenses.Sort((s1, s2) => s1.UserName.CompareTo(s2.UserName));
            Savings._savings.Sort((s1, s2) => s1.UserName.CompareTo(s2.UserName));
            Savings._goals.Sort((s1, s2) => s1.UserName.CompareTo(s2.UserName));

            Console.Clear();
            //do while loop incase user enters wrong number
            do
            {
                try 
                { 
                    //menu options for savings
                    //Get expenses for calculation
                    double totalExpenses = Expenses._expenses
                        .Where(e => e.UserName == currentLoggedInUser)
                        .Sum(e => e.ExpAmount);

                    //Gets Savings for the user
                    var userSavings = Savings._savings.FirstOrDefault(s => s.UserName == currentLoggedInUser);
                    double currentSavings = (userSavings != null) ? userSavings.amtSavings : 0;

                    //Gets Goals for the user
                    var goalEntry = _goals.Where(g => g.UserName == currentLoggedInUser);
                    var totalGoals = goalEntry.Sum(x => x.amtGoals);
                    

                    //Does the calculation: Savings - Expenses then check its with Goal
                    double newTotal = currentSavings - totalExpenses;

                    Console.WriteLine($"\t--- Savings Summary for {currentLoggedInUser} ---");
                    Console.WriteLine("---------------------------------------\n");
                    Console.WriteLine();

                    Console.WriteLine($"Total Expenses: ${totalExpenses}");
                    Console.WriteLine($"Current Savings: ${currentSavings}");
                    Console.WriteLine($"New Total (Savings - Expenses): ${newTotal}");
                    Console.WriteLine($"Target Goal Amount: ${totalGoals}");

                    


                    //If statment to check user has added goals if they havent displays message
                    if (goalEntry == null)
                    {
                        Console.WriteLine($"No goals added");

                    }
                    else
                    {
                        if (newTotal >= totalGoals)
                        {
                            Console.WriteLine("Status: You are on track to meet your goal!");
                        }
                        else
                        {
                            Console.WriteLine($"Status: You need ${totalGoals - newTotal} more to reach your goal.");
                        }

                    }

                    Console.WriteLine();
                    Console.WriteLine("---------------------------------------\n");
                    Console.WriteLine("1. Add new goal");
                    Console.WriteLine("2. View goals");
                    Console.WriteLine("3. Update savings total");
                    Console.WriteLine("4. Update to goals");
                    Console.WriteLine("5. Remove goal");
                    Console.WriteLine("6. Back home");
                    Console.WriteLine("99. Exit");

                        Console.WriteLine("Please select an option:");
                        int savingsChoice = Convert.ToInt32(Console.ReadLine());


                    switch (savingsChoice) 
                    {
                        case 1:
                            Console.WriteLine("Add New Goal");
                            Savings.AddGoals();
                            Console.WriteLine();

                                break;

                        case 2:
                            Console.WriteLine("View Goals");
                            ViewGoals(currentLoggedInUser);
                            break;


                        case 3:
                            Console.WriteLine("Update To Savings");
                            UpdateSavings(currentLoggedInUser);
                            Console.WriteLine();
                        
                                break;

                            case 4:
                                Console.WriteLine("Update Goals");
                                Savings.UpdateGoals();
                                break;

                            case 5:
                                Console.WriteLine("Remove Goals");
                                Savings.RemoveGoals(currentLoggedInUser);
                                break;

                        case 6:
                            Console.WriteLine("Back To Home");
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

                }//end of try
                catch (FormatException ex)
                {
                    Console.WriteLine();
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please enter a valid number.\n");
                    Console.WriteLine("Press any key to contine...");
                    Console.ReadKey();
                    SavingsMenu(currentLoggedInUser);
                }

            } while (savingsMenuLoop == true);

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
                Console.WriteLine("---------------------------------------\n");

                Console.WriteLine("Add Goal Name:");
                string savGoals = Console.ReadLine();

                Console.WriteLine("Add Goal Amount:");
                double amtGoals = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("1. Back To Savings Menu");
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
                Console.WriteLine($"\t Update {currentLoggedInUser} Savings\n");
                Console.WriteLine("---------------------------------------\n");
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

            Savings.SavingsMenu(User.CurrentLoggedInUser);

        }//end of update savings --------------------------------------3





        //Method for Removing goals-----------------------------4
        public static void RemoveGoals(string currentLoggedInUser)
        {
            Console.Clear();

            int exitRemoveGoalsChoice1 = 1;
            //do while loop to exit to home
            do
            {
                Console.WriteLine("\tRemove Goals Menu");
                Console.WriteLine("---------------------------------------\n");

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
                    Console.Clear();

                    Console.WriteLine("\t Update Goals Menu");
                    Console.WriteLine("---------------------------------------\n");
                    Console.WriteLine();

                    Console.WriteLine("\t Enter the name of the Goal you wish to update");



                    string removeGoal = Console.ReadLine();

                    //the variable is then passed through the list to find a matching account
                    Savings removeGoalsfound = _goals.Find(g => g.savGoals.Equals(removeGoal, StringComparison.Ordinal));

                    //if-else statement to confirm if the user wants to update selected expense

                    if (removeGoalsfound != null)
                    {
                        Console.WriteLine($"\nThe expensel {removeGoalsfound.savGoals} will be updated.");
                        Console.WriteLine("\nAre you sure you want to update this expense? (y/n)\n");

                        char removeConfirm = Convert.ToChar(Console.ReadLine());


                        if (removeConfirm == 'y') //removes the users Expense
                        {

                            _goals.Remove(removeGoalsfound);

                            Console.Clear();

                            Console.WriteLine("\tUpdated Goals\n");

                            Console.WriteLine("Updated goal name:");
                            string savGoals = Console.ReadLine();

                            Console.WriteLine("Updated goal amount:");
                            double amtGoals = Convert.ToDouble(Console.ReadLine());

                            Savings newGoal = new Savings(savGoals, amtGoals, User.CurrentLoggedInUser);
                            _goals.Add(newGoal);
                            Console.WriteLine("\nExpense removed.\n");


                        }
                        else //cancels removal
                        {
                            Console.WriteLine("\nUpdated canceled.\n");
                        }

                    }
                    else
                    {
                        Console.WriteLine("\nGoal not found. Press any key to continue...");
                        Console.ReadKey();
                    }

                } while (exitUpdateGoalsChoice1 == 0);
                    Savings.SavingsMenu(User.CurrentLoggedInUser);

        }//end of Method for updating goals----------------------------------------5


        public static void ViewGoals(string currentLoggedInUser)
        {
            Console.Clear();


            int exitAddExpenseChoice1 = 1;
            //do while loop to exit to home
            do
            {
                var userGoals = _goals.Where(e => e.UserName == currentLoggedInUser).ToList();

                Console.WriteLine($"\t View Expenses Menu\n");
                Console.WriteLine($"\tWelcome {currentLoggedInUser}\n");
                Console.WriteLine("---------------------------------------\n");
                Console.WriteLine();

                //users expenses 
                if (userGoals.Count == 0)
                {
                    Console.WriteLine($"No Goals Added");

                }
                else
                {
                    foreach (var e in userGoals)
                    {
                        Console.WriteLine($"Name: {e.savGoals} Amount: ${e.amtGoals}");
                    }

                }
                Console.WriteLine("\n1. Back To Savings");
                exitAddExpenseChoice1 = Convert.ToInt32(Console.ReadLine());


            } while (exitAddExpenseChoice1 == 0);
            SavingsMenu(currentLoggedInUser); //returns back to savings page

        }//end of ViewExpense method-----------------------------------------------------------------------------------------------------------------------6


        public void AdminViewSavings()
        {
            Console.Clear();

            int exitAddExpenseChoice1 = 1;
            //do while loop to exit to home
            do
            {
                Console.WriteLine($"\t Admin Menu For Display Savings\n");
                Console.WriteLine("---------------------------------------\n");
                Console.WriteLine();

                //users expenses 
                if (_savings.Count == 0)
                {
                    Console.WriteLine($"No savings added");
                }
                else
                {
                    foreach (Savings s in _savings)

                        Console.WriteLine($"Username: {s.UserName}\n Savings amount: {s.amtSavings} \n");

                }
                Console.WriteLine("1. Back To Home");
                exitAddExpenseChoice1 = Convert.ToInt32(Console.ReadLine());

            } while (exitAddExpenseChoice1 == 0);
            Admin.AdminHome();

        }//end of ViewSavings method--------------------------1
     
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
            (100000000, "mrbeast")
            );

        }//end of PreAddeded users savings method--------------------------7


    }//end of class savings---------------------------------------
}//end of namespace-----------------------------------------------
