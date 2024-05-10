using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityApplication
{
    public class OrganisationSession
    {
        // Singleton instance
        private static OrganisationSession instance;

        // Property to hold the current user
        public Organisation CurrentOrganisation { get; private set; }

        // Private constructor to prevent direct instantiation
        private OrganisationSession() { }

        // Public method to get the singleton instance
        public static OrganisationSession Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrganisationSession();
                }
                return instance;
            }
        }

        
        public void SetCurrentOrganisation(Organisation organisation)
        {
            CurrentOrganisation = organisation;
        }


        
        public void ClearCurrentOrganisation()
        {
            CurrentOrganisation = null;
        }
    }
}

