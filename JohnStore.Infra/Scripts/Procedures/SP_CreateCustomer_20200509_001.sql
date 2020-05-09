CREATE PROCEDURE sp_CreateCustomer
    @Id UNIQUEIDENTIFIER,
    @FirstName VARCHAR(40),
    @LastName VARCHAR(40),
    @Document CHAR(11),
    @Email VARCHAR(100),
    @Phone VARCHAR(13)
  
AS
   INSERT INTO [Customer] (
       [Id],
       [FirstName],
       [LastName],
       [Document],
       [Email],
       [Phone]
   )VALUES(
       @Id,
       @FirstName,
       @LastName,
       @Document,
       @Email,
       @Phone
   )