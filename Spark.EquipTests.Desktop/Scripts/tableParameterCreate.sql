USE [SparcEquipTest]
GO

/****** Object:  Table [dbo].[Parameters]    Script Date: 16.06.2024 21:43:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Parameters](
	[ParameterId] [int] IDENTITY(1,1) NOT NULL,
	[TestId] [int] NOT NULL,
	[ParameterName] [nvarchar](200) NOT NULL,
	[RequiredValue] [decimal](18, 0) NOT NULL,
	[MeasuredValue] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_Parameters] PRIMARY KEY CLUSTERED 
(
	[ParameterId] ASC,
	[TestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Parameters]  WITH CHECK ADD  CONSTRAINT [FK_Parameters_Tests] FOREIGN KEY([TestId])
REFERENCES [dbo].[Tests] ([TestId])
GO

ALTER TABLE [dbo].[Parameters] CHECK CONSTRAINT [FK_Parameters_Tests]
GO

