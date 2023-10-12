CREATE TABLE [ClientApp] (
    [Id] uniqueidentifier NOT NULL,
    [CompanyName] nvarchar(400) NOT NULL,
    [BussinessName] nvarchar(400) NOT NULL,
    [Cnpj] nvarchar(18) NULL,
    CONSTRAINT [PK_ClientApp] PRIMARY KEY ([Id])
);

CREATE TABLE [UserApp] (
    [Id] uniqueidentifier NOT NULL,
    [FirstName] nvarchar(200) NOT NULL,
    [LastName] nvarchar(200) NULL,
    [UserType] int NOT NULL,
    [UserEmail] nvarchar(200) NOT NULL,
    [UserPassword] nvarchar(200) NOT NULL,
    [ClientId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_UserApp] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_UserApp_ClientApp_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [ClientApp] ([Id]) ON DELETE CASCADE
);


CREATE TABLE [LogApp] (
    [Id] uniqueidentifier NOT NULL,
    [Entity] int NOT NULL,
    [Operation] int NOT NULL,
    [EntityId] uniqueidentifier NOT NULL,
    [ClientId] uniqueidentifier NOT NULL,
    [UserName] nvarchar(500) NOT NULL,
    [Date] datetimeoffset NOT NULL,
    CONSTRAINT [PK_LogApp] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_LogApp_ClientApp_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [ClientApp] ([Id]) ON DELETE CASCADE
);


CREATE INDEX [IX_LogApp_ClientId] ON [LogApp] ([ClientId]);


CREATE INDEX [IX_UserApp_ClientId] ON [UserApp] ([ClientId]);


