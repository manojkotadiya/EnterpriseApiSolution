INSERT INTO dbo.Clients
(
    ClientId,
    ClientName,
    ClientKey,
    ClientSecretHash,
    IsActive
)
VALUES
(
    NEWID(),
    'Enterprise Portal',
    'enterprise-client',
    'HASH_VALUE_HERE',
    1
);