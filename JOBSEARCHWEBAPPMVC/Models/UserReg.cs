using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JOBSEARCHWEBAPPMVC.Models
{
    public class UserReg
    {
        
        public string LOGID { set; get; }
        [Required(ErrorMessage = "Required")]
        public string Name { set; get; }
        [Required(ErrorMessage = "Required")]
        public string Address { set; get; }
        public string Email { set; get; }
        public string Phno { set; get; }
        [Required(ErrorMessage = "Required")]
        public string  Quali{ set; get; }
        [Required(ErrorMessage = "Required")]
        public string Skills { set; get; }
        [Required(ErrorMessage = "Required")]
        public string Experience { set; get; }
        public string Msg { set; get; }
        [Required(ErrorMessage = "Required")]
        public string Username { set; get; }
        public string Password { set; get; }
        [Compare("Password", ErrorMessage = "MISMATCH")]
        public string CPassword { set; get; }
    }
}