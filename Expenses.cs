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
        private string expenseName;
        private double expenseAmount;
        private int expenseFrequency;

        public static List<Expenses> _expenses = new List<Expenses>();
        public string ExpName {  get; set; }
        public double ExpAmount { get; set; }
        public int ExpFrequency { get; set; }


        //Constructor
        public Expenses(string expenseName, double expenseAmount, int expenseFrequency)
        {
            ExpName = expenseName;
            ExpAmount = expenseAmount;
            ExpFrequency = expenseFrequency;

        }

        //method for expense----------------------------------1
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
                    Console.WriteLine($"Name: {e.ExpName} Amount: ${e.ExpAmount} Frequency {e.ExpFrequency}");

                }
                Console.WriteLine("1. Back to home");
                exitAddExpenseChoice1 = Convert.ToInt32(Console.ReadLine());

            } while (exitAddExpenseChoice1 == 0);
            User.UserHome();

        }//end of ViewExpense method--------------------------1


        //adding new expense to user account------------------2
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

                Expenses newExpense = new Expenses(expName, expAmount, expFrequency);
                _expenses.Add(newExpense);


            } while (exitAddExpenseChoice2 == 0);
            User.UserHome();

        }//end of AddExpense method------------------------2



        //Remove expense to user --------------------------3
        public static void RemoveExpense()
        {
            Console.WriteLine("Expense name:");

            Console.WriteLine("Displays expense details");

            Console.WriteLine("Are you sure you want to delete this expense (y/n)");


        }//end of update expense method---------------------3


        //end of existing expense---------------------------4
        public static void UpdateExpense()
        {
            Console.Clear();

            Console.WriteLine("\t Enter the name of the expense you wish to update");
            //remove == readline
            int exitUpdateExpenseChoice1 = 1;

            //do while loop to exit to home
            do
            {

                Console.WriteLine("Updated expense name:");
                string updatedExpense = Console.ReadLine();

                Console.WriteLine("Updated expense amount:");
                string updatedExpenseAmount = Console.ReadLine();

                Console.WriteLine("Updated expense frequency (days):");
                string updatedExpenseFrequency = Console.ReadLine();

                Console.WriteLine("\n1. Back to home");
                exitUpdateExpenseChoice1 = Convert.ToInt32(Console.ReadLine());


            } while (exitUpdateExpenseChoice1 == 0);
            User.UserHome();

        }//end of update expense method---------------------4


        public static void ExpenseCalculation()
        {
            Console.Clear();



        }


        //method for admin expense----------------------------------6
        //viewing all expenses that have been added to user account

        public static void ViewExpenses()
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
                    foreach (var e in _expenses)
                        Console.WriteLine($"Name: {e.expenseName} Amount: ${e.expenseAmount} Frequency {e.expenseFrequency}");

                }
                Console.WriteLine("\n1. Back to home");
                exitAddExpenseChoice1 = Convert.ToInt32(Console.ReadLine());

            } while (exitAddExpenseChoice1 == 0);
            User.UserHome();

        }//end of ViewExpense method--------------------------6

        public static void PreaddedUserExpenses()
        {

            Expenses exampleExpense0 = new Expenses("Netflix", 14, 1);
            Expenses exampleExpense1 = new Expenses("prime", 14, 1);
            Expenses exampleExpense2 = new Expenses("internet", 14, 1);
            Expenses exampleExpense3 = new Expenses("car broom", 14, 1);
            Expenses exampleExpense4 = new Expenses("Docterrors", 14, 1);
            Expenses exampleExpense5 = new Expenses("Disneyslop", 14, 1);

            //adds objects to the list
            _expenses.Add(exampleExpense0);
            _expenses.Add(exampleExpense1);
            _expenses.Add(exampleExpense2);
            _expenses.Add(exampleExpense3);
            _expenses.Add(exampleExpense4);
            _expenses.Add(exampleExpense5);




        }


    }//end of class-----------------------------------------
}//end of namespace-----------------------------------------
