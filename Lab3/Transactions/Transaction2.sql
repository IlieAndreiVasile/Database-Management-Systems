--Dirty reads read uncommited/commited
set transaction isolation level read COMMITTED
begin tran
select * from Carte
waitfor delay '00:00:15'
select * from Carte
commit tran

--non-repeatable reads commited/repeatable read
set transaction isolation level repeatable read
begin tran
select * from Carte
waitfor delay '00:00:05'
select * from Carte
commit tran

--phantom reads repeatable read/serializable
set transaction isolation level serializable
begin tran
select * FROM Carte
waitfor delay '00:00:05'
select * from Carte
commit tran

--deadlock
set deadlock_priority high
begin tran
update Autor set nume='Petre Ispirescu transaction 2' where coda=1
waitfor delay '00:00:10'

update Carte set titlu='La Cirese transaction 2'where codc=1
commit tran

