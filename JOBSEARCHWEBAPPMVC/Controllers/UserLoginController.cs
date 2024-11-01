using JOBSEARCHWEBAPPMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JOBSEARCHWEBAPPMVC.Controllers
{
    public class UserLoginController : Controller
    {
        JOBSEARCHMVCEntities1 Dbobj = new JOBSEARCHMVCEntities1();
        public ActionResult UserLogin_PageLoad()
        {

            return View();
        }
        public ActionResult UserLogin_Click(ComLoginCls Obj)
        {
            if (ModelState.IsValid)
            {
                ObjectParameter op = new ObjectParameter("status", typeof(int));
                var sts = Dbobj.sp_ComLogin(Obj.Username, Obj.Password, op);
                int val = Convert.ToInt32(op.Value);
                if (val == 1)
                {
                    var cid = Dbobj.sp_getcid(Obj.Username, Obj.Password).FirstOrDefault();
                    Session["USERID"] = cid;

                    return RedirectToAction("Jobs_PageLoad", "UserJobDetails");
                }
                else
                {
                    Obj.Msg = "INCORRECT";
                    return View("UserLogin_PageLoad", Obj);
                }
            }

            return View("UserLogin_PageLoad", Obj);
        }
    }
}