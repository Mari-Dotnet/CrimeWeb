using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrimeWeb.DataAccess;
using CrimeWeb.Models;

namespace CrimeWeb.Controllers
{
    public class SearchController : Controller
    {
        private ADOHelper _helper = new ADOHelper();
        // GET: Search
        public ActionResult searchList()
        {
            SearchModel model= new SearchModel();
            model.FIRList = new List<FIRmodel>();
            model.ActionList = new List<ActionTakenModel>();
            model.CriminalList = new List<Criminalmodel>();
            model.InvestigatorList = new List<InvestigatorModel>();
            return View(model);
        }
        [HttpPost]
        public ActionResult searchList(SearchModel model)
        {
            model.FIRList = new List<FIRmodel>();
            model.ActionList = new List<ActionTakenModel>();
            model.CriminalList = new List<Criminalmodel>();
            model.InvestigatorList = new List<InvestigatorModel>();

            if (model.Searchvalue == "Investigator")
            {
                DataTable dt = _helper.GetQuerydetails(Consvalues.Investigatordetailget);
                if ((dt != null) && (dt.Rows.Count > 0))
                    model.InvestigatorList = TabletoList.ConvertDataTable<InvestigatorModel>(dt);

            }
            else if(model.Searchvalue == "Criminal")
            {
                DataTable dt = _helper.GetQuerydetails(Consvalues.Criminaldetailget);
                if ((dt != null) && (dt.Rows.Count > 0))
                    model.CriminalList = TabletoList.ConvertDataTable<Criminalmodel>(dt);

            }
            else if (model.Searchvalue == "FIR")
            {
                DataTable dt = _helper.GetQuerydetails(Consvalues.FIRdetailget);
                if ((dt != null) && (dt.Rows.Count > 0))
                    model.FIRList = TabletoList.ConvertDataTable<FIRmodel>(dt);
            }
            else if (model.Searchvalue == "Actiontaken")
            {
                DataTable dt = _helper.GetQuerydetails(Consvalues.Actiondetailget);
                if ((dt != null) && (dt.Rows.Count > 0))
                    model.ActionList = TabletoList.ConvertDataTable<ActionTakenModel>(dt);
            }
            
            return View(model);
        }
    }
}