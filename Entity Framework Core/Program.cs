using Entity_Framework_Core;
using Entity_Framework_Core.Objects;
using Microsoft.EntityFrameworkCore;

using(EFCoreCodeFirst dbcontext = new EFCoreCodeFirst())
{
    User objUser = new User()
    {
        Id = "20H5203027",
        Name = "TuanPH108",
        Email = "ph.hoangtuan18@gmail.com"
    };

    UserOrder objUserOrderProducts = new UserOrder()
    {
        Id = "UO006046",
        Quantity = 1,
        UserId = objUser.Id,
    };

    Product objProduct = new Product()
    {
        Id = "P00255",
        Name = "Testing Product",
        Note = "Sample",
        Price = 19.99,
        Quantity = 1,
        Discount = 0.1,
    };

    UserOrderProduct objUserOrderProduct = new UserOrderProduct()
    {
        Id = "UOP00545",
        Note = "Pay Later",
        Quantity = 1,
        Discount = 0.1,
        UserOrderId = objUserOrderProducts.Id,
        ProductId = objProduct.Id,
    };

    dbcontext.Users.Add(objUser);
    Console.WriteLine("Add User : " + objUser.Id + " Completely...");
    dbcontext.Products.Add(objProduct);
    Console.WriteLine("Add Product : " + objProduct.Id + " Completely...");
    dbcontext.UserOrders.Add(objUserOrderProducts);
    Console.WriteLine("Add User Order: " + objUserOrderProducts.Id + " +  Completely...");
    dbcontext.UserOrderProducts.Add(objUserOrderProduct);
    Console.WriteLine("Add User Order Products: " + objUserOrderProducts.Id + " +  Completely...");

    dbcontext.SaveChanges();
    
}
Console.WriteLine("Done...");