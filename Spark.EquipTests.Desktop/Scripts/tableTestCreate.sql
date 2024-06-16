USE [SparcEquipTest]
GO

/****** Object:  Table [dbo].[Tests]    Script Date: 16.06.2024 21:43:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tests](
	[TestId] [int] IDENTITY(1,1) NOT NULL,
	[TestDate] [smalldatetime] NOT NULL,
	[Blockname] [nvarchar](50) NOT NULL,
	[Note] [nvarchar](200) NULL,
 CONSTRAINT [PK_Tests] PRIMARY KEY CLUSTERED 
(
	[TestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

