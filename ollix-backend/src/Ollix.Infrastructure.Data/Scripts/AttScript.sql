BEGIN TRANSACTION;
GO

CREATE TABLE [ClientApp] (
    [Id] uniqueidentifier NOT NULL,
    [CompanyName] nvarchar(400) NOT NULL,
    [BussinessName] nvarchar(400) NOT NULL,
    [Cnpj] nvarchar(18) NULL,
    CONSTRAINT [PK_ClientApp] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [UserApp] (
    [Id] uniqueidentifier NOT NULL,
    [FirstName] nvarchar(100) NOT NULL,
    [LastName] nvarchar(200) NULL,
    [ClientId] uniqueidentifier NOT NULL,
    [UserType] int NOT NULL,
    [UserEmail] nvarchar(200) NOT NULL,
    [UserPassword] nvarchar(200) NOT NULL,
    CONSTRAINT [PK_UserApp] PRIMARY KEY ([Id])
);
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserApp]') AND [c].[name] = N'FirstName');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [UserApp] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [UserApp] ALTER COLUMN [FirstName] nvarchar(200) NOT NULL;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [LogApp] (
    [Id] uniqueidentifier NOT NULL,
    [Entity] int NOT NULL,
    [Operation] int NOT NULL,
    [EntityId] uniqueidentifier NOT NULL,
    [ClientId] uniqueidentifier NOT NULL,
    [UserId] uniqueidentifier NOT NULL,
    [Date] datetimeoffset NOT NULL,
    CONSTRAINT [PK_LogApp] PRIMARY KEY ([Id])
);
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE INDEX [IX_UserApp_ClientId] ON [UserApp] ([ClientId]);
GO

ALTER TABLE [UserApp] ADD CONSTRAINT [FK_UserApp_ClientApp_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [ClientApp] ([Id]) ON DELETE CASCADE;
GO

COMMIT;
GO


BEGIN TRANSACTION;
GO

ALTER TABLE [LogApp] DROP CONSTRAINT [FK_LogApp_ClientApp_ClientId];
GO

ALTER TABLE [LogApp] DROP CONSTRAINT [FK_LogApp_UserApp_UserId];
GO

ALTER TABLE [LogApp] ADD CONSTRAINT [FK_LogApp_ClientApp_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [ClientApp] ([Id]) ON DELETE NO ACTION;
GO

ALTER TABLE [LogApp] ADD CONSTRAINT [FK_LogApp_UserApp_UserId] FOREIGN KEY ([UserId]) REFERENCES [UserApp] ([Id]) ON DELETE NO ACTION;
GO

COMMIT;
GO

