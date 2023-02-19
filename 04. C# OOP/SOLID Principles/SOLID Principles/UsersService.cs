using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid
{
    public class UsersService
    {
        public void Register(string email, string password)
        {
            {
                if (!IsEmailValid(email))
                {
                    throw new ArgumentException("Email is not valid.");
                }
                if (!IsPasswordValid(password))
                {
                    throw new ArgumentException("Password is not valid.");
                }
            }
        }

        private bool IsPasswordValid(string password)
        {
            // 500 lines of code
            // check if password is valid as per our reqs
            // check in online databases if password has been compromised
            return true;
        }

        private bool IsEmailValid(string email)   
        {
            // 50 lines of email validation
            return true;
        }
    }
}
