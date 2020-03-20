-- database to represent students and classes

CREATE TABLE Student (
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) NOT NULL
);

CREATE TABLE Class (
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	CourseNumber NVARCHAR(20) NOT NULL UNIQUE
)

-- how can we connect them?
--   a foreign key in student table?
--     no, one student can be in many classes
--   a foreign key in class table
--     no, one class can contain many students
-- in SQL, you NEED a third table to represent the connection
--   between one class and one student.
-- this is called a join table, junction table
--   what should THIS ONE be called..?
--   StudentClass, StudentClassJoin, StudentClassJunction, Enrollment

CREATE TABLE Enrollment (
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	StudentId INT NOT NULL FOREIGN KEY REFERENCES Student (Id),
	ClassId INT NOT NULL FOREIGN KEY REFERENCES Class (Id)
);

-- you could give the junction table two columns, both foreign keys,
--   together also a composite primary key
-- maybe more common is you add a unique id column for the junction table too.

INSERT INTO Student (Name) VALUES
	('Harold'), ('Anthony'), ('Abraham');
--      1          2         3
	
INSERT INTO Class (CourseNumber) VALUES
	('CS 100'), ('CS 101'), ('CS 102');
--       1         2          3

INSERT INTO Enrollment (StudentId, ClassId) VALUES
	(1, 1), (1, 2), (3, 3), (3, 1), (3, 2);

--INSERT INTO Enrollment (StudentId, ClassId) VALUES
--	((SELECT Id FROM Student WHERE Name = 'Anthony'),
--		(SELECT Id FROM Class WHERE CourseNumber = 'CS 101'));
