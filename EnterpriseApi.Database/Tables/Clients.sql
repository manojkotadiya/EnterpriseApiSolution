CREATE TABLE dbo.Clients
(
    ClientId UNIQUEIDENTIFIER NOT NULL
        CONSTRAINT PK_Clients
        PRIMARY KEY,

    ClientName NVARCHAR(200) NOT NULL,

    ClientKey VARCHAR(100) NOT NULL UNIQUE,

    ClientSecretHash VARCHAR(500) NOT NULL,

    IsActive BIT NOT NULL
        CONSTRAINT DF_Clients_IsActive DEFAULT(1),

    CreatedDate DATETIME2 NOT NULL
        CONSTRAINT DF_Clients_CreatedDate DEFAULT(GETUTCDATE()),

    UpdatedDate DATETIME2 NULL
);
GO

CREATE INDEX IX_Clients_ClientKey
ON dbo.Clients(ClientKey);
GO