USE Soccerstats
GO

CREATE OR ALTER FUNCTION uf_ValidateName (@name VARCHAR(25))
RETURNS INT
AS
BEGIN
	DECLARE @return INT
	SET @return = 0
	IF (@name IS NOT NULL) 
		SET @return = 1
	IF (@name not like '%[0-9]%')
		SET @return = 1
RETURN @return
END
