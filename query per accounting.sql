-- Te lutem ekzekutoj rreshtat sipas renditjes te ciles i kam caktuar me poshte

-- 1. Ekzekuto vetem rreshtin e meposhtem
create database ACCOUNTING_PROJECT

-- 2. Ekzekuto vetem rreshtin e meposhtem
use ACCOUNTING_PROJECT

-- 3. Je e lire te ekzekutojsh qdo rresht me poshte
create table User_roles (
	Id int primary key identity(1,1),
	Role_name varchar(20),
)
--edhe kjo u kry ne VS
create table Users (
	Id int primary key identity(1,1),
	Username varchar(255) unique,
	Pin int check (Pin between 1000 and 9999),
	Account_number int unique,
	Balance float default 0,
	User_role int foreign key references User_roles(Id),
	Created_date datetime default getDate()
)
--edhe kjo u kry 
create table Transfers (
	Id int primary key identity(1,1),
	Sender_account int foreign key references Users(Id),
	Receiver_account int foreign key references Users(Id),
	Amount float,
	Transfer_date datetime default getDate()
)
-- u kry deposita ne VS
create table Deposits (
	Id int primary key identity(1,1),
	[User] int foreign key references Users(Id),
	Amount float,
	Deposit_date datetime default getDate()
)
--u kry kodi ne VS
create table Withdraws (
	Id int primary key identity(1,1),
	[User] int foreign key references Users(Id),
	Amount float,
	Withdraw_date datetime default getDate()
)

insert into User_roles values ('User')
insert into User_roles values ('Admin')

insert into Users(Username, Pin, Account_number, User_role) values ('edikrasniqi', 1234, 1234891023, 2)
insert into Users(Username, Pin, Account_number, User_role) values ('ajetekrasniqi', 1234, 1234891123, 1)

insert into Transfers(Sender_account, Receiver_account, Amount) values (1, 2, 1234.00)
insert into Transfers(Sender_account, Receiver_account, Amount) values (2, 1, 1234.00)

insert into Deposits([User], Amount) values (1, 222)
insert into Deposits([User], Amount) values (2, 333)

insert into Withdraws([User], Amount) values (1,222)
insert into Withdraws([User], Amount) values (2,333)
