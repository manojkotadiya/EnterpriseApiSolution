CREATE TABLE dbo.UserRoles
(
    UserRoleId UNIQUEIDENTIFIER NOT NULL
        CONSTRAINT PK_UserRoles
        PRIMARY KEY,

    UserId UNIQUEIDENTIFIER NOT NULL,

    RoleId UNIQUEIDENTIFIER NOT NULL,

    AssignedDate DATETIME2 NOT NULL
        CONSTRAINT DF_UserRoles_AssignedDate DEFAULT(GETUTCDATE()),

    CONSTRAINT FK_UserRoles_Users
        FOREIGN KEY(UserId)
        REFERENCES dbo.Users(UserId),

    CONSTRAINT FK_UserRoles_Roles
        FOREIGN KEY(RoleId)
        REFERENCES dbo.Roles(RoleId)
);
GO

CREATE UNIQUE INDEX IX_UserRoles_User_Role
ON dbo.UserRoles(UserId, RoleId);
GO