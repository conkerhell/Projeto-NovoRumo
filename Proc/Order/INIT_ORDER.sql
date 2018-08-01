use NovoRumo
go

/****** Object:  Table [dbo].[Type]    Script Date: 6/19/2018 9:25:11 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Type](
	[TypeId] [int] NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[Description] [varchar](500) NULL,
 CONSTRAINT [PK_Type] PRIMARY KEY CLUSTERED 
(
	[TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

INSERT INTO [dbo].[Type] (TypeId, Name, Description) VALUES (1, 'Monthly Donation', '')
INSERT INTO [dbo].[Type] (TypeId, Name, Description) VALUES (2, 'Single Donation', '')
INSERT INTO [dbo].[Type] (TypeId, Name, Description) VALUES (3, 'Bank Transfer', '')
INSERT INTO [dbo].[Type] (TypeId, Name, Description) VALUES (4, 'Purchase', '')

/****** Object:  Table [dbo].[StatusDomain]    Script Date: 7/8/2018 12:17:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[StatusDomain](
	[StatusId] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_StatusDomain] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO [dbo].[StatusDomain] (StatusId, Name) VALUES (1, 'Awaiting for payment')
INSERT INTO [dbo].[StatusDomain] (StatusId, Name) VALUES (2, 'In Analysis')
INSERT INTO [dbo].[StatusDomain] (StatusId, Name) VALUES (3, 'Payed')
INSERT INTO [dbo].[StatusDomain] (StatusId, Name) VALUES (4, 'Available')
INSERT INTO [dbo].[StatusDomain] (StatusId, Name) VALUES (5, 'In Dispute')
INSERT INTO [dbo].[StatusDomain] (StatusId, Name) VALUES (6, 'Returned')
INSERT INTO [dbo].[StatusDomain] (StatusId, Name) VALUES (7, 'Cancelled')

/****** Object:  Table [dbo].[Order]    Script Date: 6/19/2018 9:24:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Order](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[TypeId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[NotificationCode] [varchar](50) NULL,
	[PaypalGuid] [varchar](50) NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[RecordDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Type] FOREIGN KEY([TypeId])
REFERENCES [dbo].[Type] ([TypeId])
GO

ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Type]
GO

ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO

ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_User]
GO



/****** Object:  Table [dbo].[Status]    Script Date: 6/19/2018 9:25:35 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OrderStatus](
	[OrderId] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[RecordDate] [datetime] NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[OrderStatus]  WITH CHECK ADD  CONSTRAINT [FK_OrderStatus_StatusDomain] FOREIGN KEY([StatusId])
REFERENCES [dbo].[StatusDomain] ([StatusId])
GO

ALTER TABLE [dbo].[OrderStatus] CHECK CONSTRAINT [FK_OrderStatus_StatusDomain]
GO

ALTER TABLE [dbo].[OrderStatus]  WITH CHECK ADD  CONSTRAINT [FK_Status_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([OrderId])
GO

ALTER TABLE [dbo].[OrderStatus] CHECK CONSTRAINT [FK_Status_Order]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE spGetOrders
AS
BEGIN
SELECT OrderId, Typeid, UserId, NotificationCode, PaypalGuid, RecordDate, Total FROM [dbo].[Order] WITH (NOLOCK)
END

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE spGetOrderById(
	@OrderId AS INT
)
AS
BEGIN
SELECT OrderId, Typeid, UserId, NotificationCode, PaypalGuid, RecordDate, Total 
  FROM [dbo].[Order] WITH (NOLOCK)
 WHERE OrderId = @OrderId
END
	
	

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE spInsertOrder(
	@UserId AS INT,
	@TypeId AS INT,
	@NotificationCode AS VARCHAR(50),
	@PaypalGuid AS VARCHAR(50),
	@Total AS DECIMAL(18, 2),
	@RecordDate AS DATE
)
AS
BEGIN
INSERT INTO [dbo].[Order] (
	UserId,
	TypeId,
	NotificationCode,
	PaypalGuid,
	Total,
	RecordDate
) VALUES (
	@UserId,
	@TypeId,
	@NotificationCode,
	@PaypalGuid,
	@Total,
	@RecordDate
)

SELECT SCOPE_IDENTITY() 

END

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE spUpdateOrder(
	@OrderId AS INT,
	@NotificationCode AS VARCHAR(50),
	@PaypalGuid AS VARCHAR(50)
)
AS
BEGIN
UPDATE [dbo].[Order]
   SET NotificationCode = @NotificationCode,
	   PaypalGuid = @PaypalGuid
 WHERE OrderId = @OrderId
END


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE spInsertOrderStatus(
	@OrderId AS INT,
	@StatusId AS INT ,
	@RecordDate AS DATE
)
AS
BEGIN
INSERT INTO [dbo].[OrderStatus] (
	OrderId,
	StatusId,
	RecordDate
) VALUES (
	@OrderId,
	@StatusId,
	@RecordDate
)
END

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE spGetStatusByOrderId(
	@OrderId AS INT
)
AS
BEGIN
SELECT OrderId, StatusId, RecordDate
  FROM [dbo].[OrderStatus] WITH (NOLOCK)
 WHERE OrderId = @OrderId
END


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE spGetDonations
AS
BEGIN
SELECT OrderId, RecordDate, 
		TypeId, UserId, 
		NotificationCode, 
		PaypalGuid, Total
  FROM [dbo].[Order] WITH (NOLOCK)
 WHERE TypeId IN (1, 2, 3)
END


