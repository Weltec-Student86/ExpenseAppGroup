using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseAppGroup //Damien was responsible for this class
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

        //method for expense---------------------------------------------------------------------------------------------------------------------------------1 Damien
        //expense that have been added to user account

        public void AdminViewExpenses()
        {
            Console.Clear();

          
                Console.WriteLine($"\t Display Expenses\n");
                Console.WriteLine("---------------------------------------\n");
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

                Console.WriteLine("\nPress any key to return to Admin Home");
                Console.ReadKey();              
                Admin.AdminHome();

        }//end of ViewExpense method--------------------------------------------------------------------------------------------------------------------------1


        //adding new expense to user account----------------------------------------------------------------------------------------------------------------2 Damien
        public static void AddExpense()
        {

            Console.Clear();


                Console.WriteLine("\t Add your expenses\n");
                Console.WriteLine("---------------------------------------\n");

                Console.WriteLine("Add expense name:");
                string expName = Console.ReadLine();

                Console.WriteLine("Add expense amount:");
                double expAmount = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Add expense frequency (days):");
                int expFrequency = Convert.ToInt32(Console.ReadLine());

           

                Expenses newExpense = new Expenses(expName, expAmount, expFrequency, User.CurrentLoggedInUser);
                _expenses.Add(newExpense);

                Console.WriteLine("\nExpense successfully added.");
                Console.WriteLine("\nPress any key to return to Home Menu");
                Console.ReadKey();
                User.UserHome();


        }//end of AddExpense method----------------------------------------------------------------------------------------------------------------------------2




        //Remove expense to user --------------------------------------------------------------------------------------------------------------------------------3 Katie and Damien
        public static void RemoveExpense(string currentLoggedInUser)
        {
            Console.Clear();
            

                Console.WriteLine("\t Remove Expenses Menu");
                Console.WriteLine("---------------------------------------\n");
                Console.WriteLine();
                //searches the name of the expense they wish to remove
                Console.WriteLine("Enter the expense you want to remove:\n");
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
                    
                }

                Console.WriteLine("\nPress any key to return to Home Menu");
                Console.ReadKey();
                User.UserHome();

        }//end of removal of expense method-----------------------------------------------------------------------------------------------------------------------3



        //end of existing expense-------------------------------------------------------------------------------------------------------------------4 Damien (with minor assistance from Katie)
        public static void UpdateExpense(string currentLoggedInUser)
        {
           
                Console.Clear();

                Console.WriteLine("\t Update Expenses Menu\n");
                Console.WriteLine("---------------------------------------\n");
                Console.WriteLine();
                Console.WriteLine("Enter the name of the expense you wish to update:");
                

                string removeExpenses = Console.ReadLine();

                //the variable is then passed through the list to find a matching account
                Expenses removeExpensesfound = _expenses.Find(e => e.ExpName.Equals(removeExpenses, StringComparison.Ordinal));

                //if-else statement to confirm if the user wants to update selected expense
            
                if (removeExpensesfound != null)
                {
                    Console.WriteLine($"\nThe expense {removeExpensesfound.ExpName} will be updated.");
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
                        Console.WriteLine("\nExpense successfully updated.\n");

                    }
                    else //cancels removal
                    {
                        Console.WriteLine("\nUpdated Canceled.\n");
                    }

                }
                else
                {
                    Console.WriteLine("\nExpense Not Found.");
                    
                }

                Console.WriteLine("\nPress any key to return to Home Menu");
                Console.ReadKey();
                User.UserHome();

        }//end of update expense method---------------------------------------------------------------------------------------------------------------4


       




        //method for Viewing the expenses--------------------------------------------------------------------------------------------------------------5 Damien
        //viewing all expenses that have been added to user account
        public static void ViewExpenses(string currentLoggedInUser)
        {
            Console.Clear();

                var userExpenses = _expenses.Where(e => e.UserName == currentLoggedInUser).ToList();

                Console.WriteLine($"\t View Expenses Menu\n");
                Console.WriteLine($"\tWelcome {currentLoggedInUser}\n");
                Console.WriteLine("---------------------------------------\n");
                Console.WriteLine();
                
                //users expenses 
                if (userExpenses.Count == 0)
                {
                    Console.WriteLine($"No Expenses Added");

                }
                else
                {
                    foreach (var e in userExpenses)
                    {
                        Console.WriteLine($"Name: {e.ExpName} \tAmount: ${e.ExpAmount} \tFrequency (days): {e.ExpFrequency}");
                    }
                    
                }
                Console.WriteLine("\nPress any key to return to Home Menu");
                Console.ReadKey();
                User.UserHome();

        }//end of ViewExpense method-----------------------------------------------------------------------------------------------------------------------5





        //Method for the preadded users expenses for view expenses this is where the values are stored--------------------------------------------------------6 Damien
        public static void PreaddedUserExpenses()
        {
            //adds objects to the list

            _expenses.Add(new Expenses
            ("Power Bill", 211, 1, "johnsmith7")
            );
            _expenses.Add(new Expenses
            ("Rent", 250, 7, "johnsmith7")
);


            _expenses.Add(new Expenses
            ("Xbox Game Pass", 25, 3, "lj1978")
            );
            _expenses.Add(new Expenses
            ("Car Insurance", 110, 3, "lj1978")
            );


            _expenses.Add(new Expenses
            ("Disney Plus+", 666, 6, "p_man")
            );


            _expenses.Add(new Expenses
            ("Gym", 14, 5, "mrs_michelle")
            );
            _expenses.Add(new Expenses
            ("Phone Plan", 44, 5, "mrs_michelle")
            );


            _expenses.Add(new Expenses
            ("Crew Members pay", 2.13, 1, "mrbeast")
            );
            _expenses.Add(new Expenses
            ("Private Yacht", 50000, 7, "mrbeast")
            );


        }//end of the preadded user expenses methods-------------------------------------------------------------------------------------------------------------6


    }//end of class-----------------------------------------
}//end of namespace-----------------------------------------
