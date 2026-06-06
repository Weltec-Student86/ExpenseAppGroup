using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseAppGroup
{
    public class CustomExceptions:Exception
    {
        private static string msg = "Error!";

        public CustomExceptions() :base(msg) { }
    }
}
