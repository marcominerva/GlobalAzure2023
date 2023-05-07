CREATE TABLE [dbo].[People] (
    [Id]        UNIQUEIDENTIFIER NOT NULL,
    [FirstName] NVARCHAR (50)    NOT NULL,
    [LastName]  NVARCHAR (50)    NULL,
    [City]      NVARCHAR (80)    NOT NULL
);
GO

ALTER TABLE [dbo].[People]
    ADD CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED ([Id] ASC);
GO

ALTER TABLE [dbo].[People]
    ADD CONSTRAINT [DF_People_Id] DEFAULT (newid()) FOR [Id];
GO

