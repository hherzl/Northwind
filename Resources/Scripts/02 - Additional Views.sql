use Northwind
go

create view dbo.OrderDetailSummary
as
	select
		Details.OrderID,
		Details.ProductID,
		Products.ProductName,
		Details.UnitPrice,
		Details.Quantity,
		convert(decimal(8, 4), Details.Discount) as Discount,
		(Details.UnitPrice - (Details.UnitPrice * convert(decimal(8, 4), Details.Discount))) * Details.Quantity as Total
	from
		[Order Details] Details
	inner join
		Products on Details.ProductID = Products.ProductID
go
