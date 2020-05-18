CREATE PROCEDURE sp_GetCustomerQueryResult
AS
SELECT 
    C.[Id] AS [CustomerId],
    CONCAT(c.[FirstName], ' ',c.[LastName]) AS [Name],
    c.[Document],
    c.[Email]
FROM 
    [Customer] c


