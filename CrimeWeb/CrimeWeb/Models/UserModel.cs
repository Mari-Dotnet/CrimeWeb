using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrimeWeb.Models
{
    public class UserModel:Basemodel
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string gender { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string contactno { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public DateTime lastlogin { get; set; }
    }
}