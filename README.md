# backend

USE OllixDB

CREATE TABLE ClientApp (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    CompanyName NVARCHAR(400) NOT NULL,
    BussinessName NVARCHAR(400) NULL,
    Cnpj CHAR(18) NOT NULL,
);

CREATE TABLE UserApp (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(200) NULL,
    ClientId UNIQUEIDENTIFIER NOT NULL,
    UserType INT NOT NULL,
    UserEmail NVARCHAR(200) NOT NULL,
    UserPassword NVARCHAR(200) NOT NULL,

    FOREIGN KEY (ClientId) REFERENCES ClientApp(Id) ON DELETE CASCADE
);

Select * from UserApp
Select * from ClientApp
