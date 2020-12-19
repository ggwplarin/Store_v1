USE master
GO

USE master
GO

IF NOT EXISTS (
    SELECT name
        FROM sys.databases
        WHERE name = N'MagazzzDB'
)
CREATE DATABASE MagazzzDB
GO

USE MagazzzDB 
GO

IF OBJECT_ID('Products', 'U') IS NOT NULL
DROP TABLE Products
GO
IF OBJECT_ID('Accounts', 'U') IS NOT NULL
DROP TABLE Accounts
GO

CREATE TABLE Products
(
    product_id INT NOT NULL PRIMARY KEY IDENTITY,
    product_title NVARCHAR(64) NOT NULL,
    product_description NVARCHAR(256) NOT NULL,
    product_price INT NOT NULL
);
GO

CREATE TABLE Accounts
(
    account_id INT NOT NULL PRIMARY KEY IDENTITY,
    account_email NVARCHAR(32) NOT NULL,
    account_password NVARCHAR(64) NOT NULL
);
GO