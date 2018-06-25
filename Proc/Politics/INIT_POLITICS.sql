
USE [NovoRumo]
GO

/****** Object:  Table [dbo].[Politics]    Script Date: 25/06/2018 11:06:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Politics](
	[PoliticsID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](100) NOT NULL,
	[Description] [varchar](8000) NOT NULL,
 CONSTRAINT [PK_Politics] PRIMARY KEY CLUSTERED 
(
	[PoliticsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



USE [NovoRumo]
GO

/****** Object:  StoredProcedure [dbo].[spGetPolitics]    Script Date: 25/06/2018 11:05:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spGetPolitics]
	
AS
BEGIN
	--
	SELECT TOP 1 Title,Description from dbo.Politics WITH (NOLOCK)
END
GO


USE [NovoRumo]
GO

/****** Object:  StoredProcedure [dbo].[spUpdatePolitics]    Script Date: 25/06/2018 11:06:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spUpdatePolitics]
	-- Add the parameters for the stored procedure here
	@PoliticsID as int,
	@Title as varchar(20),
	@Description as varchar(3000)
AS
BEGIN
	UPDATE Politics 
   SET Title = @Title,
	   Description = @Description	   
 WHERE PoliticsID = @PoliticsID
END
GO


