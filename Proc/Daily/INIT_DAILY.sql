USE [NovoRumo]
GO

DROP TABLE [dbo].[Daily]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Daily](
	[DailyID] [int] IDENTITY(1,1) NOT NULL,
	[Filename] [varchar](100) NOT NULL,
	[Status] [bit] NOT NULL,
	[Data] [datetime] NOT NULL,
	[Title] [varchar](100) NOT NULL,
	[Description] [varchar](1000) NOT NULL,
 CONSTRAINT [PK_Daily] PRIMARY KEY CLUSTERED 
(
	[DailyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE [dbo].[spGetDaily]
GO

CREATE PROCEDURE spGetDaily
AS
BEGIN
SELECT DailyID, Filename, Status, Data, Title, Description
  FROM Daily WITH (NOLOCK)
END


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE [dbo].[spGetDailyById]
GO

CREATE PROCEDURE spGetDailyById( 
	@DailyID AS INT
)
AS 
BEGIN
SELECT DailyID, Filename, Status, Data, Title, Description
  FROM Daily WITH (NOLOCK)
 WHERE DailyID = @DailyID
END

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE [dbo].[spInsertDaily]
GO

CREATE PROCEDURE spInsertDaily(
	@Filename AS VARCHAR(100),
	@Status AS BIT,
	@Data AS DATETIME,
	@Title AS VARCHAR(100),
	@Description AS VARCHAR(1000)
)
AS
BEGIN
INSERT Daily (Filename, Status, Data, Title, Description) VALUES (@Filename, @Status, @Data, @Title, @Description) 
END

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE [dbo].[spUpdateDaily]
GO

CREATE PROCEDURE spUpdateDaily(
	@DailyID AS INT,
	@Filename AS VARCHAR(100),
	@Status AS BIT,
	@Data AS datetime,
	@Title AS VARCHAR(100),
	@Description AS VARCHAR(1000)
)
AS
BEGIN
UPDATE Daily 
   SET Filename = @Filename,
       Status = @Status,
	   Data = @Data,
	   Title = @Title,
	   Description = @Description
 WHERE DailyID = @DailyID
END

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE [dbo].[spDeleteDaily]
GO

CREATE PROCEDURE spDeleteDaily(
	@DailyID AS INT
)
AS
BEGIN
DELETE FROM Daily WHERE DailyID = @DailyID
END