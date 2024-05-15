using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityApplication
{
    public class UserSession
    {
        
        private static UserSession instance;

        // Property to hold the current user
        public Donator CurrentUser { get; private set; }
       
        private UserSession() { }

        
        public static UserSession Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserSession();
                }
                return instance;
            }
        }

        // Method to set the current user
        public void SetCurrentUser(Donator donator)
        {
            CurrentUser = donator;
        }
        

        // Method to clear the current user (e.g., on logout)
        public void ClearCurrentUser()
        {
            CurrentUser = null;
        }
    }
}
