USE [NovoRumo]
GO

/****** Object:  Table [dbo].[About]    Script Date: 15/05/2018 23:46:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[About](
	[AboutID] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](20) NOT NULL,
	[Descricao] [varchar](100) NOT NULL,
	[Filename] [varchar](100) NOT NULL,
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

CREATE PROCEDURE spUpdateAbout
	@AboutID as int,
	@Titulo as varchar(20),
	@Descricao as varchar(100),
	@Filename as varchar(100)
AS
BEGIN
	
	UPDATE About 
   SET Filename = @Filename,
       Titulo = @Titulo,
	   Descricao = @Descricao 
 WHERE AboutID = @AboutID
	
END
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
GO

USE [NovoRumo]
GO

/****** Object:  StoredProcedure [dbo].[spGetAbout]    Script Date: 15/05/2018 23:48:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetAbout] 

AS
BEGIN
	SELECT AboutID, Titulo, Descricao,Filename 
  FROM About WITH (NOLOCK)
END
GO


USE [NovoRumo]
GO

/****** Object:  StoredProcedure [dbo].[spGetAboutById]    Script Date: 15/05/2018 23:49:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetAboutById] 
	@AboutID as int
AS
BEGIN
	SELECT AboutID, Titulo, Descricao,Filename  
  FROM About WITH (NOLOCK)
 WHERE AboutID = AboutID
END
GO



USE [NovoRumo]
GO

/****** Object:  StoredProcedure [dbo].[spInsertAbout]    Script Date: 15/05/2018 23:49:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spInsertAbout]
	@Titulo as varchar(20),
	@Descricao as varchar(100),
	@Filename as varchar(100)

	AS
BEGIN
	INSERT About (Titulo,Descricao,Filename) values(@Titulo,@Descricao,@Filename)
END
GO

USE [NovoRumo]
GO

/****** Object:  StoredProcedure [dbo].[spGetNextAbout]    Script Date: 23/05/2018 08:32:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spGetNextAbout]

AS
BEGIN
	SELECT TOP 1 AboutID, Title, Description, Filename 
    FROM About WITH (NOLOCK)
ORDER BY Title 
END
GO






