-- two ways to reverse engineer:

-- (install Microsoft.EntityFrameworkCore.Tools on DataAccess,
-- open Package Manager Console in VS, switch Default project to DataAccess, and run:)
	-- Scaffold-DbContext -Connection <connection_string> -Provider Microsoft.EntityFrameworkCore.SqlServer -StartupProject RestaurantReviews.ConsoleUI -OutputDir Entities -Force
-- delete OnConfiguring method from generated DbContext
-- (https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/powershell#scaffold-dbcontext)

-- (install Microsoft.EntityFrameworkCore.Design on DataAccess, and run in bash:)
	-- dotnet ef dbcontext scaffold <connection_string> Microsoft.EntityFrameworkCore.SqlServer --startup-project ../RestaurantReviews.ConsoleUI --force --output-dir Entities
-- delete OnConfiguring method from generated DbContext
-- (https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet#dotnet-ef-dbcontext-scaffold)

--DROP TABLE RR.Restaurant;
--DROP TABLE RR.Review;
--DROP SCHEMA RR;

CREATE SCHEMA RR;
GO

CREATE TABLE RR.Restaurant
(
	ID INT IDENTITY NOT NULL,
	Name NVARCHAR(128) NOT NULL,
	CONSTRAINT PK_Restaurant_ID PRIMARY KEY (ID)
)
GO

CREATE TABLE RR.Review
(
	ID INT IDENTITY NOT NULL,
	RestaurantID INT NOT NULL,
	ReviewerName NVARCHAR(128) NOT NULL,
	Score INT NOT NULL,
	Text NVARCHAR(2048) NOT NULL,
	CONSTRAINT PK_Review_ID PRIMARY KEY (ID)
)
GO

ALTER TABLE RR.Review ADD
	CONSTRAINT FK_Review_Restaurant
		FOREIGN KEY (RestaurantID) REFERENCES RR.Restaurant (ID)
		ON DELETE CASCADE;
GO
