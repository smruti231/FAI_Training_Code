sp_tables 
select * from BookDB
drop table BoookTable
drop table AuthorTable

-- Create Authors Table
CREATE TABLE Author
(
    AuthorID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL UNIQUE,
    Age INT,
    Country NVARCHAR(100)
)

CREATE TABLE Book 
(
    BookID INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(255) NOT NULL,
    Price DECIMAL(10, 2),
    AuthorID INT FOREIGN KEY REFERENCES Author(AuthorID),
    BookImage NVARCHAR(255)
)

select * from Book

select * from Author

SELECT AuthorID, Name FROM Author

drop table Author

drop table Book

truncate table Book


