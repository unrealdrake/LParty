CREATE FUNCTION [dbo].[UserExistsByLogin]
(
	@email NVARCHAR(60)
)
RETURNS BIT
AS
BEGIN
	RETURN  CAST(
		   CASE WHEN EXISTS(SELECT * FROM [User] where Login = @email) THEN 1 
		   ELSE 0 
		   END 
	AS BIT)
END


