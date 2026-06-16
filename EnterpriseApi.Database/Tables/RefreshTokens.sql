CREATE TABLE dbo.RefreshTokens
(
    RefreshTokenId UNIQUEIDENTIFIER NOT NULL
        CONSTRAINT PK_RefreshTokens
        PRIMARY KEY,

    UserId UNIQUEIDENTIFIER NOT NULL,

    Token VARCHAR(500) NOT NULL,

    ExpiresAt DATETIME2 NOT NULL,

    CreatedAt DATETIME2 NOT NULL
        CONSTRAINT DF_RefreshTokens_CreatedAt DEFAULT(GETUTCDATE()),

    Revoked BIT NOT NULL
        CONSTRAINT DF_RefreshTokens_Revoked DEFAULT(0),

    CONSTRAINT FK_RefreshTokens_Users
        FOREIGN KEY(UserId)
        REFERENCES dbo.Users(UserId)
);
GO

CREATE INDEX IX_RefreshTokens_UserId
ON dbo.RefreshTokens(UserId);
GO