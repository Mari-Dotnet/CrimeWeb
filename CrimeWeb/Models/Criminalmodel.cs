using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CrimeWeb.Models
{
    public class Criminalmodel : Basemodel
    {
        public int id { get; set; }
        [Display(Name="Name")]
        [Required(ErrorMessage ="Please enter the Name")]
        public string name { get; set; }
        [Display(Name = "Criminal Id")]
        [Required(ErrorMessage = "Please enter the criminal number")]
        public string CriminalNumber { get; set; }
        [Display(Name = "Father name")]
        [Required(ErrorMessage = "Please enter the father name")]
        public string fathername { get; set; }
        public string gender { get; set; }
        [Display(Name = "DOB")]
        [Required(ErrorMessage = "Please enter the DOB"),DataType(DataType.Date)]
        public DateTime dob { get; set; }
        [Display(Name = "Place of birth")]
        public string placeofbirth { get; set; }
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please enter the Address")]
        public string address { get; set; }
        [Display(Name = "Hair color (Black/Grey)")]
        [Required(ErrorMessage = "Please enter the hair color")]
        public string haircolour { get; set; }
        [Display(Name = "Color (Fair/Dark)")]
        [Required(ErrorMessage = "Please enter the color")]
        public string colour { get; set; }
        [Display(Name = "Body Marks")]
        [Required(ErrorMessage = "Please enter the body marks")]
        public string bodymarks { get; set; }
        public string DOBstring { get; set; }
        [Required(ErrorMessage = "Please enter the Nationality")]
        public string Nationality { get; set; }
        public string Imagepath { get; set; }
    }
}