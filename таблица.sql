USE [Accounting of medicines]
GO

/****** Object:  Table [dbo].[Medicines]    Script Date: 05.04.2023 8:41:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Medicines](
	[Name of the medicine] [nvarchar](50) NOT NULL,
	[Cost] [decimal](12, 2) NULL,
	[Number of units] [int] NULL,
	[Product date] [date] NULL,
	[Expiration date] [date] NULL,
	[Factory name] [nvarchar](50) NOT NULL,
	[Factory address] [nvarchar](250) NULL,
 CONSTRAINT [PK_Medicines] PRIMARY KEY CLUSTERED 
(
	[Name of the medicine] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


