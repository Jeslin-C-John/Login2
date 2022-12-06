using Login2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace Login2.Controllers
{
    public class LoginController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(DataModel instance)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-28UGTAO;Initial Catalog=user;Integrated Security=True");
            string SqlQuery = "select name from userlist where name=@name and password=@password";
            con.Open();
            SqlCommand cmd = new SqlCommand(SqlQuery, con);
            cmd.Parameters.AddWithValue("@name", instance.Name);
            cmd.Parameters.AddWithValue("@Password", instance.Password);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                Session["Name"] = instance.Name.ToString();
                return RedirectToAction("Welcome");
            }
            con.Close();
            return View();
        }

        [HttpGet]
        public ActionResult Welcome(DataModel instance)
        {
            return View();
        }
    }
}