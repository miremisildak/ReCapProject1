create table Customers(
CustomerId  int PRIMARY KEY IDENTITY(1,1),
UserId int ,
CompanyName nvarchar(25),
FOREIGN KEY(UserId) References Users(UserId)
)

create table Users(
UserId int PRIMARY KEY IDENTITY(1,1),
FirstName nvarchar(25),
LastName nvarchar(25),
Email nvarchar(25),
Passwords nvarchar(25)
)

create table Rentals(
RentalsId  int PRIMARY KEY IDENTITY(1,1),
CustomerId int,
CarsId int,
CompanyName nvarchar(25),
RentDate datetime,
ReturnDate datetime,
FOREIGN KEY(CustomerId) References Customers(CustomerId),
FOREIGN KEY(CarsId) References Cars(Id),
)

select * from Rentals
select * from Users
select * from Customers




