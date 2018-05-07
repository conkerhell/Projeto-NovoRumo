USE [NovoRumo]
GO

/****** Object:  Table [dbo].[Contact]    Script Date: 4/29/2018 5:11:17 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Contact](
	[ContactID] [int] NOT NULL,
	[Telephone] [varchar](20) NULL,
	[Mobile] [varchar](20) NULL,
	[SecondaryMobile] [varchar](20) NULL,
	[Address] [varchar](500) NULL,
	[CEP] [varchar](9) NULL,
	[Email] [varchar](200) NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[ContactID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO Contact(
	ContactID,
	Address, 
	CEP,
	Email,
	Mobile, 
	SecondaryMobile, 
	Telephone) 
 VALUES (
	1,
	'Rua Papa Paulo VI, 182 <br> Vila Thais - Atibaia, SP',
	'12345-789',
	'contato@novorumoatibaia.com.br',  
	'(11) 1234-5667', 
	'(11) 1234-5667', 
	'(11) 1234-5667')

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE spUpdateContact(
	@Telephone AS VARCHAR(20),
	@Mobile AS VARCHAR(20),
	@SecondaryMobile AS VARCHAR(20),
	@Address AS VARCHAR(500),
	@CEP AS VARCHAR(9),
	@Email AS VARCHAR(200)
)
AS
BEGIN
UPDATE [dbo].[Contact] SET
  Telephone = @Telephone,
  Mobile = @Mobile,
  SecondaryMobile = @SecondaryMobile,
  Address = @Address,
  CEP = @CEP,
  Email = @Email
  WHERE ContactID = 1
END


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE spGetContact
AS
BEGIN
SELECT TOP 1 Address, CEP, Email, Mobile, SecondaryMobile, Telephone FROM [dbo].[Contact] WITH (NOLOCK)
END