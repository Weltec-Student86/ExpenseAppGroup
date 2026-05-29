using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseAppGroup
{
    public abstract class Account
    {
        private string firstName;
        private string lastName;
        private DateTime birthday = new DateTime();
        private string username;
        private string password;

        //properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday = new DateTime();
        public string Username { get; set; }
        public string Password { get; set; }



    }//end of account
}
