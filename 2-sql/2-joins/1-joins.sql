SELECT * FROM Album;

-- every album by "Various Artists", without joins
SELECT ArtistId
FROM Artist
WHERE Name = 'Various Artists';
-- ...now that i know it's 21
SELECT *
FROM Album
WHERE ArtistId = 21;

-- every album by artist starting with letter A (incomplete)
SELECT ArtistId
FROM Artist
WHERE Name < 'B';
--WHERE Name LIKE 'A%';

-- we have joins to allow a query that accesses several tables at once.

-- pair every employee with every other employee
-- maybe for 360 degree performance reviews
SELECT *
FROM Employee AS e1 CROSS JOIN Employee AS e2
WHERE e1.EmployeeId != e2.EmployeeId;
-- cross join not sure common
--   maybe... a table of all possible sandwiches
--    bread cross join meat cross join cheese cross join topping cross join topping

-- every album by artist with joins
SELECT al.Title, ar.Name
FROM Artist AS ar
	INNER JOIN Album AS al ON ar.ArtistId = al.ArtistId;
-- match each artist with each album, IF the artist IDs are the same.
-- (if any artist starting with letter A has no albums, he won't appear in the results)

-- every artist and the albums they have in the database, if any.
SELECT al.Title, ar.Name
FROM Artist AS ar LEFT JOIN Album AS al
	ON ar.ArtistId = al.ArtistId;
-- more results in this version, because all the artists with no albums are paired up with NULL.

-- all rock songs, showing the name in the format 'ArtistName - SongName'
SELECT COALESCE(ar.Name, 'n/a') + ' - ' + t.Name AS Song
FROM Track AS t
	INNER JOIN Genre ON Genre.GenreId = t.GenreId
	LEFT JOIN Album AS al ON t.AlbumId = al.AlbumId
	LEFT JOIN Artist AS ar ON al.ArtistId = ar.ArtistId
WHERE Genre.Name = 'Rock';
-- it turns out every track does have an album & artist...
-- but if one didn't, we'd still want to have it in the results. thus, left joins.

-- if there might be a null, we have a few ways to deal with that.
-- '= NULL' is always false, even NULL = NULL is false.
-- we use "IS NULL" and "IS NOT NULL" to check.
-- COALESCE(thing-that-might-be-null, replacement-if-it-is-null) lets you handle the null case