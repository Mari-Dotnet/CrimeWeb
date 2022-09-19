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
    public class FIRController : Controller
    {
        private ADOHelper _helper = new ADOHelper();

       private List<DropdownModel> Lstcriminal = new List<DropdownModel>();
        // GET: FIR
        /// <summary>
        /// All Fir details get
        /// </summary>
        /// <returns></returns>
        public ActionResult FIRList()
        {
            try
            {
                List<FIRmodel> list = new List<FIRmodel>();
                DataTable dt = _helper.GetQuerydetails(Consvalues.FIRdetailget);
                if ((dt != null) && (dt.Rows.Count > 0))
                    list = TabletoList.ConvertDataTable<FIRmodel>(dt);
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
                FIRmodel model = new FIRmodel();
                CriminalDropdown();
                if (id > 0)
                {
                    model = Editdetails(id);
                    model.CriminalId = model.fircriminals.Split(',').Select(int.Parse).ToArray();
                    model.FIRdatestr = model.firdate.ToString("yyyy-MM-dd");
                    model.informdatestr = model.infodate.ToString("yyyy-MM-dd");
                    model.Occurancedatestr = model.occurencedate.ToString("yyyy-MM-dd");
                    model.fircriminals = String.Join(",", Lstcriminal.Where(x => model.CriminalId.Contains(x.Id)).Select(x => x.Name).ToArray());
                }
                return View(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public ActionResult Edit(FIRmodel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //double timebetween = (model.timeto - model.timefrom).TotalHours;
                    CriminalDropdown();
                    List<SqlParameter> sp = new List<SqlParameter>();
                    sp.Add(new SqlParameter("@Id", model.id));
                    sp.Add(new SqlParameter("@FirNo ", model.firno));
                    sp.Add(new SqlParameter("@District ", model.district));
                    sp.Add(new SqlParameter("@Policestation ", model.policestation));
                    sp.Add(new SqlParameter("@FirYear ", model.firyear));
                    sp.Add(new SqlParameter("@FirDate ",model.firdate));
                    sp.Add(new SqlParameter("@Act1 ", model.act1));
                    sp.Add(new SqlParameter("@Section1 ", model.section1));
                    sp.Add(new SqlParameter("@Act2 ", model.act2));
                    sp.Add(new SqlParameter("@Section2 ", model.section2));
                    sp.Add(new SqlParameter("@Otheractandsection ", model.otheractandsection));
                    sp.Add(new SqlParameter("@Occurenceday ", model.occurenceday));
                    sp.Add(new SqlParameter("@Occurencedate ", model.occurencedate));
                    sp.Add(new SqlParameter("@Timeperiod ", model.timeperiod));
                    sp.Add(new SqlParameter("@Timefrom ", model.timefrom));
                    sp.Add(new SqlParameter("@Timeto ", model.timeto));
                    sp.Add(new SqlParameter("@Inforeceivedps ", model.inforeceivedps));
                    sp.Add(new SqlParameter("@Infodate ", model.infodate));
                    sp.Add(new SqlParameter("@Infotime ", model.infotime));
                    sp.Add(new SqlParameter("@Dairyrefno ", model.dairyrefno));
                    sp.Add(new SqlParameter("@Placeanddirectionofoccurence ", model.placeanddirectionofoccurence));
                    sp.Add(new SqlParameter("@Reason ", model.reason));
                    sp.Add(new SqlParameter("@Particularsofpropertystolen ", model.particularsofpropertystolen));
                    sp.Add(new SqlParameter("@Totalvalue ", model.totalvalue));
                    model.fircriminals = string.Join(",", model.CriminalId);
                    sp.Add(new SqlParameter("@FirCriminals ", model.fircriminals));
                    string query = string.Format(Consvalues.FIRcheckinsert, model.firno);
                    DataTable dt = _helper.GetQuerydetails(query);
                    if (model.id > 0)
                    {
                        FIRmodel editdetailget = new FIRmodel();
                        editdetailget = Editdetails(model.id);
                        if (editdetailget != null)
                        {
                            if (editdetailget.firno.Trim() == model.firno.Trim())
                            {
                                int NewId = _helper.OutputResultID(Consvalues.AddFIR.ToString(), sp);
                                TempData["Sucessmessage"] = "Updated Sucessfully";
                                return RedirectToAction("FIRList");

                            }
                            else
                            {
                                ModelState.AddModelError("", "Please check FIR Number is Wrong");
                            }
                        }

                    }
                    else
                    {
                        if ((dt != null) && (dt.Rows.Count == 0))
                        {
                            int NewId = _helper.OutputResultID(Consvalues.AddFIR.ToString(), sp);
                            if (NewId > 0)
                            {
                                TempData["Sucessmessage"] = "Inserted Sucessfully";
                                return RedirectToAction("FIRList");
                            }
                            else
                            {
                                ModelState.AddModelError("", "Please enter the all details");
                            }

                        }
                        else
                        {
                            ModelState.AddModelError("", "FIR Number Exist");
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
        /// <summary>
        /// Edit time values get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private FIRmodel Editdetails(int id)
        {
            FIRmodel model = new FIRmodel();
            string editdetails = string.Format(Consvalues.SingleFIRget, id);
            DataTable dt = _helper.GetQuerydetails(editdetails);
            if ((dt != null) && (dt.Rows.Count > 0))
                model = TabletoList.ConvertDataTablemodel<FIRmodel>(dt);
            return model;
        }

        /// <summary>
        /// Criminal detial load to criminal dropdown
        /// </summary>
        private void CriminalDropdown()
        {
            DataTable dt = _helper.GetQuerydetails(Consvalues.CriminalDropdownvalue);
            if ((dt != null) && (dt.Rows.Count > 0))
            Lstcriminal = TabletoList.ConvertDataTable<DropdownModel>(dt);
            ViewBag.Criminallist = Lstcriminal;
        }
    }
}