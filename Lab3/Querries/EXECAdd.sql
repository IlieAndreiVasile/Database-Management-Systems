USE Soccerstats
GO

SELECT * FROM Referees
SELECT * FROM Balls
SELECT * FROM Matches

--EXEC AddRefereeBallMatch2 Null, '1980-01-01', 'Ball Prototype', 'New Balance', 330, '2018-06-01', 'Arsenal', 'PSG', 'Europa League', 'Official'
EXEC AddRefereeBallMatch2 'Milorad Mazic', '1973-03-23', 'Adidas Finale Kyiv Champions League 2018', 'Adidas', 200, '2018-05-26', 'Real Madrid', 'Liverpool', 'Champions League', 'Official'

SELECT * FROM Referees
SELECT * FROM Balls
SELECT * FROM Matches