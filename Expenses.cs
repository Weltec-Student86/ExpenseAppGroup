using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseAppGroup
{
    public class Expenses
    {
        //fields
        private string userName;
        private string expenseName;
        private double expenseAmount;
        private int expenseFrequency;

      
        public string ExpName {  get; set; }
        public double ExpAmount { get; set; }
        public int ExpFrequency { get; set; }
        public string UserName { get; set; }



        public static List<Expenses> _expenses = new List<Expenses>();
        //Constructor
        public Expenses(string name, double amount, int freq, string user)
        {
            ExpName = name;
            ExpAmount = amount;
            ExpFrequency = freq;
            UserName = user;
        }

        //method for expense---------------------------------------------------------------------------------------------------------------------------------1
        //expense that have been added to user account

        public void AdminViewExpenses()
        {
            Console.Clear();

            int exitAddExpenseChoice1 = 1;


            //do while loop to exit to home
            do
            {
                Console.WriteLine($"\t Display Expenses\n");

                //users expenses 
                if (_expenses.Count == 0)
                {
                    Console.WriteLine($"No expenses added");
                }
                else
                {
                    foreach (Expenses e in _expenses)
                   
                    Console.WriteLine($"Username: {e.UserName}\nExpense Name: {e.ExpName}\t Amount: ${e.ExpAmount}\t Frequency (days): {e.ExpFrequency}\n");

                }
                Console.WriteLine("1. Back to home");
                exitAddExpenseChoice1 = Convert.ToInt32(Console.ReadLine());

            } while (exitAddExpenseChoice1 == 0);
            Admin.AdminHome();

        }//end of ViewExpense method--------------------------------------------------------------------------------------------------------------------------1


        //adding new expense to user account----------------------------------------------------------------------------------------------------------------2
        public static void AddExpense()
        {

            Console.Clear();
            int exitAddExpenseChoice2 = 1;


            //do while loop to exit to home
            do
            {

                Console.WriteLine("\t Add your expenses\n");

                Console.WriteLine("Add expense name:");
                string expName = Console.ReadLine();

                Console.WriteLine("Add expense amount:");
                double expAmount = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Add expense frequency (days):");
                int expFrequency = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\n1. Back to home");
                exitAddExpenseChoice2 = Convert.ToInt32(Console.ReadLine());

                Expenses newExpense = new Expenses(expName, expAmount, expFrequency, User.CurrentLoggedInUser);
                _expenses.Add(newExpense);


            } while (exitAddExpenseChoice2 == 0);
            User.UserHome();

        }//end of AddExpense method----------------------------------------------------------------------------------------------------------------------------2




        //Remove expense to user --------------------------------------------------------------------------------------------------------------------------------3
        public static void RemoveExpense(string currentLoggedInUser)
        {
            Console.Clear();
            int exitRemoveExpenseChoice1 = 1;

            do
            {
                //searches the name of the expense they wish to remove
                Console.WriteLine("Enter the expense you want to remove:");
                string removeExpenses = Console.ReadLine();

                //the variable is then passed through the list to find a matching account
                Expenses removeExpensesfound = _expenses.Find(e => e.ExpName.Equals(removeExpenses, StringComparison.Ordinal));

                //if-else statement to confirm if the user wants to remove selected expense
                if (removeExpensesfound != null)
                {
                    Console.WriteLine($"\nThe Expense {removeExpensesfound.ExpName} will be removed.");
                    Console.WriteLine("\nAre you sure you want to remove this expense? (y/n)\n");

                    char removeConfirm = Convert.ToChar(Console.ReadLine());


                    if (removeConfirm == 'y') //removes the users Expense
                    {
                    _expenses.Remove(removeExpensesfound);
                    Console.WriteLine("\nExpense removed.\n");

                    }
                    else //cancels removal
                    {
                    Console.WriteLine("\nRemove canceled.\n");
                    }

                }
                else
                {
                    Console.WriteLine("\nExpense not found. Press any key to continue...");
                    Console.ReadKey();
                }
            } while (exitRemoveExpenseChoice1 == 0);
            User.UserHome();
        }//end of removal of expense method-----------------------------------------------------------------------------------------------------------------------3



        //end of existing expense-------------------------------------------------------------------------------------------------------------------4
        public static void UpdateExpense(string currentLoggedInUser)
        {
            int exitUpdateExpenseChoice1 = 1;
            do
            {
                Console.Clear();

            Console.WriteLine("\t Enter the name of the expense you wish to update");

            

            string removeExpenses = Console.ReadLine();

            //the variable is then passed through the list to find a matching account
            Expenses removeExpensesfound = _expenses.Find(e => e.ExpName.Equals(removeExpenses, StringComparison.Ordinal));

            //if-else statement to confirm if the user wants to update selected expense
            
                if (removeExpensesfound != null)
                {
                    Console.WriteLine($"\nThe expensel {removeExpensesfound.ExpName} will be updated.");
                    Console.WriteLine("\nAre you sure you want to update this expense? (y/n)\n");

                    char removeConfirm = Convert.ToChar(Console.ReadLine());


                    if (removeConfirm == 'y') //removes the users Expense
                    {

                        _expenses.Remove(removeExpensesfound);

                        Console.Clear();

                        Console.WriteLine("\tUpdated expenses\n");

                        Console.WriteLine("Updated expense name:");
                        string expName = Console.ReadLine();

                        Console.WriteLine("Updated expense amount:");
                        double expAmount = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Updated expense frequency (days):");
                        int expFrequency = Convert.ToInt32(Console.ReadLine());

                        Expenses newExpense = new Expenses(expName, expAmount, expFrequency, User.CurrentLoggedInUser);
                        _expenses.Add(newExpense);
                        Console.WriteLine("\nExpense removed.\n");

                    }
                    else //cancels removal
                    {
                        Console.WriteLine("\nUpdated canceled.\n");
                    }

                }
                else
                {
                    Console.WriteLine("\nExpense not found. Press any key to continue...");
                    Console.ReadKey();
                }
            } while (exitUpdateExpenseChoice1 == 0);
            User.UserHome();//returns back to home page

        }//end of update expense method---------------------------------------------------------------------------------------------------------------4


        public static void ExpenseCalculation()
        {
            Console.Clear();



        }


        //method for Viewing the expenses--------------------------------------------------------------------------------------------------------------6
        //viewing all expenses that have been added to user account
        public static void ViewExpenses(string currentLoggedInUser)
        {
            Console.Clear();

            
            int exitAddExpenseChoice1 = 1;
            //do while loop to exit to home
            do
            {
                
                Console.WriteLine($"\t Display Expenses\n");
                Console.WriteLine($"\tWelcome {currentLoggedInUser}\n");

                var userExpenses = _expenses.Exists(e => e.UserName == currentLoggedInUser);
                var user = _expenses.FindAll(e => e.UserName == currentLoggedInUser);

                if (userExpenses == false)
                {
                    Console.WriteLine("No expenses found.");
                }
                else
                {
                    
                    foreach (var e in user)
                    {
                        Console.WriteLine($"Name: {e.ExpName}\tAmount: ${e.ExpAmount}\t Frequency (days): {e.ExpFrequency}");
                    }
                    
                }//end of if-else

                Console.WriteLine("\n1. Back to home");
                exitAddExpenseChoice1 = Convert.ToInt32(Console.ReadLine());

                //var userExpenses = _expenses.Where(e => e.UserName == currentLoggedInUser).ToList();
                //Console.WriteLine($"\t Display Expenses\n");
                //Console.WriteLine($"\tWelcome {currentLoggedInUser}\n");
                ////users expenses 
                //if (_expenses.Count >= 0)
                //{
                //    foreach (var e in userExpenses)
                //        Console.WriteLine($"Name: {e.ExpName} Amount: ${e.ExpAmount} Frequency {e.ExpFrequency}");
                //}
                //else
                //{
                //    Console.WriteLine($"No expenses added");
                //}
                //Console.WriteLine("\n1. Back to home");
                //exitAddExpenseChoice1 = Convert.ToInt32(Console.ReadLine());

            } while (exitAddExpenseChoice1 == 0);
            User.UserHome(); //returns back to home page

        }//end of ViewExpense method-----------------------------------------------------------------------------------------------------------------------6





        //Method for the preadded users expenses for view expenses this is where the values are stored--------------------------------------------------------7
        public static void PreaddedUserExpenses()
        {
            //adds objects to the list

            _expenses.Add(new Expenses
            ("netflix", 14, 1, "johnsmith7")
            );

            _expenses.Add(new Expenses
            ("Prime", 11, 3, "lj1978")
            );

            _expenses.Add(new Expenses
            ("Disney", 666, 6, "p_man")
            );

            _expenses.Add(new Expenses
            ("Gym", 14, 5, "mrs_michelle")
            );

            _expenses.Add(new Expenses
            ("Phone Bill", 25, 3, "mrbeast")
            );

        }//end of the preadded user expenses methods-------------------------------------------------------------------------------------------------------------7


    }//end of class-----------------------------------------
}//end of namespace-----------------------------------------
