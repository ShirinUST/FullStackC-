namespace Module_1_CSharp_Assessment
{
    enum OptionSelector
    {
        AddProduct=1,
        ViewProducts,
        SearchProducts,
        RemoveProduct,
        Exit,
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Product_ICare product = new Product_ICare();
            ProductManagement productManagement = new ProductManagement();
            ProductValidation productValidation = new ProductValidation();
            Console.WriteLine("  iCare Store- 'We Care For You....'");
            Console.WriteLine("  --------------------------------------------");
            do
            {
                Console.WriteLine("\n  ---MENU---");
                Console.WriteLine(" 1. Add product\n 2. View all products.\n 3. Search products based on price.\n 4. Remove a product based on product id.\n 5. Exit");
                Console.WriteLine("  Enter Your Choice:");
                string inputString = Console.ReadLine();
                if (int.TryParse(inputString, out int option))
                {
                    switch (option)
                    {
                        case (int)OptionSelector.AddProduct:
                            AddProducts(product,productManagement,productValidation);
                            break;
                        
                        case (int)OptionSelector.ViewProducts:
                            var newList = productManagement.GetProductList();
                            if (newList.Count() > 0)
                            {
                                Console.WriteLine("  Products in the store are:");
                                DisplayProducts(newList);
                            }
                            else
                                Console.WriteLine("  No products available  in the store...");
                            break;
                        case (int)OptionSelector.SearchProducts:
                            SearchProductInProducts(productValidation, productManagement);
                            break;
                        case (int)OptionSelector.RemoveProduct:
                            try
                            {
                                Console.WriteLine("  Enter an ID to Remove Product:");
                                int removeId = Convert.ToInt32(Console.ReadLine());
                                if (productManagement.RemoveProductById(removeId))
                                {
                                    Console.WriteLine("  Product with ID = " + removeId + " is removed successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("  No such ID  exist");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        case (int)OptionSelector.Exit:
                            Console.WriteLine("  ***********************");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("  Invalid Entry");
                            break;
                    }
                }
                else if (string.IsNullOrWhiteSpace(inputString))
                {
                    Console.WriteLine("  Nothing entered, Enter correct choice.....");
                }
                else
                    Console.WriteLine("  Enter choice in correct format....");
            }while(true);
        }
        public static void DisplayProducts(List<Product_ICare> products)
        {
            foreach (var product in products) 
            { 
                Console.WriteLine($"  ID : {product.ProductID} | Name : {product.ProductName} | Manufactured Year : {product.ManufacturedYear} | Price : {product.ProductPrice}");
            }
        }
        public static void AddProducts(Product_ICare product,ProductManagement productManagement,ProductValidation productValidation)
        {
            try
            {
                Console.WriteLine("  Enter product details below:-");
                Console.WriteLine("  Enter the product name:");
                product.ProductName = Console.ReadLine();
                productValidation.IsStringValid(product.ProductName, "Name");
                Console.WriteLine("  Enter the Description of product:");
                product.ProductDescription = Console.ReadLine();
                productValidation.IsStringValid(product.ProductDescription, "Description");
                Console.WriteLine("  Enter the Manufactured year of product:");
                product.ManufacturedYear = Convert.ToInt32(Console.ReadLine());
                productValidation.IsYearValid(Convert.ToString(product.ManufacturedYear));
                if (productManagement.IsProductExists(product))
                {
                    Console.WriteLine("  Enter the price of product:");
                    product.ProductPrice = Convert.ToDouble(Console.ReadLine());
                    productValidation.IsPriceValid(Convert.ToString(product.ProductPrice));
                    productManagement.AddProduct(product);
                    Console.WriteLine("  Product added successfully...");
                }
                else
                    Console.WriteLine("  Product Already Exists!");
            }
            catch (ValidateException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void SearchProductInProducts(ProductValidation productValidation,ProductManagement productManagement)
        {
            try
            {
                Console.WriteLine("  Enter a Price:");
                double inputPrice = Convert.ToDouble(Console.ReadLine());
                productValidation.IsPriceValid(Convert.ToString(inputPrice));
                var newList = productManagement.GetProductListAboveInputPrice(inputPrice);
                if (newList.Count() > 0)
                {
                    Console.WriteLine("  Products in the store above price " + inputPrice + " are:");
                    DisplayProducts(newList);
                }
                else
                    Console.WriteLine("  No products greater than the price " + inputPrice + " available  in the store...");
            }
            catch (ValidateException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}