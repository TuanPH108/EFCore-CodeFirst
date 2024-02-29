using Entity_Framework_Core.Objects;

namespace Entity_Framework_Core
{
    public class DummyData
    {
        private User _objUser;
        private Product _objProduct;
        private UserOrder _objUserOrder;
        private UserOrderProduct _objUserOrderProduct;
        public DummyData() { 
            this._objUser = new User();
            this._objProduct = new Product();
            this._objUserOrder = new UserOrder();
            this._objUserOrderProduct = new UserOrderProduct();
        }
        public void InsertData() {
            //count completed
            int count = 0;
            //String array of user name
            String[] listUserName = { "TuanPH", "ph.hoangtuan", "hoangtuan", "Phan Hoang Tuan", "Tuan" };
            //String array of product name
            String[] listProductName = { "Iphone", "Mac", "IMac", "Laptop", "PC", "Workstation" };
            //Create new Random Instance
            Random rnd = new Random();
            
            using (EFCoreCodeFirst dbcontext = new EFCoreCodeFirst())
                //Loop for 1000 times
                for (int i = 1; i <= 1000; i++)
                {
                    Console.WriteLine("Adding new record -- " + i + " -- .....#");
                    //Set Variable of User
                    this._objUser.Id = Guid.NewGuid().ToString();
                    this._objUser.Name = listUserName[rnd.Next(0, listUserName.Length - 1)];
                    this._objUser.Email = listUserName[rnd.Next(0, listUserName.Length - 1)] + rnd.Next(0, 9) + rnd.Next(0, 9) + "@gmail.com";

                    //Set Variable of User Order
                    this._objUserOrder.Id = Guid.NewGuid().ToString();
                    this._objUserOrder.Quantity = rnd.Next(1, 10);
                    this._objUserOrder.UserId = this._objUser.Id;

                    //Set Variable of Product
                    this._objProduct.Id = Guid.NewGuid().ToString();
                    this._objProduct.Name = listProductName[rnd.Next(0, listUserName.Length - 1)];
                    this._objProduct.Note = "Sample Testing";
                    this._objProduct.Price = rnd.Next(100, 1000) + rnd.Next(10, 1000);
                    this._objProduct.Quantity = rnd.Next(1, 10);
                    this._objProduct.Discount = rnd.Next(10, 50);

                    //Set Variable of User Order Product
                    this._objUserOrderProduct.Id = Guid.NewGuid().ToString();
                    this._objUserOrderProduct.Note = "Pay Later";
                    this._objUserOrderProduct.Quantity = rnd.Next(1, 10);
                    this._objUserOrderProduct.Discount = rnd.Next(10, 50);
                    this._objUserOrderProduct.UserOrderId = this._objUserOrder.Id;
                    this._objUserOrderProduct.ProductId = this._objProduct.Id;


                    //Insert into Database
                    dbcontext.Users.Add(this._objUser);
                    Console.WriteLine("Add User : " + this._objUser.Id + " Completely...");
                    dbcontext.Products.Add(this._objProduct);
                    Console.WriteLine("Add Product : " + this._objProduct.Id + " Completely...");
                    dbcontext.UserOrders.Add(this._objUserOrder);
                    Console.WriteLine("Add User Order: " + this._objUserOrder.Id + " Completely...");
                    dbcontext.UserOrderProducts.Add(this._objUserOrderProduct);
                    Console.WriteLine("Add User Order Products: " + this._objUserOrderProduct.Id + "  Completely...");
                    count++;
                    dbcontext.SaveChanges();
                }
            Console.WriteLine("Insert Completed " + count + " Records Each Table....#");
        }    
    }
}