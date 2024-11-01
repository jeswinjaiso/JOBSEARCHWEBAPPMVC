using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JOBSEARCHWEBAPPMVC.Models;

namespace JOBSEARCHWEBAPPMVC.Controllers
{ 
    public class CLoginController : Controller
    {
        JOBSEARCHMVCEntities1 Dbobj = new JOBSEARCHMVCEntities1();
        public ActionResult Login_PageLoad()
        {
            return View();
        }
        public ActionResult Login_Click(ComLoginCls Obj)
        {
            if (ModelState.IsValid)
            {
                ObjectParameter op = new ObjectParameter("status", typeof(int));
                var sts = Dbobj.sp_ComLogin(Obj.Username, Obj.Password, op);
                int val = Convert.ToInt32(op.Value);
                if (val == 1)
                {
                    var cid = Dbobj.sp_getcid(Obj.Username, Obj.Password).FirstOrDefault();
                    Session["CPID"] = cid;
                    
                    return RedirectToAction("ComHome_PageLoad","ComponyHome");
                }
                else
                {
                    Obj.Msg = "INCORRECT";
                    return View("Login_PageLoad",Obj);
                }
            }
            
            return View("Login_PageLoad", Obj);
        }
    }
}