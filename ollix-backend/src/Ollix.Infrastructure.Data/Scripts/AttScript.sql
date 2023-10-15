
-- Fase 1

CREATE TABLE [ClientApp] (
    [Id] uniqueidentifier NOT NULL,
    [CompanyName] nvarchar(400) NOT NULL,
    [BussinessName] nvarchar(400) NOT NULL,
    [Cnpj] nvarchar(18) NULL,
    [Active] bit NOT NULL DEFAULT 1,
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

-- Fase 2

CREATE TABLE [AddressApp] (
    [Id] uniqueidentifier NOT NULL,
    [PostalCode] nvarchar(16) NOT NULL,
    [Street] nvarchar(400) NOT NULL,
    [Neighborhood] nvarchar(400) NOT NULL,
    [City] nvarchar(400) NOT NULL,
    [State] nvarchar(400) NOT NULL,
    CONSTRAINT [PK_AddressApp] PRIMARY KEY ([Id])
);

CREATE TABLE [Order] (
    [Id] uniqueidentifier NOT NULL,
    [RequesterName] nvarchar(200) NOT NULL,
    [RequesterEmail] nvarchar(200) NOT NULL,
    [Observation] nvarchar(600) NULL,
    [RequestDate] datetimeoffset NOT NULL,
    [OrderStatus] int NOT NULL,
    [InstallationDate] datetimeoffset NULL,
    [QuantityRequested] int NOT NULL,
    [AddressId] uniqueidentifier NOT NULL,
    [ClientId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Order_AddressApp_AddressId] FOREIGN KEY ([AddressId]) REFERENCES [AddressApp] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Order_ClientApp_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [ClientApp] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [Propeller] (
    [Id] uniqueidentifier NOT NULL,
    [HelixId] nvarchar(80) NOT NULL,
    [Active] bit NOT NULL,
    [Installed] bit NOT NULL,
    [AddressId] uniqueidentifier NOT NULL,
    [ClientId] uniqueidentifier NOT NULL,
    [OrderId] uniqueidentifier NOT NULL, 
    CONSTRAINT [PK_Propeller] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Propeller_AddressApp_AddressId] FOREIGN KEY ([AddressId]) REFERENCES [AddressApp] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Propeller_ClientApp_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [ClientApp] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Propeller_Order_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Order] ([Id]) ON DELETE NO ACTION 
);


CREATE TABLE [PropellerInfoDate] (
    [Id] uniqueidentifier NOT NULL,
    [TotalRpm] int NOT NULL,
    [TotalKwh] int NOT NULL,
    [ReadingCount] int NOT NULL,
    [InfoDate] datetimeoffset NOT NULL,
    [PropellerId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_PropellerInfoDate] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PropellerInfoDate_Propeller_PropellerId] FOREIGN KEY ([PropellerId]) REFERENCES [Propeller] ([Id]) ON DELETE CASCADE
);

CREATE INDEX [IX_Order_AddressId] ON [Order] ([AddressId]);

CREATE INDEX [IX_Address_PostalCode] ON [AddressApp] ([PostalCode]);

CREATE INDEX [IX_Order_ClientId] ON [Order] ([ClientId]);

CREATE INDEX [IX_Propeller_AddressId] ON [Propeller] ([AddressId]);

CREATE INDEX [IX_Propeller_ClientId] ON [Propeller] ([ClientId]);

CREATE INDEX [IX_Propeller_OrderId] ON [Propeller] ([OrderId]);

CREATE INDEX [IX_PropellerInfoDate_PropellerId] ON [PropellerInfoDate] ([PropellerId]);
