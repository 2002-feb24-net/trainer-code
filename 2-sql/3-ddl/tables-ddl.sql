-- in each database...
--  we have many schemas
--   a schema is like a namespace for tables and similar objects

-- in SQL Server, if you highlight three statements at once and hit execute,
-- SQL Server gets all three, and plans the execution of them all together.


CREATE SCHEMA RR;
GO -- SQL Server command to split up the file into batches

-- constraints... PRIMARY KEY, FOREIGN KEY, CHECK, UNIQUE, DEFAULT, NOT NULL, NULL, IDENTITY

CREATE TABLE RR.Restaurant (
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	Name NVARCHAR(100) UNIQUE
);

--INSERT INTO RR.Restaurant (Id, Name)
--VALUES (1, 'Fred''s'); -- error, can't insert to an identity column

INSERT INTO RR.Restaurant (Name) VALUES
	('Fred''s'),
	('McDonald''s'),
	('Nick''s');

SELECT * FROM RR.Restaurant;

CREATE TABLE RR.Review (
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	AuthorName NVARCHAR(60) NOT NULL,
	Text NVARCHAR(500) NULL,
	Rating INT NOT NULL
);

ALTER TABLE RR.Review ADD
	RestaurantId INT NOT NULL;

ALTER TABLE RR.Review ADD
	CONSTRAINT CK_RatingMaxMin CHECK (Rating >= 0 AND Rating <= 10),
	CONSTRAINT FK_Review_Restaurant FOREIGN KEY (RestaurantId) REFERENCES RR.Restaurant (Id);

INSERT INTO RR.Review (AuthorName, Rating, RestaurantId) VALUES
	('Nick', 10, (SELECT Id FROM RR.Restaurant WHERE Name = 'Nick''s'));

SELECT * FROM RR.Review;

SELECT res.Name, rev.Rating
FROM RR.Restaurant AS res INNER JOIN RR.Review AS rev ON res.Id = rev.RestaurantId;
