using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CrimeWeb.Models
{
    public class ActionTakenModel : Basemodel
    {
        public int id { get; set; }
        [Display(Name = "Inverstigator Name")]
        public int investigatorId { get; set; }
        [Display(Name = "FIR NO")]
        public int firno { get; set; }
        [Required(ErrorMessage = "Please enter investigator Rank")]
        [Display(Name = "Inverstigator Rank")]
        public string investigatorrank { get; set; }
        [Required(ErrorMessage = " Please enter Refused Investigation")]
        [Display(Name = "Refused Investigation due to")]
        public string refusedinvestigation { get; set; }
        [Display(Name = "Tranfered to Police station")]
        [Required(ErrorMessage = "Plaese enter police station")]
        public string transferredps { get; set; }
        [Required(ErrorMessage = "Please enter District")]
        [Display(Name = "District")]
        public string district { get; set; }
        [Required(ErrorMessage = "Incharge officer ")]
        [Display(Name = "Name of Officer in charge policestation ")]
        public string nameofinchargeps { get; set; }
        [Display(Name = "Judgement Details")]
        [Required(ErrorMessage = "Please enter judgement")]
        public string judgementdetails { get; set; }
        public String InverstigatorName { get; set; }
        public String FIRNumber { get; set; }

    }
}