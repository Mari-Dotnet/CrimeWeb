using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrimeWeb.Models
{
    public class LoginModel
    {
        public int UserId { get; set; }
        [Required(ErrorMessage ="Please enter the UserName")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter the Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}