using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrimeWeb.Models
{
    public class SearchModel
    {
        public string Searchvalue { get; set; }
        public  List<ActionTakenModel> ActionList { get; set; }
        public  List<FIRmodel> FIRList { get; set; }
        public  List<InvestigatorModel> InvestigatorList { get; set; }
        public  List<Criminalmodel> CriminalList { get; set; }
    }
}