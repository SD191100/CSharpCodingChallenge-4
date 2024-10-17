USE InsuranceDB;

SELECT USER_NAME();
SELECT

CREATE TABLE [User] (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(50) NOT NULL,
    Role NVARCHAR(20) NOT NULL
);

CREATE TABLE Client (
    ClientId INT PRIMARY KEY IDENTITY(1,1),
    ClientName NVARCHAR(100) NOT NULL,
    ContactInfo NVARCHAR(100),
    PolicyId INT,
    FOREIGN KEY (PolicyId) REFERENCES Policy(PolicyId) -- Assume Policy table exists
);

CREATE TABLE Claim (
    ClaimId INT PRIMARY KEY IDENTITY(1,1),
    ClaimNumber NVARCHAR(50) NOT NULL,
    DateFiled DATETIME NOT NULL,
    ClaimAmount DECIMAL(18,2) NOT NULL,
    Status NVARCHAR(20) NOT NULL,
    PolicyId INT,
    ClientId INT,
    FOREIGN KEY (PolicyId) REFERENCES Policy(PolicyId), -- Assume Policy table exists
    FOREIGN KEY (ClientId) REFERENCES Client(ClientId)
);

CREATE TABLE Policy (
    PolicyId INT PRIMARY KEY,
    PolicyName NVARCHAR(100) NOT NULL,
    CoverageAmount DECIMAL(18,2) NOT NULL
);

CREATE TABLE Payment (
    PaymentId INT PRIMARY KEY IDENTITY(1,1),
    PaymentDate DATETIME NOT NULL,
    PaymentAmount DECIMAL(18,2) NOT NULL,
    ClientId INT,
    FOREIGN KEY (ClientId) REFERENCES Client(ClientId)
);

SELECT * FROM Policy