use Northwind
go

create table ChangeLog
(
	ChangeLogID int not null identity(1, 1),
	TableName varchar(255) not null,
	ColumnName varchar(255) not null,
	Value varchar(255) not null,
	CreationDate datetime not null
)
go
