using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityApplication
{
    internal class AdminSession
    {
        private static AdminSession instance;
        public Admin CurrentAdmin{ get; private set; }
        private AdminSession() { }
        public static AdminSession Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AdminSession();
                }
                return instance;
            }
        }
        public void SetCurrentAdmin(Admin admin)
        {
            CurrentAdmin = admin;
        }
        public void ClearCurrentAdmin()
        {
            CurrentAdmin = null;
        }
    }
}
