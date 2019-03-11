--Dirty read
begin transaction
update Carte set gen='SF'
where codc=1
waitfor delay '00:00:10'
rollback transaction

--non-repeatable reads
begin tran
waitfor delay '00:00:05'
update Carte set gen='Fantasy'
where titlu='Sub Dom'
commit tran

--phantom reads
begin tran
waitfor delay '00:00:04'
insert into Carte values(2000,'Morometii',300,30,'Fictiune',1,1)
commit tran

--deadlock
begin tran
update Carte set titlu='La cirese transaction 1' where codc=1
waitfor delay '00:00:10'

update Autor set nume='Petre Ispirescu transaction 1' where coda=1
commit tran
