using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using JOBSEARCHWEBAPPMVC.Models;

namespace JOBSEARCHWEBAPPMVC.Controllers
{
    public class ApplyController : Controller
    {
        JOBSEARCHMVCEntities1 Dbobj = new JOBSEARCHMVCEntities1();
        string Con = ConfigurationManager.ConnectionStrings["AdoCon"].ToString();
        public ActionResult Index()
        {
            return View();
        }

        // GET: Apply/Details/5
        public ActionResult Details(int id)
        {
            ApplyCls Obj = new ApplyCls();
            using (SqlConnection con = new SqlConnection(Con))
            {
                SqlCommand Cmd = con.CreateCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "sp_getjobinfo";
                Cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                SqlDataAdapter Sda = new SqlDataAdapter(Cmd);
                DataTable Dt = new DataTable();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                Sda.Fill(Dt);
                con.Close();
                foreach (DataRow Job in Dt.Rows)
                {
                    Obj.CompId = Job["COMPONYID"].ToString();
                    Obj.JobId = Job["JOB_ID"].ToString();
                    Obj.Uid = id.ToString();
                    Obj.JobTitle = Job["JOB_TITLE"].ToString();
                }
            }
                return View(Obj);
        }

        // GET: Apply/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Apply/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Apply/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Apply/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Apply/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Apply/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
