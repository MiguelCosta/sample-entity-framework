CREATE PROCEDURE DeleteNinja
  @param1 int = 0
AS
  DELETE FROM Ninjas WHERE Id = @param1
RETURN 0
