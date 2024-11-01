using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JOBSEARCHWEBAPPMVC.Models;


namespace JOBSEARCHWEBAPPMVC.Controllers
{
    public class UserRegController : Controller
    {
        JOBSEARCHMVCEntities1 Dbobj = new JOBSEARCHMVCEntities1();
        public ActionResult UserReg_PageLoad()
        {

            return View();
        }
        public ActionResult UserReg_Click(UserReg Obj)
        {
            if (ModelState.IsValid)
            {
                var getmaxid = Dbobj.sp_maxid().FirstOrDefault();

                int mid = Convert.ToInt32(getmaxid);
                int regid = 0;
                if (mid == 0)
                {
                    regid = mid + 1;
                    // Obj.LOGID =  ID;
                }
                else
                {
                    int newid = mid + 1;
                    regid = newid;
                    string ID = newid.ToString();
                    // Obj.LOGID = ID;
                }

                Dbobj.Sp_UserReg(regid, Obj.Name, Obj.Address, Obj.Email, Obj.Phno, Obj.Quali, Obj.Skills, Obj.Experience);

                Dbobj.sp_LoginInsert(regid, Obj.Username, Obj.Password, "USER");
                Obj.Msg = "REGISTERED";
                return RedirectToAction("UserLogin_PageLoad", "UserLogin");

            }

            return View();
        }

    }
}