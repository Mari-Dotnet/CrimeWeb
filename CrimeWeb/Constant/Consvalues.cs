using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrimeWeb
{
    public static class Consvalues
    {
        #region User
        public static string AddUser = "proc_adduser";
        public static string LoginSelect = "select id ,username,password from user_details (nolock) where username='{0}' and Isactive=1";
        public static string UserNameselect = "select Username from user_details (nolock) where username='{0}' and Isactive=1 ";
        public static string Lastloginupdate = "update user_details set lastlogin=getdate() where id={0}";
        #endregion

        #region Invstigater
        public static string AddInvstigater = "proc_addinvestigator";
        public static string Investigatordetailget = "select * from investigator_details (nolock) where Isactive=1";
        public static string SingleInvestigatorget = "select * from investigator_details (nolock) where id='{0}' and Isactive=1";
        public static string Investigatorcheckinsert = "select investigatorid  from [dbo].[investigator_details] (nolock) where investigatorid='{0}'and Isactive=1";
        public static string Investigatordropdown = "select id as Id, (investigatorname+' ( '+investigatorid+' )') as Name from[dbo].[investigator_details] (nolock) where Isactive=1";
        
        #endregion

        #region Criminal
        public static string AddCriminal = "proc_addcriminal";
        public static string Criminaldetailget = "select * from criminal_details (nolock) where Isactive=1";
        public static string SingleCriminalget = "select * from criminal_details (nolock) where id='{0}' and Isactive=1";
        public static string Criminalcheckinsert = "select CriminalNumber  from criminal_details (nolock) where CriminalNumber='{0}'and Isactive=1";
        public const string CriminalDropdownvalue = "select Id,(name+'_'+CriminalNumber) as Name from criminal_details(nolock) where Isactive = 1";

        #endregion

        #region FIR
        public static string AddFIR = "proc_addfir";
        public static string FIRdetailget = "select *from FIR (nolock)";
        public static string SingleFIRget = "select *from FIR (nolock) where Id='{0}'";
        public static string FIRcheckinsert = "select firno from FIR (nolock) where firno='{0}'";
        public static string FIRDropdownvalue = "select id as Id,firno as Name from FIR (nolock)";
        #endregion 
        
        #region ActionTaken 
        public static string AddAction = "proc_addactiontaken";
        public static string Actiondetailget = "select act.Id as id,Ivg.investigatorname as InverstigatorName ,FR.firno as FIRNumber,act.judgementdetails,act.refusedinvestigation from action_taken as act (nolock)inner join investigator_details as Ivg(nolock) on act.investigatorId=Ivg.id and Ivg.Isactive= 1 inner join [dbo].[FIR] as FR (nolock) on act.firno= FR.id";
        public static string Singleactionget = "select *from action_taken (nolock) where Id='{0}'";
        public static string Actioninsertcheck = "select firno from action_taken (nolock) where firno='{0}'";
        #endregion

    }
}