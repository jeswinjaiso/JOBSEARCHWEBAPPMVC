using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JOBSEARCHWEBAPPMVC.Models
{
    public class ComponyCls
    {
        
        [Required(ErrorMessage = "Enter name")]
        public string Name { set; get; }
        [Required(ErrorMessage = "Enter type of the compony")]
        public string C_Type { set; get; }
        [Required(ErrorMessage = "Enter address")]
        public string Address { set; get; }
        //[Required(ErrorMessage = "Enter phone number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public int Phno { set; get; }
        [EmailAddress(ErrorMessage = "Enter valid email")]
        public string Email { set; get; }
       
        public string Username { set; get; }
        [Required(ErrorMessage = "username")]
        public string Password { set; get; }
        [Compare("Password", ErrorMessage = "MISMATCH")]
        public string CPassword { set; get; }
        public string AdMsg { set; get; }
    }
}