select id from Customers where Name = @name;
select id from Movies where Name= @name;
INSERT INTO Rentals (MovieID,CusromerID) VALUES ('NYNK','Cardinal');

--SELECT customer, Customers.CompanyName, Orders.OrderDate
--FROM Customers
--INNER JOIN Orders ON Orders.CustomerID=Customers.CustomerID;
