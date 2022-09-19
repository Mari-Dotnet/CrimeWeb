using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CrimeWeb.Models
{
    public class FIRmodel:Basemodel
    {

        public int id { get; set; }
        [Display(Name ="FIR NO")]
        [Required(ErrorMessage ="Please enter FIR No")]
        public string firno { get; set; }
        [Display(Name = "District")]
        [Required(ErrorMessage = "District")]
        public string district { get; set; }
        [Required(ErrorMessage = "Please enter Police Station")]
        [Display(Name = "Police station")]
        public string policestation { get; set; }
        [Required(ErrorMessage = "Please enter FIR year")]
        [Display(Name = "Fir year")]
        public int firyear { get; set; }
        [Display(Name = "Fir Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please enter FIR date")]
        public DateTime firdate { get; set; }
        [Required(ErrorMessage = "Please enter ACT 1")]
        [Display(Name = "ACT 1")]
        public string act1 { get; set; }
        [Required(ErrorMessage = "Please enter Section 1")]
        [Display(Name = "Section 1")]
        public string section1 { get; set; }
        [Display(Name = "ACT 2")]
        public string act2 { get; set; }
        [Display(Name = "Section 2")]
        public string section2 { get; set; }
        [Display(Name = "Other act and section")]
        public string otheractandsection { get; set; }
        [Required(ErrorMessage = "Please enter Day")]
        [Display(Name = "Occurence day")]
        public string occurenceday { get; set; }
        [Required(ErrorMessage = "Please enter Date")]
        [DataType(DataType.Date)]
        [Display(Name = "Occurence date")]
        public DateTime occurencedate { get; set; }
        [Display(Name = "Time period")]        
        public string timeperiod { get; set; }
        [Required(ErrorMessage = "Please enter Time From")]
        [Display(Name = "Time From")]
        [DataType(DataType.Time)]
        public TimeSpan timefrom { get; set; }
        [Display(Name = "Time To")]
        [Required(ErrorMessage = "Please enter Time To")]
        [DataType(DataType.Time)]
        public TimeSpan timeto { get; set; }
        [Required(ErrorMessage = "Please enter Police station name")]
        [Display(Name = "Information received at PS")]
        public string inforeceivedps { get; set; }
        [Display(Name = "Information date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please enter Information date")]
        public DateTime infodate { get; set; }
        [DataType(DataType.Time)]
        [Display(Name = "Information Time")]
        [Required(ErrorMessage = "Please enter Information Time")]
        public TimeSpan infotime { get; set; }
        [Required(ErrorMessage = "Please enter Ref No")]
        [Display(Name = "Diary Ref No")]
        public string dairyrefno { get; set; }
        [Display(Name = "Place and Direction")]
        [Required(ErrorMessage = "Please enter Place")]
        public string placeanddirectionofoccurence { get; set; }
        [Display(Name = "Reason for delay in reporting by the commision")]
        public string reason { get; set; }
        [Display(Name = "Particular of Property Stolen")]
        [Required(ErrorMessage = "Please enter property stolen")]
        public string particularsofpropertystolen { get; set; }
        [Display(Name = "Total value of Property Stolen")]
        [Required(ErrorMessage = "Please enter Total value stolen")]
        public decimal totalvalue { get; set; }
        public string fircriminals { get; set; }
        [Display(Name = "FIR Criminals")]
        public int[] CriminalId { get; set; }

        public string FIRdatestr { get; set; }
        public string Occurancedatestr { get; set; }
        public string informdatestr { get; set; }
      
    }
}