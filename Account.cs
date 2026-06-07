using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExpenseAppGroup
{
    public abstract class Account
    {
        //fields
        private string firstName = "defaultFirstName";
        private string lastName = "defaultLastName";
        private string username = "defaultUsername";
        private string password = "defaultPassword";

        //properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }



    }//end of account
}
