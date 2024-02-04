Create Database Shooop

Use Shooop

Create Table Category
(
	Id Int Primary Key Identity,
	[Name] NVARCHAR(30) Not Null,
	IsDeleted Bit Not Null,
	CreatedAt Date Not Null,
	UpdateAt Date Not Null
)

Create Table Product
(
	Id Int Primary Key Identity,
	[Name] NVARCHAR(30) Not Null,
	IsDeleted Bit Not Null,
	Price Int,
	CategoryId Int Foreign Key References Category(Id), 
	CreatedAt Date Not Null,
	UpdateAt Date Not Null
)