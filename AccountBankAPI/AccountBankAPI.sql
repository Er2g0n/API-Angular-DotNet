use master
go

drop database if exists AccountBankAPI
create database AccountBankAPI
go

use AccountBankAPI
go


-- Tạo bảng Account
CREATE TABLE Account (
    AccID INT PRIMARY KEY IDENTITY(1,1),
    Username VARCHAR(50) NOT NULL,
    Password VARCHAR(250) NOT NULL,
    FullName VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Phone VARCHAR(20) NOT NULL,
    Balance DECIMAL(18, 2) NOT NULL
);

-- Tạo bảng TransactionDetails
CREATE TABLE TransactionDetails (
    TransID INT PRIMARY KEY IDENTITY(1,1),
    AccID INT NOT NULL,
    TransMoney DECIMAL(18, 2) NOT NULL,
    TransType INT NOT NULL,
    DateOfTrans DATE NOT NULL,
    FOREIGN KEY (AccID) REFERENCES Account(AccID)
);


