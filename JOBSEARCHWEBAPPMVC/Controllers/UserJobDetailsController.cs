using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JOBSEARCHWEBAPPMVC.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace JOBSEARCHWEBAPPMVC.Controllers
{
    public class UserJobDetailsController : Controller
    {
        JOBSEARCHMVCEntities1 DBOBJ = new JOBSEARCHMVCEntities1();
        string ConStr = ConfigurationManager.ConnectionStrings["AdoCon"].ToString();
        
        public ActionResult Jobs_PageLoad()
        {
            List<GetJobDetCls> Li = new List<GetJobDetCls>();
            Li = JobDetails(null,null,null);

            return View(Li);
        }
        public ActionResult Search(string jbt, string skills, string exp)
        {
            List<GetJobDetCls> Li = new List<GetJobDetCls>();
            if (jbt ==null || skills==null || exp==null)
            {
                RedirectToAction("Jobs_PageLoad");
            }
            else
            {
                Li = JobDetails(jbt,skills,exp);
                return View("Jobs_PageLoad", Li);
            }
            //List<GetJobDetCls> Li = new List<GetJobDetCls>();
            Li = JobDetails(jbt, skills, exp);
            
            return View("Jobs_PageLoad",Li);

        }


    public List<GetJobDetCls> JobDetails(string jbt, string skills, string exp)
        {
            List<GetJobDetCls> Jobs = new List<GetJobDetCls>();
            using (SqlConnection con = new SqlConnection(ConStr))
            {
                SqlCommand Cmd = con.CreateCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                if (skills == null || jbt==null || exp ==null )
                {
                   Cmd.CommandText = "sp_AllJob";
                }
                else
                {
                    Cmd.CommandText = "sp_Search";
                    Cmd.Parameters.Add("@jbt", SqlDbType.VarChar).Value=jbt;
                    Cmd.Parameters.Add("@ski", SqlDbType.VarChar).Value =skills;
                    Cmd.Parameters.Add("@exp", SqlDbType.VarChar).Value =exp ;


                }
                
                SqlDataAdapter Sda = new SqlDataAdapter(Cmd);
                DataTable Dt = new DataTable();
                int c=Dt.Rows.Count;
                if (c == 0)
                {

                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                Sda.Fill(Dt);
                con.Close();
                int J = 0;
                foreach(DataRow Job in Dt.Rows)
                {
                    J++;
                    Jobs.Add(new GetJobDetCls
                    {
                        CID = Job["JOB_ID"].ToString(),
                        Title = Job["JOB_TITLE"].ToString(),
                        Desc = Job["JOB_DESCRIPTION"].ToString(),
                        Skills = Job["SKILLS"].ToString(),
                        CompName = GetCompName(Job["COMPONYID"].ToString()),
                        Exp = Job["EXPERIENCE"].ToString(),
                        Salary = Job["SALARY"].ToString(),
                        Datep = Job["DATE_POSTED"].ToString(),
                        EndDate = Job["END_DATE"].ToString(),
                        Status = Job["STATUS"].ToString(),
                    });
                }
            }
            return Jobs;
        }
        public string GetCompName(string ID)
        {
            SqlConnection con = new SqlConnection(ConStr);
            SqlCommand Cmd = con.CreateCommand();
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.CommandText = "sp_GetCompName";
            Cmd.Parameters.Add("@id",SqlDbType.VarChar).Value=ID;
            //Cmd.ExecuteScalar();
            //SqlDataAdapter Sda = new SqlDataAdapter(Cmd);
            //DataTable Dt = new DataTable();
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            string NAME=Cmd.ExecuteScalar().ToString();
            con.Close();
            return NAME;
        }
    }
}