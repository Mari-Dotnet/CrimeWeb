using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CrimeWeb.Models
{
    public abstract class Basemodel
    {
        [ScaffoldColumn(false)]
        public int createdby
        {
            get
            {
                if (HttpContext.Current.Session["UserId"]!=null)
                {
                    return Convert.ToInt32(HttpContext.Current.Session["UserId"]);
                }
                return 0;
            }
            set { }
        }
        [ScaffoldColumn(false)]
        public DateTime createdate { get; set; }
        [ScaffoldColumn(false)]
        public bool Isactive { get; set; }
        [ScaffoldColumn(false)]
        public string LoginUsername
        {
            get
            {
                if (HttpContext.Current.Session["Username"] != null)
                {
                    return Convert.ToString(HttpContext.Current.Session["Username"]);
                }
                return string.Empty;
            }
            set { }
        }
    }
}