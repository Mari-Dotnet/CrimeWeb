using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CrimeWeb.Models
{
    public class InvestigatorModel:Basemodel
    {
        public int id { get; set; }

        [Display(Name = "Investigator Id")]
        [Required(ErrorMessage = "Please enter Investigator Id")]
        public string investigatorid { get; set; }
        [Required(ErrorMessage ="Please enter the Name"),MaxLength(25)]
        [Display(Name = "Investigator Name")]
        public string investigatorname { get; set; }
        [MaxLength(25)]
        [Display(Name = "Father Name")]
        public string fathersname { get; set; }
        [Required(ErrorMessage = "Please enter DOB"), DataType(DataType.Date)]
        [Display(Name = "DOB")]
        public DateTime dob { get; set; }
        [Required(ErrorMessage = "Please enter the Address")]
        [Display(Name = "Address")]
        public string address { get; set; }
        [Display(Name = "City")]
        public string city { get; set; }
        [Display(Name = "State")]
        public string state { get; set; }
        [Display(Name = "Pincode")]
        [StringLength(6,ErrorMessage ="Pincode have 6 digit")]
        public string pincode { get; set; }
        [Required(ErrorMessage ="Please enter date of join"),DataType(DataType.Date)]
        [Display(Name = "Date of Join")]
        public DateTime doj { get; set; }
        [Display(Name = "Station Name")]
        [Required(ErrorMessage = "Please enter station name ")]
        public string nameofthestation { get; set; }
        [Display(Name = "Location")]
        public string location { get; set; }

        public string DOBstring { get; set; }
        public string DOJstring { get; set; }
    }
}