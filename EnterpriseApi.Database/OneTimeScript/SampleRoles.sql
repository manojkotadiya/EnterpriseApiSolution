INSERT INTO dbo.Roles
(
    RoleId,
    RoleName,
    Description
)
VALUES
(
    NEWID(),
    'Admin',
    'System Administrator'
);

INSERT INTO dbo.Roles
(
    RoleId,
    RoleName,
    Description
)
VALUES
(
    NEWID(),
    'Manager',
    'Business Manager'
);

INSERT INTO dbo.Roles
(
    RoleId,
    RoleName,
    Description
)
VALUES
(
    NEWID(),
    'User',
    'Standard User'
);