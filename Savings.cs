using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ExpenseAppGroup //Damien was responsible for this class
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
      

        public static List<Savings> _savings = new List<Savings>();//list of pre added savings list
        public static List<Savings> _goals = new List<Savings>();//list of pre added goals list


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

        //Methods
     
       
        //Method for Savings menu----------------------------------------------------------------------------------1 Damien
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
                    if (totalGoals == 0)
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
                    Console.WriteLine("1. Update savings total");
                    Console.WriteLine("2. View goals");
                    Console.WriteLine("3. Add new goal");
                    Console.WriteLine("4. Update to goals");
                    Console.WriteLine("5. Remove goal");
                    Console.WriteLine("6. Back home");
                    Console.WriteLine("99. Exit");

                        Console.WriteLine("Please select an option:");
                        int savingsChoice = Convert.ToInt32(Console.ReadLine());

                    //(currentLoggedInUser); used to transport stored data across methods
                    switch (savingsChoice) 
                    {
                        case 1:
                            Console.WriteLine("Update To Savings");
                            UpdateSavings(currentLoggedInUser);
                            Console.WriteLine();
                            break;

                        case 2:
                            Console.WriteLine("View Goals");
                            ViewGoals(currentLoggedInUser);
                            break;


                        case 3:
                            Console.WriteLine("Add New Goal");
                            Savings.AddGoals();
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

        }//end of savings menu method------------------------------------------------------------------------------1


        //Method for Adding goals-----------------------------------------------------------------2 Damien
        public static void AddGoals()
        {
            Console.Clear();

            
                //Allows user to enter a new goal and then stores it in list
                Console.WriteLine("\t Add New Goal\n");
                Console.WriteLine("---------------------------------------\n");

                Console.WriteLine("Add Goal Name:");
                string savGoals = Console.ReadLine();

                Console.WriteLine("Add Goal Amount:");
                double amtGoals = Convert.ToDouble(Console.ReadLine());

                Savings newGoal = new Savings(savGoals, amtGoals, User.CurrentLoggedInUser);
                _goals.Add(newGoal);

                Console.WriteLine("\nGoal successfully added.");
                Console.WriteLine("\nPress any key to return to Savings Menu");
                Console.ReadKey();

            Savings.SavingsMenu(User.CurrentLoggedInUser);

        }//end of Method for Adding goals-----------------------------------------------------------2


        //method for updating savings ------------------------------------------------------------------3 Damien and Katie
        public static void UpdateSavings(string currentLoggedInUser)
        {
            Console.Clear();

                Console.WriteLine($"\t Update {currentLoggedInUser} Savings\n");
                Console.WriteLine("---------------------------------------\n");
                var userSavings = _savings.Where(e => e.UserName == currentLoggedInUser);
                var savingsEntry = _savings.FindIndex(s => s.UserName == currentLoggedInUser);
                
                if (savingsEntry > -1)
                {
                    Console.WriteLine("Enter your new total savings amount:");
                    double amountToAdd = Convert.ToDouble(Console.ReadLine());

                    _savings.RemoveAt(savingsEntry);

                    Savings updatedSavings = new Savings(amountToAdd, currentLoggedInUser);
                    _savings.Insert(savingsEntry, updatedSavings);

                    Console.WriteLine("\nSavings has been successfully updated.");

                }
                else
                {
                    Console.WriteLine("No Savings Found.");
                }

                Console.WriteLine("\nPress any key to return to Savings Menu");
                Console.ReadKey();
                Savings.SavingsMenu(User.CurrentLoggedInUser);

        }//end of update savings ---------------------------------------------------------------------------3





        //Method for Removing goals--------------------------------------------------------------------------4 Damien
        public static void RemoveGoals(string currentLoggedInUser)
        {
            Console.Clear();

            int exitRemoveGoalsChoice1 = 1;
            //do while loop to exit to home
            
                Console.WriteLine("\tRemove Goals Menu");
                Console.WriteLine("---------------------------------------\n");

                //searches the name of the goal they wish to remove
                Console.WriteLine("Enter the Goal you want to remove:");
                string removeGoal = Console.ReadLine();

                //the variable is then passed through the list to find a matching account
                Savings removeGoalfound= _goals.Find(e => e.savGoals.Equals(removeGoal, StringComparison.Ordinal));

                //if-else statement to confirm if admin wants to remove the goal
                if (removeGoalfound != null)
                {
                    Console.WriteLine($"\nThe goal {removeGoal} will be removed.");
                    Console.WriteLine("\nAre you sure you want to remove this goal? (y/n)\n");

                    char removeConfirm = Convert.ToChar(Console.ReadLine());


                    if (removeConfirm == 'y') //removes goal
                    {
                        _goals.Remove(removeGoalfound);
                        Console.WriteLine("\nGoal removed.\n");

                    }
                    else //cancels removal
                    {
                        Console.WriteLine("\nRemove canceled.\n");
                    }

                }
                else //displays if the goal entered is not on the list
                {
                    Console.WriteLine("\nGoal does not exist.\n");

                }

                Console.WriteLine("\nPress any key to return to Savings Menu");
                Console.ReadKey();
                Savings.SavingsMenu(User.CurrentLoggedInUser);

            }//end of Method for Removing goals-----------------------------------------------------------4




        //Method for updating goals ------------------------------------------------------------------------------------5 Damien
        public static void UpdateGoals()
        {
            Console.Clear();                  

                    Console.WriteLine("\t Update Goals Menu");
                    Console.WriteLine("---------------------------------------\n");
                    Console.WriteLine();

                    Console.WriteLine("Enter the name of the Goal you wish to update\n");

                    string removeGoal = Console.ReadLine();

                    //the variable is then passed through the list to find a matching account
                    Savings removeGoalsfound = _goals.Find(g => g.savGoals.Equals(removeGoal, StringComparison.Ordinal));

                    //if-else statement to confirm if the user wants to update selected goal

                    if (removeGoalsfound != null)
                    {
                        Console.WriteLine($"\nThe goal {removeGoal} will be updated.");
                        Console.WriteLine("\nAre you sure you want to update this goal? (y/n)\n");

                        char removeConfirm = Convert.ToChar(Console.ReadLine());


                        if (removeConfirm == 'y') //removes the users goal
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
                            Console.WriteLine("\nGoal successfully updated.\n");


                        }
                        else //cancels removal
                        {
                            Console.WriteLine("\nUpdated canceled.\n");
                        }// end of second if else

                    }
                    else//prints if goal is not found
                    {
                        Console.WriteLine("\nGoal not found.");
                        Console.ReadKey();
                    }//end of first if else

                Console.WriteLine("\nPress any key to return to Savings Menu");
                Console.ReadKey();
                Savings.SavingsMenu(User.CurrentLoggedInUser);

        }//end of Method for updating goals----------------------------------------------------------------------------------5


        //view goals method------------------------------------------------------------------------------------------------------------------------6 Damien
        public static void ViewGoals(string currentLoggedInUser)
        {
            Console.Clear();

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
                    }//end of foreach

                }//end of else if
             
                Console.WriteLine("\nPress any key to return to Savings Menu");
                Console.ReadKey();
                Savings.SavingsMenu(User.CurrentLoggedInUser);

        }//end of ViewGoal method-----------------------------------------------------------------------------------------------------------------------6




        //Admin view savings --------------------------------------------------------------7 Damien
        public void AdminViewSavings()
        {
            Console.Clear();

            //do while loop to exit to home
 
                Console.WriteLine($"\t Admin Menu For Display Savings\n");
                Console.WriteLine("---------------------------------------\n");
                Console.WriteLine();

                //displays savings for all users 
                if (_savings.Count == 0)
                {
                    Console.WriteLine($"No savings added");
                }
                else
                {
                    foreach (Savings s in _savings)

                        Console.WriteLine($"Username: {s.UserName}\n Savings amount: {s.amtSavings} \n");

                }//end of if else

            Console.WriteLine("\nPress any key to return to Admin Home");
            Console.ReadKey();
            Admin.AdminHome();

        }//end of ViewSavings method---------------------------------------------------------7
     


        //method for PreaAdded users goals---------------------------------------------------------8 Damien
        public static void PreaddedUserGoals()
        {
            //adds objects to the list

            _goals.Add(new Savings
            ("Dinner", 34, "johnsmith7")
            );
            _goals.Add(new Savings
            ("Fix Car", 2569, "johnsmith7")
            );


            _goals.Add(new Savings
            ("New Tv", 800, "lj1978")
            );


            _goals.Add(new Savings
            ("Hoilday Trip", 2700, "p_man")
            );
            _goals.Add(new Savings
            ("Office Chair", 128, "p_man")
            );


            _goals.Add(new Savings
            ("Electric Shaver", 55, "mrs_michelle")
            );


            _goals.Add(new Savings
            ("Private Island", 15000000, "mrbeast")
            );
            _goals.Add(new Savings
            ("New Workers", 12, "mrbeast")
            );
            _goals.Add(new Savings
            ("Priavte Jet", 250000, "mrbeast")
            );

        }//end of PreAddeded users Goals method------------------------------------------------------8


        //method for PreaAdded users savings----------------------------------------9 Damien
        public static void PreaddedUserSavings()
        {
            //adds objects to the list

            _savings.Add(new Savings
            ( 18.98, "johnsmith7")
            );

            _savings.Add(new Savings
            ( 1500, "lj1978")
            );

            _savings.Add(new Savings
            ( 3400, "p_man")
            );

            _savings.Add(new Savings
            ( 350, "mrs_michelle")
            );

            _savings.Add(new Savings
            (1000000000, "mrbeast")
            );

        }//end of PreAddeded users savings method------------------------------------9


    }//end of class savings---------------------------------------
}//end of namespace-----------------------------------------------
