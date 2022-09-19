using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc;
using CrimeWeb.Models;
using System.Data;
using System.Data.SqlClient;
using CrimeWeb.DataAccess;


namespace CrimeWeb.Controllers
{
    public class ActionTakenController : Controller
    {
        private ADOHelper _helper = new ADOHelper();
        // GET: ActionTaken
        public ActionResult ActionList()
        {
            try
            {
                List<ActionTakenModel> list = new List<ActionTakenModel>();
                DataTable dt = _helper.GetQuerydetails(Consvalues.Actiondetailget);
                if ((dt != null) && (dt.Rows.Count > 0))
                    list = TabletoList.ConvertDataTable<ActionTakenModel>(dt);
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
                LoadDropdown();
                ActionTakenModel model = new ActionTakenModel();
                if (id > 0)
                {
                    model = Editdetails(id);
                }
                return View(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ActionResult Edit(ActionTakenModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    List<SqlParameter> sp = new List<SqlParameter>();
                    sp.Add(new SqlParameter("@Id", model.id));
                    sp.Add(new SqlParameter("@Createdby", model.createdby));
                    sp.Add(new SqlParameter("@InvestigatorId ", model.investigatorId));
                    sp.Add(new SqlParameter("@investigatorrank ", model.investigatorrank));
                    sp.Add(new SqlParameter("@Refusedinvestigation", model.refusedinvestigation));
                    sp.Add(new SqlParameter("@Transferredps", model.transferredps));
                    sp.Add(new SqlParameter("@District", model.district));
                    sp.Add(new SqlParameter("@Nameofinchargeps", model.nameofinchargeps));
                    sp.Add(new SqlParameter("@Firno", model.firno));
                    sp.Add(new SqlParameter("@Judgementdetails", model.judgementdetails));

                    string query = string.Format(Consvalues.Actioninsertcheck, model.firno);
                    DataTable dt = _helper.GetQuerydetails(query);
                    if (model.id > 0)
                    {
                        ActionTakenModel editdetailget = new ActionTakenModel();
                        editdetailget = Editdetails(model.id);
                        if (editdetailget != null)
                        {
                                int NewId = _helper.OutputResultID(Consvalues.AddAction.ToString(), sp);
                                TempData["Sucessmessage"] = "Updated Sucessfully";
                                return RedirectToAction("ActionList");
                           
                        }

                    }
                    else
                    {
                        if ((dt != null) && (dt.Rows.Count == 0))
                        {
                            int NewId = _helper.OutputResultID(Consvalues.AddAction.ToString(), sp);
                            if (NewId > 0)
                            {
                                TempData["Sucessmessage"] = "Inserted Sucessfully";
                                return RedirectToAction("ActionList");
                            }
                            else
                            {
                                ModelState.AddModelError("", "Please enter the all details");
                            }

                        }
                        else
                        {
                            ModelState.AddModelError("", "FIR already Exist");
                        }

                    }
                }
                LoadDropdown();
                return View(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        private ActionTakenModel Editdetails(int id)
        {
            ActionTakenModel model = new ActionTakenModel();
            string editdetails = string.Format(Consvalues.Singleactionget, id);
            DataTable dt = _helper.GetQuerydetails(editdetails);
            if ((dt != null) && (dt.Rows.Count > 0))
                model = TabletoList.ConvertDataTablemodel<ActionTakenModel>(dt);
            return model;
        }


        /// FIR and Investigator detial load to dropdown
        /// </summary>
        private void LoadDropdown()
        {
            List<DropdownModel> lstFir = new List<DropdownModel>();
            List<DropdownModel> lstInversigator = new List<DropdownModel>();
            DataTable dt = _helper.GetQuerydetails(Consvalues.FIRDropdownvalue);
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                lstFir = TabletoList.ConvertDataTable<DropdownModel>(dt);
            }
            DataTable dtinverstigator = _helper.GetQuerydetails(Consvalues.Investigatordropdown);
            if ((dtinverstigator != null) && (dtinverstigator.Rows.Count > 0))
            {
                lstInversigator = TabletoList.ConvertDataTable<DropdownModel>(dtinverstigator);
            }
            lstFir.Insert(0, new DropdownModel() { Id = 0, Name = "select" });
            lstInversigator.Insert(0, new DropdownModel() { Id = 0, Name = "select" });
            ViewBag.firlst = lstFir;
            ViewBag.Investigator = lstInversigator;
        
        }
    }


   
}