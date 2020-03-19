-- basic exercises (Chinook database)

-- 1. list all customers (full names, customer ID, and country) who are not in the US

-- 2. list all customers from brazil

-- 3. list all sales agents

-- 4. show a list of all countries in billing addresses on invoices.

-- 5. how many invoices were there in 2009, and what was the sales total for that year?

-- 6. how many line items were there for invoice #37?

-- 7. how many invoices per country?

-- 8. show total sales per country, ordered by highest sales first.



--Answers
--
--
--
--
--
--
--
--
--
--
--
--
--

SELECT * FROM Customer;

-- 1. list all customers (full names, customer ID, and country) who are not in the US
SELECT CustomerId, FirstName, LastName, Country
FROM Customer
WHERE Country != 'USA';

-- 2. list all customers from brazil

-- 3. list all sales agents
SELECT *
FROM Employee
WHERE Title LIKE '%Sales%Agen?%';
-- pattern matching with the LIKE operator
-- % - 0 to many of any character
-- [abc] - one of a, b, or c
-- _ - one of any character


-- 4. show a list of all countries in billing addresses on invoices.
SELECT DISTINCT BillingCountry
FROM Invoice;
-- SELECT DISTINCT means, after you get all the result rows, 
--    remove duplicate rows (where ALL column values match)

-- 5. how many invoices were there in 2009, and what was the sales total for that year?
--    (extra challenge: find the invoice count sales total for every year, using one query)
SELECT SUM(Total) AS TotalAmount, COUNT(InvoiceId) AS InvoicesIn2009
FROM Invoice
--WHERE InvoiceDate BETWEEN '2009-01-01' AND '2010-01-01';
WHERE YEAR(InvoiceDate) = 2009;

SELECT YEAR(InvoiceDate) AS Year, SUM(Total) AS TotalAmount, COUNT(InvoiceId) AS Invoices
FROM Invoice
GROUP BY YEAR(InvoiceDate);

-- 6. how many line items were there for invoice #37?

-- 7. how many invoices per country?

-- 8. show total sales per country, ordered by highest sales first.
SELECT BillingCountry, SUM(Total)
FROM Invoice
GROUP BY BillingCountry
ORDER BY SUM(Total) DESC, BillingCountry;
