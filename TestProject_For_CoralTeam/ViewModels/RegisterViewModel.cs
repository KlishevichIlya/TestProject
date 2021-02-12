using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject_For_CoralTeam.ViewModels
{
    public class RegisterViewModel

    {
        [Required]
        public string Salutation { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid address")]
        public string Email { get; set; }

        [Required]
        [Compare("Email", ErrorMessage = "Email doesn't match!")]       
        public string ConfirmEmail { get; set; }

        [Required]        
        public string FirstName { get; set; }       
       
        public string MiddleName { get; set; }

        [Phone(ErrorMessage = "Invalid Phone")]
        public string Phone { get; set; }

        [Required]        
        public string LastName { get; set; }

        [Phone(ErrorMessage = "Invalid Fax")]
        public string Fax { get; set; }

        [Required]
        public string Company { get; set; }

        [Phone(ErrorMessage = "Invalid Mobile")]
        public string Mobile { get; set; }

        [Required]
        public string Title { get; set; }


        public bool Finance { get; set; }

        public bool Operations { get; set; }

        public bool IT { get; set; }
        public bool Sales { get; set; }
        public bool Administrative { get; set; }
        public bool Legal { get; set; }
        public bool Marketing { get; set; }



        [Required]
       
        public string Comments { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string OfficeName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password doesn't match!")]
        public string ConfirmPassword { get; set; }

    }
}
