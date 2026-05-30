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
        private string goals;
        private double savings;

        //Method for Savings menu-----------------------------------1
        public static void SavingsMenu()
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

                Console.WriteLine("1. back to savings menu");
                exitAddGoalsChoice1 = Convert.ToInt32(Console.ReadLine());



            } while (exitAddGoalsChoice1 == 0);
            Savings.SavingsMenu();

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

                Console.WriteLine("1. back to savings menu");
                exitAddSavingChoice1 = Convert.ToInt32(Console.ReadLine());



            } while (exitAddSavingChoice1 == 0);
            Savings.SavingsMenu();

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

                Console.WriteLine("1. back to savings menu");
                exitRemoveGoalsChoice1 = Convert.ToInt32(Console.ReadLine());



            } while (exitRemoveGoalsChoice1 == 0);
            Savings.SavingsMenu();

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

                Console.WriteLine("1. back to savings menu");
                exitUpdateGoalsChoice1 = Convert.ToInt32(Console.ReadLine());



            } while (exitUpdateGoalsChoice1 == 0);
            Savings.SavingsMenu();

        }//end of Method for updating goals----------------------------------------5





    }//end of class savings---------------------------------------
}//end of namespace-----------------------------------------------
