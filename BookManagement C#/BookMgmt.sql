create table BoookTable
(
	bookId int primary key identity(1,1),
	bookName nvarchar(50),
	authName nvarchar(50),
	bookISBN int
)

insert into BoookTable values(1234)

insert into BoookTable values(65678)

select * from BoookTable
select * from AuthorTable

 create table AuthorTable
(
  authId int identity(1,1),
  authName nvarchar(50),
  bookName nvarchar(50) primary key
 )

 insert into AuthorTable values('ARUNDHATI ROY', 'THE GOD OF SMALL THINGS')
 insert into AuthorTable values('ARAVIND ADIGA', 'THE WHITE TIGER')
 insert into AuthorTable values('LEO TOLSTOY', 'RESURRECTION')
 insert into AuthorTable values('LEO TOLSTOY', 'CONFESSION')
 insert into AuthorTable values('M K GANDHI', 'MY EXPERIMENT WITH TRUTH')
 insert into AuthorTable values('MK GANDHI', 'HIND SWARAJ')
 insert into AuthorTable values('PRATIVA ROY', 'JAGYNASENNI')


 Alter table BookTable add bookName varchar(50) NOT NULL REFERENCES AuthorTable(bookName)




 create table BookDB
(
	bookId int primary key identity(1,1),
	BookAuthor nvarchar(50),
	BookName nvarchar(50),
	BookIsbn int
)

create table AuthDB
(
	authId int primary key identity(1,1),
	authorName nvarchar(50)
)


Alter table BookDB Add authId int NOT NULL REFERENCES AuthDB(authId)

insert into AuthDB values('SCIENCE')
insert into AuthDB values('FICTION')
insert into AuthDB values('MYTHOLOGY')
insert into AuthDB values('HISTORY')
insert into AuthDB values('POLITY')


ALTER TABLE AUTHDB DROP COLUMN genre
ALTER TABLE AUTHDB DROP COLUMN genre

ALTER TABLE AUTHDB ADD AuthName varchar(50)

drop table BookDB
drop table AuthDB

truncate table BookDB
truncate table AuthDB

insert into AuthDB values('MK GANDHI')
insert into AuthDB values('LEO TOLSTOY')
insert into AuthDB values('PRATIVA ROY')
insert into AuthDB values('SHAKESPEAR')
insert into AuthDB values('BALARAM DAS')
insert into AuthDB values('JL NEHRU')
insert into AuthDB values('MARTIN LUTAR')
insert into AuthDB values('SMRUUTI RANJAN')



select * from BookDB
select * from AuthDB
