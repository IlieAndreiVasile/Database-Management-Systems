--Dirty read
BEGIN TRANSACTION
UPDATE Balls SET price = 190
WHERE BallName = 'Adidas Finale Kyiv Champions L'
WAITFOR DELAY '00:00:10'
ROLLBACK TRANSACTION

--non-repeatable reads
BEGIN TRANSACTION
WAITFOR DELAY '00:00:05'
UPDATE Balls SET Price = 300
WHERE Manufacturer = 'Nike'
COMMIT TRAN

--phantom reads
BEGIN TRANSACTION
WAITFOR DELAY '00:00:04'
INSERT INTO Balls VALUES('Prototype', 'Nike', 150)
COMMIT TRAN

--deadlock
BEGIN TRANSACTION
UPDATE Balls SET BallName = 'Adidas Final - transaction 1' WHERE Price = 200
WAITFOR DELAY '00:00:10'

UPDATE Referees SET Name ='Someone - transaction 1' WHERE Rid = 1
COMMIT TRANSACTION
