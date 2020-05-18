--TODO: Realizar o inner join no subselect para melhorar a performance quando estivermos em prod

CREATE PROCEDURE sp_GetCustomerOrdersCount
    @Document CHAR(11)
AS
SELECT 
    C.[Id] AS [CustomerId],
    CONCAT(c.[FirstName], ' ',c.[LastName]) AS [Name],
    c.[Document],
    (
        SELECT 
            COUNT(o.[Id]) 
        FROM 
            [Order] o 
        WHERE 
        o.[CustomerId] = c.[id]
    ) AS [Orders]
FROM 
    [Customer] c
WHERE 
    c.[Document] = @Document

