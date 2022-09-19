using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using CrimeWeb.DataAccess;
using CrimeWeb.Models;
using System.Data;
using System.Data.SqlClient;


namespace CrimeWeb.Controllers
{
    public class LoginController : Controller
    {
        private ADOHelper _helper=new ADOHelper();
                
        // GET: Login
        public ActionResult Login()
        {
            LoginModel model = new LoginModel();
            return View(model);
        }
        
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string query = string.Format(Consvalues.LoginSelect, model.UserName.Trim());
                    DataTable dt = _helper.GetQuerydetails(query);
                    if ((dt != null) && (dt.Rows.Count > 0))
                    {
                        model.UserId = Convert.ToInt32(dt.Rows[0]["id"]);
                        string encryptPasswordGet = dt.Rows[0]["password"].ToString();
                        string decryptPassword = Encoding.UTF8.GetString(Convert.FromBase64String(encryptPasswordGet));
                        if (decryptPassword == model.Password)
                        {
                             string loginupdateqyery = string.Format(Consvalues.Lastloginupdate, model.UserId);
                            _helper.Lastloginupdate(loginupdateqyery);
                            Session["UserId"]=model.UserId;
                            Session["Username"] = model.UserName;
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ViewBag.errormessage = "Please enter correct Username and password";
                        }
                    }
                    else
                    {
                        ViewBag.errormessage = "you don't have login credentials";
                    }
                }
                return View(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public ActionResult Create()
        {
            UserModel model = new UserModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(UserModel model)
        {
            try
            {
                string query = string.Format(Consvalues.UserNameselect, model.username.Trim());
                DataTable dt = _helper.GetQuerydetails(query);
                if ((dt != null) && (dt.Rows.Count == 0))
                {
                    //encrypt
                    model.password = Convert.ToBase64String(Encoding.UTF8.GetBytes(model.password));
                    List<SqlParameter> sp = new List<SqlParameter>();
                    sp.Add(new SqlParameter("@FirstName", model.firstname));
                    sp.Add(new SqlParameter("@LastName", model.lastname));
                    sp.Add(new SqlParameter("@Gender", model.gender));
                    sp.Add(new SqlParameter("@Address", model.address));
                    sp.Add(new SqlParameter("@City", model.city));
                    sp.Add(new SqlParameter("@State", model.state));
                    sp.Add(new SqlParameter("@Contactno", model.contactno));
                    sp.Add(new SqlParameter("@Username", model.username));
                    sp.Add(new SqlParameter("@Password", model.password));
                    int NewId = _helper.OutputResultID(Consvalues.AddUser.ToString(), sp);
                    if (NewId > 0)
                    {
                        return RedirectToAction("Login", "Login");
                    }
                }
                else
                {
                    ViewBag.errormessage = "UserName already Exist";
                }

                
                return View(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Login");
        }
    }
}