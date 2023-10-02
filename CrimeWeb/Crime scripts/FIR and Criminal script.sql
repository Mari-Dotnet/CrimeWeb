USE [CrimeWeb]
GO
/****** Object:  Table [dbo].[criminal_details]    Script Date: 05-04-2022 14:45:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[criminal_details](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[CriminalNumber] [varchar](50) NULL,
	[fathername] [varchar](50) NULL,
	[gender] [char](1) NULL,
	[dob] [date] NULL,
	[placeofbirth] [varchar](50) NULL,
	[address] [text] NULL,
	[haircolour] [varchar](50) NULL,
	[colour] [varchar](10) NULL,
	[bodymarks] [text] NULL,
	[createdby] [int] NULL,
	[createdate] [datetime] NULL,
	[Isactive] [bit] NULL,
	[Nationality] [varchar](20) NULL,
	[Imagepath] [nvarchar](100) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FIR]    Script Date: 05-04-2022 14:45:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FIR](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[firno] [varchar](50) NULL,
	[district] [varchar](50) NULL,
	[policestation] [varchar](50) NULL,
	[firyear] [int] NULL,
	[firdate] [date] NULL,
	[act1] [varchar](50) NULL,
	[section1] [varchar](50) NULL,
	[act2] [varchar](50) NULL,
	[section2] [varchar](50) NULL,
	[otheractandsection] [text] NULL,
	[occurenceday] [varchar](20) NULL,
	[occurencedate] [date] NULL,
	[timeperiod] [time](7) NULL,
	[timefrom] [datetime] NULL,
	[timeto] [datetime] NULL,
	[inforeceivedps] [varchar](50) NULL,
	[infodate] [date] NULL,
	[infotime] [time](7) NULL,
	[dairyrefno] [varchar](25) NULL,
	[placeanddirectionofoccurence] [text] NULL,
	[reason] [text] NULL,
	[particularsofpropertystolen] [text] NULL,
	[totalvalue] [numeric](12, 2) NULL,
	[fircriminals] [varchar](100) NULL,
	[createdby] [int] NULL,
	[createddate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[criminal_details] ADD  DEFAULT (getdate()) FOR [createdate]
GO
ALTER TABLE [dbo].[criminal_details] ADD  DEFAULT ((1)) FOR [Isactive]
GO
ALTER TABLE [dbo].[FIR] ADD  DEFAULT (getdate()) FOR [createddate]
GO
/****** Object:  StoredProcedure [dbo].[proc_addcriminal]    Script Date: 05-04-2022 14:45:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_addcriminal]      
(      
@Id int=0,      
@Name varchar(50)=null,      
@CriminalNumber varchar(50)=null,      
@FatherName varchar(50)='',      
@Gender char=null,      
@DOB date=null,      
@Placeofbirth varchar(50)='',      
@Address text='',      
@Haircolour varchar(50)='',      
@Colour varchar(10)='',      
@Bodymarks text='',    
@Nationality  nvarchar(20)='',
@Imagepath nvarchar(100) ='',
@Createdby int=0      
)      
AS      
BEGIN      
      SET NOCOUNT ON;      
   If(@Id>0)begin      
   Update criminal_details set      
   name=@Name,      
   CriminalNumber=@CriminalNumber,      
   fathername= @FatherName,      
   gender=@Gender,      
   dob=@DOB,      
   placeofbirth=@Placeofbirth,      
   address=@Address,      
   haircolour=@Haircolour,      
   colour=@Colour,      
   bodymarks=@Bodymarks,
   Nationality=@Nationality,
   Imagepath=@Imagepath
   select @Id as Result      
   end      
   else      
      INSERT INTO  criminal_details (name,CriminalNumber, fathername,gender,dob,placeofbirth,address, haircolour,colour,bodymarks,createdby,Nationality,Imagepath)      
      VALUES (@Name,@CriminalNumber, @FatherName, @Gender,@DOB,@Placeofbirth, @Address,@Haircolour,@Colour,@Bodymarks,@Createdby,@Nationality,@Imagepath)      
       select SCOPE_IDENTITY() as Result      
END 
GO
/****** Object:  StoredProcedure [dbo].[proc_addfir]    Script Date: 05-04-2022 14:45:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[proc_addfir]
(
@Id int=0,
@FirNo varchar(50)='',
@District varchar(50)='',
@Policestation varchar(50)='',
@FirYear int=null,
@FirDate date=null,
@Act1 varchar(50)='',
@Section1 varchar(50)='',
@Act2 varchar(50)='',
@Section2 varchar(50)='',
@Otheractandsection varchar(50)='',
@Occurenceday varchar(20)='',
@Occurencedate date=null,
@Timeperiod time=null,
@Timefrom time=null,
@Timeto time=null,
@Inforeceivedps varchar(50)='',
@Infodate date=null,
@Infotime time=null,
@Dairyrefno varchar(25)='',
@Placeanddirectionofoccurence text='',
@Reason text='',
@Particularsofpropertystolen text='',
@Totalvalue numeric(12,2)=null,
@FirCriminals varchar(100)='',
@Createdby int=0
)
AS
BEGIN
      SET NOCOUNT ON;
 If(@Id>0)begin
 Update FIR set
	firno=@FirNo                      
	,district=@District                   
	,policestation=@Policestation  
	,firyear=@FirYear              
	,firdate=@FirDate              
	,act1=@Act1                    
	,section1=@Section1            
	,act2=@Act2               		
	,section2=@Section2            
	,otheractandsection=@Otheractandsection               
	,occurenceday=@Occurenceday              
	,occurencedate= @Occurencedate                             
	,timeperiod=@Timeperiod                             
	,timefrom=@Timefrom                              
	,timeto=@Timeto                              
	,inforeceivedps=@Inforeceivedps                              
	,infodate= @Infodate                             
	,infotime= @Infotime                             
	,dairyrefno=@Dairyrefno                              
	,placeanddirectionofoccurence=@Placeanddirectionofoccurence                              
	,reason=@Reason                              
	,particularsofpropertystolen= @Particularsofpropertystolen                            
	,totalvalue= @Totalvalue                             
	,fircriminals=@FirCriminals                              
	,createdby =@Createdby  
where @id=id
 select @Id as Result
 end
 else
      INSERT INTO  FIR (firno,district,policestation,firyear,firdate,act1,section1,act2,section2,otheractandsection,occurenceday,
 occurencedate,timeperiod,timefrom,timeto,inforeceivedps,infodate,infotime,dairyrefno,placeanddirectionofoccurence,reason,particularsofpropertystolen,
 totalvalue,fircriminals,createdby)
      VALUES (@Firno,@District,@Policestation,@FirYear,@FirDate,@Act1,@Section1,@Act2,@Section2,@Otheractandsection,@Occurenceday,
@Occurencedate,@Timeperiod,@Timefrom,@Timeto,@Inforeceivedps,@Infodate,@Infotime,@Dairyrefno,@Placeanddirectionofoccurence,
@Reason,@Particularsofpropertystolen,@Totalvalue,@FirCriminals,@Createdby)
       select SCOPE_IDENTITY() as Result
 
END

GO
