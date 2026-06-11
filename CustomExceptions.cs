using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseAppGroup //Attempted by Katie
{

    //attempted to make custom exceptions but struggled to implement them

    public class CustomExceptions:Exception
    {
        private static string msg = "Error!";

        public CustomExceptions() :base(msg) { }
    }//end of cutsom exception


    public class InvalidNameException : Exception
    {
        private static string invalidName = "Name contains invalid characters.";

        public InvalidNameException(string name) :base(invalidName) { }
    }//end of invalid name exception
}
