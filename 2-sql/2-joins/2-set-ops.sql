-- we have some operators in SQL
--  + - * / AND OR NOT = !=
-- there's also some set operators, which operate on
--    not individual values, but whole SELECT queries

-- UNION, UNION ALL, INTERSECT, EXCEPT.

-- these can only be used on two queries that return compatible sets
--  compatible as in, the number of columns is the same, and the type are the same/convertible

-- UNION
--  return all rows from both queries together
--  (removes duplicates)
-- UNION ALL - same as UNION, but doesn't remove duplicates

-- INTERSECT: return all rows which were in BOTH queries
-- EXCEPT return all rows which were in the first query BUT NOT in the second.
--    (like subtracting the second set from the first set)

-- all first names among both customers and employees.
SELECT FirstName FROM Customer
UNION
SELECT FirstName FROM Employee;

-- (including the four duplicate first names...)
SELECT FirstName FROM Customer
UNION ALL
SELECT FirstName FROM Employee;

-- all first names that a customer has and also an employee has
SELECT FirstName FROM Customer
INTERSECT
SELECT FirstName FROM Employee;

-- all first names that a customer has but no employee has
SELECT FirstName FROM Customer
EXCEPT
SELECT FirstName FROM Employee;