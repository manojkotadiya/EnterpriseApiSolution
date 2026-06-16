CREATE TABLE dbo.Users
(
    UserId UNIQUEIDENTIFIER NOT NULL
        CONSTRAINT PK_Users
        PRIMARY KEY,

    UserName NVARCHAR(100) NOT NULL,

    Email NVARCHAR(250) NOT NULL,

    PasswordHash VARCHAR(500) NOT NULL,

    FirstName NVARCHAR(100) NULL,

    LastName NVARCHAR(100) NULL,

    IsActive BIT NOT NULL
        CONSTRAINT DF_Users_IsActive DEFAULT(1),

    CreatedDate DATETIME2 NOT NULL
        CONSTRAINT DF_Users_CreatedDate DEFAULT(GETUTCDATE()),

    UpdatedDate DATETIME2 NULL
);
GO

CREATE UNIQUE INDEX IX_Users_Email
ON dbo.Users(Email);
GO