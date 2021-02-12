using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject_For_CoralTeam.Models
{
    public class User : IdentityUser
    {
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Phone { get; set; }

        public string LastName { get; set; }
        public string Fax { get; set; }
        public string Company { get; set; }
        public string Mobile { get; set; }
        public string Title { get; set; }
        public bool Finance { get; set; }

        public bool Operations { get; set; }

        public bool IT { get; set; }
        public bool Sales { get; set; }
        public bool Administrative { get; set; }
        public bool Legal { get; set; }
        public bool Marketing { get; set; }


        public string Comments { get; set; }

        public string Country { get; set; }
        public string OfficeName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
