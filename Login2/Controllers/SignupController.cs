using Login2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login2.Controllers
{
    public class SignupController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(DataModel instance)
        {
            DataModel DataModelobj=new DataModel();
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-28UGTAO;Initial Catalog=user;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("insertuser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", instance.Name);
                    cmd.Parameters.AddWithValue("@password", instance.Password);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            }
            return View();

        }
    }
}