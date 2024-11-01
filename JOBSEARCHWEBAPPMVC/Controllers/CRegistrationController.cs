using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JOBSEARCHWEBAPPMVC.Models;

namespace JOBSEARCHWEBAPPMVC.Controllers
{
    public class CRegistrationController : Controller
    {
        JOBSEARCHMVCEntities1 Dbobj = new JOBSEARCHMVCEntities1();
        public ActionResult Reg_PageLoad()
        {
            return View();
        }
        public ActionResult Reg_Click(ComponyCls Obj)
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
                
                Dbobj.sp_ComponyInsert(regid, Obj.Name, Obj.Address,Obj.C_Type, (Obj.Phno), Obj.Email);
                
                Dbobj.sp_LoginInsert(regid, Obj.Username, Obj.CPassword,"COMPONY");
                Obj.AdMsg = "REGISTERED";
                return RedirectToAction("Login_PageLoad", "CLogin");

            }
            return View("Reg_PageLoad",Obj);
           
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}