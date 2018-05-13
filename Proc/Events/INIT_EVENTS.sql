USE [NovoRumo]
GO

/****** Object:  Table [dbo].[Event]    Script Date: 5/12/2018 1:53:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Event](
	[EventID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](200) NOT NULL,
	[Description] [varchar](1000) NOT NULL,
	[Data] [datetime] NOT NULL,
	[Endereco] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[EventID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE spGetEvents
AS
BEGIN
SELECT EventID, Title, Description, Data, Endereco FROM Event WITH (NOLOCK)
END


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE spGetEventById (
	@EventID AS INT
)
AS
BEGIN
SELECT EventID, Title, Description, Data, Endereco 
  FROM Event WITH (NOLOCK)
 WHERE EventID = @EventID
END


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE spInsertEvent(
	@Title AS VARCHAR(200),
	@Description AS VARCHAR(1000),
	@Data AS DATETIME,
	@Endereco AS VARCHAR(200)
)
AS
BEGIN
INSERT INTO Event (
		Title,
		Description,
		Data,
		Endereco
	) VALUES (
		@Title,
		@Description,
		@Data,
		@Endereco
	)
END


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE spUpdateEvent(
	@EventID AS INT,
	@Title AS VARCHAR(200),
	@Description AS VARCHAR(1000),
	@Data AS DATETIME,
	@Endereco AS VARCHAR(200)
)
AS
BEGIN
UPDATE Event
   SET Title = @Title,
       Description = @Description,
       Data = @Data,
       Endereco = @Endereco
 WHERE EventID = @EventID
END


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE spDeleteEventById(
	@EventID AS INT	
)
AS
BEGIN
DELETE FROM Event WHERE EventID = @EventID
END
