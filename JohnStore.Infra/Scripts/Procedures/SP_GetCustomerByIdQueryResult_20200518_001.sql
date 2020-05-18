CREATE PROCEDURE SP_GetCustomerByIdQueryResult
    @Id uniqueidentifier
AS
SELECT 
    C.[Id] AS [CustomerId],
    CONCAT(c.[FirstName], ' ',c.[LastName]) AS [Name],
    c.[Document],
    c.[Email]
FROM 
    [Customer] c
WHERE 
    c.[Id] = @Id


