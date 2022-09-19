using CrimeWeb.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrimeWeb.Models;
using System.Data;
using System.Data.SqlClient;

namespace CrimeWeb.Controllers
{
    public class InvestigatorController : Controller
    {
        private ADOHelper _helper = new ADOHelper();
        // GET: Investigator
        public ActionResult InvestigatorList()
        {
            try
            {
                List<InvestigatorModel> list = new List<InvestigatorModel>();
                DataTable dt = _helper.GetQuerydetails(Consvalues.Investigatordetailget);
                if ((dt != null) && (dt.Rows.Count > 0))
                    list = TabletoList.ConvertDataTable<InvestigatorModel>(dt);
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
                InvestigatorModel model = new InvestigatorModel();
                if (id > 0)
                {
                    model = Editdetails(id);
                    model.DOBstring = model.dob.ToString("yyyy-MM-dd");
                    model.DOJstring = model.doj.ToString("yyyy-MM-dd");
                }
                return View(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }

        public ActionResult Edit(InvestigatorModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    List<SqlParameter> sp = new List<SqlParameter>();
                    sp.Add(new SqlParameter("@Id", model.id));
                    sp.Add(new SqlParameter("@Investigatorid", model.investigatorid));
                    sp.Add(new SqlParameter("@Investigatorname", model.investigatorname));
                    sp.Add(new SqlParameter("@Fathersname", model.fathersname));
                    sp.Add(new SqlParameter("@DOB", model.dob));
                    sp.Add(new SqlParameter("@Address", model.address));
                    sp.Add(new SqlParameter("@City", model.city));
                    sp.Add(new SqlParameter("@State", model.state));
                    sp.Add(new SqlParameter("@Pincode", model.pincode));
                    sp.Add(new SqlParameter("@DOJ", model.doj));
                    sp.Add(new SqlParameter("@Nameofthestation", model.nameofthestation));
                    sp.Add(new SqlParameter("@Location", model.location));
                    sp.Add(new SqlParameter("@Createdby", model.createdby));

                    string query = string.Format(Consvalues.Investigatorcheckinsert, model.investigatorid);
                    DataTable dt = _helper.GetQuerydetails(query);
                    if (model.id > 0)
                    {
                        InvestigatorModel editdetailget = new InvestigatorModel();
                        editdetailget = Editdetails(model.id);
                        if (editdetailget != null)
                        {
                            if (editdetailget.investigatorid.Trim() == model.investigatorid.Trim())
                            {
                                int NewId = _helper.OutputResultID(Consvalues.AddInvstigater.ToString(), sp);
                                TempData["Sucessmessage"] = "Updated Sucessfully";
                                return RedirectToAction("InvestigatorList");
                               
                            }
                            else
                            {
                                ModelState.AddModelError("", "Please check Investigator Id is Wrong");
                            }
                        }
                      
                    }
                    else
                    {
                        if ((dt != null) && (dt.Rows.Count == 0))
                        {
                            int NewId = _helper.OutputResultID(Consvalues.AddInvstigater.ToString(), sp);
                            if(NewId > 0)
                            {
                                TempData["Sucessmessage"] = "Inserted Sucessfully";
                                return RedirectToAction("InvestigatorList");
                            }
                            else
                            {
                                ModelState.AddModelError("", "Please enter the all details");
                            }
                           
                        }
                        else
                        {
                            ModelState.AddModelError("", "Investigator Id Exist");
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

        private InvestigatorModel Editdetails(int id)
        {
            InvestigatorModel model= new InvestigatorModel();
            string editdetails = string.Format(Consvalues.SingleInvestigatorget, id);
            DataTable dt = _helper.GetQuerydetails(editdetails);
            if ((dt != null) && (dt.Rows.Count > 0))
            model = TabletoList.ConvertDataTablemodel<InvestigatorModel>(dt);
            return model;
        }
    }
}