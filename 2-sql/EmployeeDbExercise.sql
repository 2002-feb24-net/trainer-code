--CREATE DATABASE EmployeeDb;
--use EmployeeDb;
--using CREATE DATABASE could be expensive b/c we are using azure, so instead create separate schema w/in same database

--USE Chinook;
CREATE SCHEMA EmployeeDbExercise;
GO

CREATE TABLE EmployeeDbExercise.Department(
ID int primary key NOT NULL,
Name nvarchar(20),
Location varchar(20)
);
CREATE TABLE EmployeeDbExercise.Employee(
ID int primary key NOT NULL,
DeptID int foreign key references EmployeeDbExercise.Department(ID) NOT NULL, --need to alt to foreign key a/f creation to modify constraint
FirstName nvarchar(30),
LastName nvarchar(30),
SSN char(9) unique   --ssn no arithmetic req (char instead of int)
);
CREATE TABLE EmployeeDbExercise.EmpDetails(
ID int primary key NOT NULL,
EmployeeID int foreign key references EmployeeDbExercise.Employee(ID) NOT NULL,
Salary money, --2 digits of precision
Address1 varchar(80),
Address2 varchar(80),
City nvarchar(40),
State varchar(40),
Country nvarchar(40)
);

