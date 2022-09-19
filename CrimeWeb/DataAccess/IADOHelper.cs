using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace CrimeWeb.DataAccess
{
    interface IADOHelper 
    {
        DataTable Get(String SPname , List<SqlParameter> Params);
        string OutputResult(String SPname, List<SqlParameter> Params);
        int OutputResultID(String SPname, List<SqlParameter> Params);
    }

    

}