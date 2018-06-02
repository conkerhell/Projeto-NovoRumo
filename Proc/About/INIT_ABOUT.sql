USE [NovoRumo]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[About](
	[AboutID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](20) NOT NULL,
	[Description] [varchar](2000) NOT NULL,
	[Filename] [varchar](100) NOT NULL,
	[Data] [datetime] NOT NULL,
 CONSTRAINT [PK_About] PRIMARY KEY CLUSTERED 
(
	[AboutID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spDeleteAbout]

	@AbouID int
	
AS
BEGIN
DELETE FROM About WHERE AboutID = @AbouID
END

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetAbout] 

AS
BEGIN
	SELECT AboutID, Title, Description,Filename,data 
  FROM About WITH (NOLOCK)
END

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetAboutById] 
	@AboutID as int
AS
BEGIN
	SELECT AboutID, Title, Description,Filename,data
  FROM About WITH (NOLOCK)
 WHERE AboutID = AboutID
END

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetNewestAbout] 

AS
BEGIN
	
	SELECT top 2 AboutID, Title, Description,Filename, Data   
	 FROM About WITH (NOLOCK)
ORDER BY Data 
END

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spInsertAbout]
	@Title as varchar(20),
	@Description as varchar(2000),
	@Filename as varchar(100),
	@Data as datetime

	AS
BEGIN
	INSERT About (Title,Description,Filename,Data) values(@Title,@Description,@Filename,@Data)
END

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spUpdateAbout]
	@AboutID as int,
	@Title as varchar(20),
	@Description as varchar(2000),
	@Filename as varchar(100),
	@Data as datetime
AS
BEGIN
	
	UPDATE About 
   SET Title = @Title,
	   Description = @Description,
	   Filename = @Filename,
	   Data = @Data
 WHERE AboutID = @AboutID
	
END















