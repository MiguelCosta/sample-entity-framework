CREATE PROCEDURE GetOldNinjas
	--@param1 int = 0,
	--@param2 int
AS
	SELECT * FROM Ninjas WHERE DayOfBirth <= '1990-01-01'
--RETURN 0
