// ef example:
// this example's separation of concerns is not great because
// business rules (when an order is placed, inventory decreases)
// are being coded in the data access layer (EF details).
// but it does provide an example of reading and writing with
// relationships in EF.
public void PlaceOrder(Order order)
{
    // omitted: check the location's inventory to make sure this will work,
    // check that all the entities really exist, etc.

    var dbCustomer = _context.Customers.Find(order.Customer.Id);
    var dbLocation = _context.Locations
        .Include(l => l.Inventories)
            .ThenInclude(i => i.Product)
        .First(l => l.Id == order.Location.Id);

    var dbOrder = new Data.Order
    {
        Customer = dbCustomer,
        Location = dbLocation
    };
    // a dictionary is a sequence of key-value pairs
    dbOrder.OrderLines.AddRange(order.Products.Select(pq => new Data.OrderLine
    {
        ProductId = pq.Key.Id,
        Quantity = pq.Value
    }));

    // update the dbLocation's Inventory stuff:
    foreach (var orderLine in dbOrder.OrderLines)
    {
        // this would fail if not for the Includes in the original query.
        var inventory = dbLocation.Inventories.First(i => i.Product == orderLine.Product);
        inventory.Quantity -= orderLine.Quantity;
    }

    // add all new reachable entities (the order and the order-lines)
    _context.Add(dbOrder);

    // apply all these changes as one transaction, not piece by piece
    _context.SaveChanges();
}
