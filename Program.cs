namespace ExpenseAppGroup
{
    internal class Program
    {
        static void Main(string[] args)

        {
            //declaring varaibles
            int choice;


            Console.WriteLine("\t******Welcome to the Expense App*******");
            Console.WriteLine("\t Login or Register for an account");

            Console.WriteLine("1.Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Administrator Login");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Please select a choice");
            choice = Convert.ToInt32(Console.ReadLine());
            
        }
    }
}
