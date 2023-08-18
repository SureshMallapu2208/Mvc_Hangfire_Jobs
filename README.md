# Mvc_Hangfire_Jobs

Step 1:	Add below Nuget packages 

<PackageReference Include="Hangfire" Version="1.8.5" />
<PackageReference Include="Hangfire.Core" Version="1.8.5" />
<PackageReference Include="Hangfire.AspNetCore" Version="1.8.5" />
<PackageReference Include="Hangfire.SqlServer" Version="1.8.5" />

Step 2:
Create Database "Mphasis"

Step 3:
Create table with below script
USE [Mphasis]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Requests](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NULL,
	[RequestType] [varchar](50) NULL,
	[RequestMessage] [text] NULL,
 CONSTRAINT [PK_Requests] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Requests] ADD  CONSTRAINT [DF_Requests_Id]  DEFAULT (newid()) FOR [Id]
GO


Step 4:
Change the local connection string in appsettings.json file


