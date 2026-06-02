using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseAppGroup
{
    public abstract class Account
    {
        //fields
        private string firstName;
        private string lastName;
        private string username;
        private string password;

        //properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }



    }//end of account
}
