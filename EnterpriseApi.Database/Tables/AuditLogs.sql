CREATE TABLE dbo.AuditLogs
(
    AuditLogId BIGINT IDENTITY(1,1)
        CONSTRAINT PK_AuditLogs
        PRIMARY KEY,

    UserId UNIQUEIDENTIFIER NULL,

    EventType VARCHAR(100) NOT NULL,

    EventDescription NVARCHAR(MAX) NULL,

    IpAddress VARCHAR(100) NULL,

    CreatedDate DATETIME2 NOT NULL
        CONSTRAINT DF_AuditLogs_CreatedDate DEFAULT(GETUTCDATE())
);
GO

CREATE INDEX IX_AuditLogs_CreatedDate
ON dbo.AuditLogs(CreatedDate);
GO