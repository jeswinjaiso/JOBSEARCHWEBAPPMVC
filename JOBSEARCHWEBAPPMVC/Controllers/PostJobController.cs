using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JOBSEARCHWEBAPPMVC.Models;

namespace JOBSEARCHWEBAPPMVC.Controllers
{
    public class PostJobController : Controller
    {
        JOBSEARCHMVCEntities1 Dbobj = new JOBSEARCHMVCEntities1();
        public ActionResult PostJob_PageLoad()
        {
            return View();
        }
        public ActionResult PostJob_Click(JobCls Obj)
        {
            if (ModelState.IsValid)
            {
                Obj.Datep= DateTime.Now.ToString("yyyy-MM-dd");
                string newdate=Obj.EndDate.ToString("yyyy-MM-dd");
                Obj.Compid = Session["CPID"].ToString();
                Dbobj.sp_insertjob(Obj.Title, Obj.Desc, Obj.Compid, Obj.Skills,Obj.Exp, Obj.Datep, Obj.Salary,newdate, "ACTIVE");
                Obj.MSG = "ADDED";
            }
            return View("PostJob_PageLoad",Obj);
        }
    }
}