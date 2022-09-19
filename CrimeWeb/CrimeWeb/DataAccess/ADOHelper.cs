using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using CrimeWeb.Models;
using CrimeWeb.DataAccess;
using CrimeWeb.Constant;

namespace CrimeWeb.DataAccess
{
    public class ADOHelper:IADOHelper
    {
        private SqlConnection connection = null;
        public string Connectionstring = System.Configuration.ConfigurationManager.AppSettings["SqlConnection"];
        private int timeoutconnection = 180;
        private void OpenConnection()
        {
            if((connection == null)||(connection.State!=ConnectionState.Open))
            {
                connection = new SqlConnection(Connectionstring);
                connection.Open();
            }
        }

        private void CloseConnection()
        {
            if ((connection != null)&&(connection.State==ConnectionState.Open))
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Method for to retrive the data
        /// </summary>
        /// <param name="SPname"></param>
        /// <param name="Params"></param>
        /// <returns></returns>
        public DataTable Get(string SPname, List<SqlParameter> Params)
        {
            try
            {
                DataTable DT = null;
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(SPname, connection))
                {
                    cmd.CommandTimeout = timeoutconnection;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    if (Params != null)
                    {
                        foreach (SqlParameter param in Params)
                            cmd.Parameters.Add(param);
                    }

                    using (SqlDataReader sqlreader = cmd.ExecuteReader())
                    {
                        DT = new DataTable();
                        DT.Load(sqlreader);
                    }
                    return DT;
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendErrorToText(ex);
                return new DataTable();
            }
            finally
            {
                CloseConnection();
            }
            
        }

      
        /// <summary>
        /// Method for to delete the data
        /// </summary>
        /// <param name="SPname"></param>
        /// <param name="Params"></param>
        /// <returns></returns>
        public string OutputResult(string SPname, List<SqlParameter> Params)
        {
            try
            {
                string result = string.Empty;
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(SPname, connection))
                {
                    cmd.CommandTimeout = timeoutconnection;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    if (Params != null)
                    {
                        foreach (SqlParameter param in Params)
                            cmd.Parameters.Add(param);
                    }

                    using (SqlDataReader sqlreader = cmd.ExecuteReader())
                    {
                        while (sqlreader.Read())
                        {
                            result = sqlreader["Result"].ToString();
                        }
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendErrorToText(ex);
                return "Failure";
            }
            finally
            {
                CloseConnection();
            }
           
        }
        /// <summary>
        /// Method for insert/update the data
        /// </summary>
        /// <param name="SPname"></param>
        /// <param name="Params"></param>
        /// <returns></returns>
        public int OutputResultID(string SPname, List<SqlParameter> Params)
        {
            int result = 0;
            try
            {
                
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(SPname, connection))
                {
                    cmd.CommandTimeout = timeoutconnection;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    if (Params != null)
                    {
                        foreach (SqlParameter param in Params)
                            cmd.Parameters.Add(param);
                    }

                    using (SqlDataReader sqlreader = cmd.ExecuteReader())
                    {
                        while (sqlreader.Read())
                        {
                            result = Convert.ToInt32(sqlreader["Result"]);
                        }
                    }
                    return result;
                }

               
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendErrorToText(ex);
                string exe = ex.Message;
                return result;
            }
            finally
            {
                CloseConnection();
            }

           
        }
        /// <summary>
        /// direct Query execute and get datatable result 
        /// </summary>
        /// <param name="Querytext"></param>
        /// <returns></returns>
        public DataTable GetQuerydetails(string Querytext)
        {
            try
            {
                DataTable DT = null;
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(Querytext, connection))
                {
                    cmd.CommandTimeout = timeoutconnection;
                    cmd.CommandType = System.Data.CommandType.Text;
                    using (SqlDataReader sqlreader = cmd.ExecuteReader())
                    {
                        DT = new DataTable();
                        DT.Load(sqlreader);
                    }
                    return DT;
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendErrorToText(ex);
                return new DataTable();
            }
            finally
            {
                CloseConnection();
            }

        }


        public void Lastloginupdate(string Querytext)
        {
            try
            {
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(Querytext, connection))
                {
                    cmd.CommandTimeout = timeoutconnection;
                    cmd.CommandType = System.Data.CommandType.Text;
                    int rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendErrorToText(ex);
                throw ex;
                
            }
            finally
            {
                CloseConnection();
            }

        }

    }
}