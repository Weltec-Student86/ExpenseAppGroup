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

        private static List<Expenses> _expenses = new List<Expenses>();
        public string expName {  get; set; }
        public double expAmount { get; set; }
        public int expFrequency { get; set; }

        //method for expense----------------------------------1
        //expense that have been added to user account
       
        public static void ViewExpenses()
        {
            Console.Clear();

            int exitAddExpenseChoice1 = 1;
            //do while loop to exit to home
            do
            {
                Console.WriteLine("\t Display Expenses");

                //users expenses 
                if (_expenses.Count == 0)
                {
                    Console.WriteLine($"no expenses added");
                }
                else
                {
                    foreach (var e in _expenses)
                    Console.WriteLine($"Name: {e.expenseName} Amount: ${e.expenseAmount} Frequency {e.expenseFrequency}");

                }
                Console.WriteLine("1. back to home");
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

                Console.WriteLine("\t add your expenses");
                Console.WriteLine();

                Console.WriteLine("Add expense name:");
                string expName = Console.ReadLine();

                Console.WriteLine("Add expense amount:");
                double expAmount = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Add expense frequency (days):");
                int expFrequency = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("1. back to home");
                exitAddExpenseChoice2 = Convert.ToInt32(Console.ReadLine());

                _expenses.Add(new Expenses
                {
                    expenseName = expName,
                    expenseAmount = expAmount,
                    expenseFrequency = expFrequency
                });


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

                Console.WriteLine("1. back to home");
                exitUpdateExpenseChoice1 = Convert.ToInt32(Console.ReadLine());


            } while (exitUpdateExpenseChoice1 == 0);
            User.UserHome();

        }//end of update expense method---------------------4


        public static void ExpenseCalculation()
        {
            Console.Clear();



        }

     
    }//end of class-----------------------------------------
}//end of namespace-----------------------------------------
