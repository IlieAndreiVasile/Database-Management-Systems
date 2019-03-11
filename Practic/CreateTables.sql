USE WaterPark
GO

CREATE TABLE Rules
	(
	RID int primary key,
	NrPoints int,
	Description Varchar(200)
	)

CREATE TABLE Tickets 
	(
	TIID int primary key,
	Type Varchar(30),
	Price int
	)

CREATE TABLE Adults
	(
	AID int primary key,
	AName Varchar(50),
	Age int,
	TIID int foreign key references Tickets(TIID),
	RID int foreign key references Rules(RID)
	)

CREATE TABLE Toboggans
	(
	TOID int primary key,
	TName Varchar(50),
	Color Varchar(30),
	Difficulty Varchar(30)
	)

CREATE TABLE AdultsToboggans
	(
	ATID int primary key,
	AID int foreign key references Adults(AID),
	TOID int foreign key references Toboggans(TOID),
	StartTime time,
	EndTime time
	)