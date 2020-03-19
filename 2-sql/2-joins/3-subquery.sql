-- sometimes the most natural way to think about
-- or write a query is based on the results of some partial sub-query

-- every track that has never been purchased.
-- join version
SELECT t.*
FROM Track AS t
	LEFT JOIN InvoiceLine AS il ON t.TrackId = il.TrackId
WHERE il.InvoiceLineId IS NULL;
-- subquery version
SELECT *
FROM Track
WHERE TrackId NOT IN (
	SELECT TrackId
	FROM InvoiceLine);

-- there is a syntax called CTE, common table expression
-- lets you set up a subquery "before" your main query, giving it a name (alias)

-- CTE version
WITH purchased_tracks AS (
	SELECT TrackId
	FROM InvoiceLine)
SELECT *
FROM Track
WHERE TrackId NOT IN (SELECT * FROM purchased_tracks);

-- set operator version (except we only get the IDs)
SELECT TrackId FROM Track
EXCEPT
SELECT TrackId FROM InvoiceLine;
