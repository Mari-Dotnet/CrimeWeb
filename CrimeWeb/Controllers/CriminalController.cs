using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrimeWeb.Models;
using System.Data;
using System.Data.SqlClient;
using CrimeWeb.DataAccess;
using System.IO;

namespace CrimeWeb.Controllers
{
    public class CriminalController : Controller
    {
        // GET: Criminal
        private ADOHelper _helper = new ADOHelper();
        // GET: Investigator
        public ActionResult CriminalList()
        {
            try
            {
                List<Criminalmodel> list = new List<Criminalmodel>();
                DataTable dt = _helper.GetQuerydetails(Consvalues.Criminaldetailget);
                if ((dt != null) && (dt.Rows.Count > 0))
                    list = TabletoList.ConvertDataTable<Criminalmodel>(dt);
                return View(list);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                Criminalmodel model = new Criminalmodel();
                if (id > 0)
                {
                    model = Editdetails(id);
                    model.DOBstring = model.dob.ToString("yyyy-MM-dd");
                }
                return View(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public ActionResult Edit(Criminalmodel model,HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string filepathset = string.Empty;
                    string imageFoldername=string.Empty;
                    List<SqlParameter> sp = new List<SqlParameter>();
                    sp.Add(new SqlParameter("@Id", model.id));
                    sp.Add(new SqlParameter("@CriminalNumber", model.CriminalNumber));
                    sp.Add(new SqlParameter("@Name", model.name));
                    sp.Add(new SqlParameter("@Fathername", model.fathername));
                    sp.Add(new SqlParameter("@DOB", model.dob));
                    sp.Add(new SqlParameter("@Gender", model.gender));
                    sp.Add(new SqlParameter("@Placeofbirth", model.placeofbirth));
                    sp.Add(new SqlParameter("@Address", model.address));
                    sp.Add(new SqlParameter("@Haircolour", model.haircolour));
                    sp.Add(new SqlParameter("@Colour", model.colour));
                    sp.Add(new SqlParameter("@Bodymarks", model.bodymarks));
                    sp.Add(new SqlParameter("@Createdby", model.createdby));
                    sp.Add(new SqlParameter("@Nationality", model.Nationality));
                    if (file != null)
                    {
                        imageFoldername = "/CriminalImage/" + model.CriminalNumber + ".jpg";
                        string Pic = file.FileName;
                        string serverPath = Server.MapPath("~/CriminalImage");
                        if(!Directory.Exists(serverPath))
                        {
                            Directory.CreateDirectory(serverPath);
                        }
                        filepathset = System.IO.Path.Combine(Server.MapPath("~/CriminalImage"), model.CriminalNumber+".jpg");
                        sp.Add(new SqlParameter("@Imagepath", imageFoldername));
                    }
                    else
                    {
                        sp.Add(new SqlParameter("@Imagepath", model.Imagepath));
                    }
                    string query = string.Format(Consvalues.Criminalcheckinsert, model.CriminalNumber);
                    DataTable dt = _helper.GetQuerydetails(query);
                    if (model.id > 0)
                    {
                        Criminalmodel editdetailget = new Criminalmodel();
                        editdetailget = Editdetails(model.id);
                        if (editdetailget != null)
                        {
                            if (editdetailget.CriminalNumber.Trim() == model.CriminalNumber.Trim())
                            {
                                int NewId = _helper.OutputResultID(Consvalues.AddCriminal.ToString(), sp);
                                if((NewId > 0) && (file!=null))
                                {
                                    file.SaveAs(filepathset);
                                }
                                TempData["Sucessmessage"] = "Updated Sucessfully";
                                return RedirectToAction("CriminalList");

                            }
                            else
                            {
                                ModelState.AddModelError("", "Please check Criminal Id is Wrong");
                            }
                        }

                    }
                    else
                    {
                        if ((dt != null) && (dt.Rows.Count == 0))
                        {
                            int NewId = _helper.OutputResultID(Consvalues.AddCriminal.ToString(), sp);
                            if ((NewId > 0) && (file != null))
                            {
                                file.SaveAs(filepathset);
                                TempData["Sucessmessage"] = "Inserted Sucessfully";
                                return RedirectToAction("CriminalList");
                            }
                            else
                            {
                                ModelState.AddModelError("", "Please enter the all details");
                            }

                        }
                        else
                        {
                            ModelState.AddModelError("", "Criminal Id Exist");
                        }

                    }
                }

                return View(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private Criminalmodel Editdetails(int id)
        {
            Criminalmodel model = new Criminalmodel();
            string editdetails = string.Format(Consvalues.SingleCriminalget, id);
            DataTable dt = _helper.GetQuerydetails(editdetails);
            if ((dt != null) && (dt.Rows.Count > 0))
            model = TabletoList.ConvertDataTablemodel<Criminalmodel>(dt);
            return model;
        }
    }
}