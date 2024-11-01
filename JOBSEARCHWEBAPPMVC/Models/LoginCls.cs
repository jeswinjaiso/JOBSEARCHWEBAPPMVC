using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JOBSEARCHWEBAPPMVC.Models
{
    public class LoginCls
    {
        public string Type { set; get; }
        public string Username { set; get; }
        [Required(ErrorMessage = "username")]
        public string Password { set; get; }
        [Compare("Password", ErrorMessage = "MISMATCH")]
        public string CPassword { set; get; }
        public string AdMsg { set; get; }
    }
}