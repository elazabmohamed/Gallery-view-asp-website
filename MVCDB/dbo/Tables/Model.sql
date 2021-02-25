CREATE TABLE [dbo].[Model]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Modelid] INT NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Price] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [Size] NVARCHAR(50) NOT NULL, 
    [Platform] NVARCHAR(100) NOT NULL, 
    [Category] NVARCHAR(50) NOT NULL, 
    [Material] NVARCHAR(50) NOT NULL, 
    [Style] NVARCHAR(50) NOT NULL, 
    [Render] NVARCHAR(50) NOT NULL, 
    [Color] NVARCHAR(50) NOT NULL, 
    [Tag] NVARCHAR(MAX) NULL, 
    [FileName] NVARCHAR(100) NOT NULL, 
    [ImagePath] NVARCHAR(MAX) NOT NULL, 
    [FilePath] NVARCHAR(MAX) NOT NULL
)
