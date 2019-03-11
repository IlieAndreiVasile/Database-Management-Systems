USE Soccerstats
GO

CREATE OR ALTER PROCEDURE AddRefereeBallMatch1 @rname VARCHAR(25), @rdate DATE, @ball VARCHAR(30), @manufacturer VARCHAR(15), @price INT, @date DATE, @team1name VARCHAR(30), @team2name VARCHAR(30), @competitionname VARCHAR(30), @type VARCHAR(15)
AS
BEGIN  
	BEGIN TRAN
		BEGIN TRY
			DECLARE @rid int
			SET @rid = 0
			IF(dbo.uf_ValidateName(@rname)<>1) 
				BEGIN 
					RAISERROR('Referee name must contain only letters and can not be NULL',14,1) 
				END
			SELECT TOP 1 @rid = Rid+1  FROM Referees ORDER BY Rid DESC
			INSERT INTO Referees (Rid, Name, BirthDate) VALUES (@rid, @rname, @rdate)

			IF(dbo.uf_ValidateName(@ball)<>1) 
				BEGIN 
					RAISERROR('Ball name must contain only letters and can not be NULL',14,1) 
				END
			INSERT INTO Balls (BallName, Manufacturer, Price) VALUES (@ball, @manufacturer, @price)

			IF(dbo.uf_ValidateName(@team2name)<>1) 
				BEGIN 
					RAISERROR('Team1 name must contain only letters and can not be NULL',14,1) 
				END

			IF(dbo.uf_ValidateName(@team1name)<>1) 
				BEGIN 
					RAISERROR('Team2 name must contain only letters and can not be NULL',14,1) 
				END

			IF (@rid <> 0)
			INSERT INTO Matches (Date, Rid, CompetitionName, Team1Name, Team2Name, BallName, Type) VALUES (@date, @rid, @competitionname, @team1name, @team2name, @ball, @type)

			SELECT 'Transaction committed'
		END TRY 
	BEGIN CATCH
		ROLLBACK TRAN
		SELECT 'Transaction rollbacked'
	END CATCH
END 
