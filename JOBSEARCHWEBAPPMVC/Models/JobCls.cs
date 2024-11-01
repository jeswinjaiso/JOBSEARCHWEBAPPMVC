using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JOBSEARCHWEBAPPMVC.Models
{
    public class JobCls
    {
        public string Title { set; get; }
        public string Desc { set; get; }
        public string Compid { set; get; }
        public string Skills { set; get; }
        public string Exp { set; get; }

        public string Datep{ set; get; }
        public string Salary { set; get; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime EndDate
        {
            get;set;
        }
        public string Status { set; get; }
        public string MSG { set; get; }


    }
}