//using Business.Concrete;
//using DataAccess.Concrete;

//public static void ProductTest()
//{
//    AddressManager address = new AddressManager(new EfAddressDal()
//        , new UserManager(new EfUsersDal()));

//    var result = address.GetProductDetails();

//    if (result.Success == true)
//    {
//        foreach (var product in result.Data)
//        {
//            Console.WriteLine(product.ProductName + "/" + product.CategoryName);
//        }
//    }
//    else
//    {
//        Console.WriteLine(result.Message);
//    }