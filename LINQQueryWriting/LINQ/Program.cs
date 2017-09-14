using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main()
        {
            Exercise30();
            //PrintAllProducts();
            //PrintAllCustomers();
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        #region "Sample Code"
        /// <summary>
        /// Sample, load and print all the product objects
        /// </summary>
        static void PrintAllProducts()
        {
            List<Product> products = DataLoader.LoadProducts();
            PrintProductInformation(products);
        }

        /// <summary>
        /// This will print a nicely formatted list of products
        /// </summary>
        /// <param name="products">The collection of products to print</param>
        static void PrintProductInformation(IEnumerable<Product> products)
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }

        }

        /// <summary>
        /// Sample, load and print all the customer objects and their orders
        /// </summary>
        static void PrintAllCustomers()
        {
            var customers = DataLoader.LoadCustomers();
            PrintCustomerInformation(customers);
        }

        /// <summary>
        /// This will print a nicely formated list of customers
        /// </summary>
        /// <param name="customers">The collection of customer objects to print</param>
        static void PrintCustomerInformation(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }
        #endregion

        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        static void Exercise1()
        {
            var filtered = DataLoader.LoadProducts().Where(p => p.UnitsInStock < 1);
            PrintProductInformation(filtered);
        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        static void Exercise2()
        {
            var filtered = DataLoader.LoadProducts().Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3.00M);
            PrintProductInformation(filtered);
        }

        /// <summary>
        /// Print all customer and their order information for the Washington (WA) region.
        /// </summary>
        static void Exercise3()
        {
            var filtered = DataLoader.LoadCustomers().Where(p => p.Region == "WA");
            PrintCustomerInformation(filtered);
        }

        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        static void Exercise4()
        {
            var products = from p in DataLoader.LoadProducts()
                           select new { productName = p.ProductName };
            foreach(var product in products)
            {
                Console.WriteLine(product.productName);
            }
            
        }

        /// <summary>
        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        /// </summary>
        static void Exercise5()
        {
            string lineFormat = "{0,-15 }{1,-40}{2,-20}{3,-20:C}{4,-20}";
            var products = from p in DataLoader.LoadProducts()
                          select new 
                          {
                              PruductID = p.ProductID,
                              ProcductName = p.ProductName,
                              Category = p.Category,
                              UnitPrice = p.UnitPrice * 1.25M,
                              UnitsInStock = p.UnitsInStock
                          };

            Console.WriteLine(lineFormat, "Pruduct ID", "Product Name", "Category", "Unit Price", "Units In Stock");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
            foreach (var product in products)
            {
                Console.WriteLine( lineFormat, product.PruductID, product.ProcductName, product.Category, product.UnitPrice, product.UnitsInStock);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
        /// </summary>
        static void Exercise6()
        {
            string lineFormat = "{0,-40 }{1,-20}";

            var products = from p in DataLoader.LoadProducts()
                           select new
                           {
                               ProductName = p.ProductName.ToUpper(),
                               Category = p.Category.ToUpper() };

            Console.WriteLine(lineFormat, "PRODCUCT NAME", "CATEGORY");
            Console.WriteLine("------------------------------------------------------------");
            foreach (var product in products)
            {
                Console.WriteLine(lineFormat, product.ProductName, product.Category);
            }

        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3
        /// 
        /// Hint: use a ternary expression
        /// </summary>
        static void Exercise7()
        {
            string lineFormat = "{0,-15 }{1,-35}{2,-20}{3,-15:C}{4,-20}{5,-15}";
            var products = from p in DataLoader.LoadProducts()
                           select new
                           {
                               PruductID = p.ProductID,
                               ProcductName = p.ProductName,
                               Category = p.Category,
                               UnitPrice = p.UnitPrice,
                               UnitsInStock = p.UnitsInStock,
                               ReOrder = p.UnitsInStock < 3 ? true : false
                           };

            Console.WriteLine(lineFormat, "Pruduct ID", "Product Name", "Category", "Unit Price", "Units In Stock", "ReOrder");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
            foreach (var product in products)
            {
                Console.WriteLine(lineFormat, product.PruductID, product.ProcductName, product.Category, product.UnitPrice, product.UnitsInStock, product.ReOrder);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        static void Exercise8()
        {
            string lineFormat = "{0,-15 }{1,-35}{2,-20}{3,-15:C}{4,-20}{5,-15:C}";
            var products = from p in DataLoader.LoadProducts()
                           select new
                           {
                               PruductID = p.ProductID,
                               ProcductName = p.ProductName,
                               Category = p.Category,
                               UnitPrice = p.UnitPrice,
                               UnitsInStock = p.UnitsInStock,
                               StockValue = p.UnitPrice * p.UnitsInStock
                           };

            Console.WriteLine(lineFormat, "Pruduct ID", "Product Name", "Category", "Unit Price", "Units In Stock", "StockValue");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            foreach (var product in products)
            {
                Console.WriteLine(lineFormat, product.PruductID, product.ProcductName, product.Category, product.UnitPrice, product.UnitsInStock, product.StockValue);
            }
        }

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        static void Exercise9()
        {
            var evens = from e in DataLoader.NumbersA
                       where e % 2 == 0
                       select e;
            foreach(var even in evens)
            {
                Console.WriteLine(even);
            }
        }

        /// <summary>
        /// Print only customers that have an order whos total is less than $500
        /// </summary>
        static void Exercise10()
        {

            var orders = DataLoader.LoadCustomers().Where(o => o.Orders.Any(ot => ot.Total < 500));
            PrintCustomerInformation(orders);
        }

        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        static void Exercise11()
        {
            var odds = from o in DataLoader.NumbersC.Where(o => o % 2 == 1).Take(3)select o;
            foreach (var odd in odds)
            {
                Console.WriteLine(odd);
            }

        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        static void Exercise12()
        {
            var numbers = from n in DataLoader.NumbersB.Skip(3) select n;
            foreach(var number in numbers)
            {
                Console.WriteLine(number);
            }
        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        static void Exercise13()
        {
            string lineFormat = "{0,-40}{1,-30}{2,-30}";
            var filters = from f in DataLoader.LoadCustomers().Where(f => f.Region == "WA")
                          select new
                          {
                              CompanyName = f.CompanyName,
                              Order = f.Orders.OrderByDescending(g => g.OrderDate).First(),
                           };

            Console.WriteLine(lineFormat, "Company Name", "Order ID", "Order Date");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");

            foreach (var filter in filters)
            {
                Console.WriteLine(lineFormat, filter.CompanyName, filter.Order.OrderID, filter.Order.OrderDate);
            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        static void Exercise14()
        {
            var numbers = from n in DataLoader.NumbersC.TakeWhile(n => n < 7)select n;
            foreach(var number in numbers)
            {
                Console.WriteLine(number);
            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        static void Exercise15()
        {
            var numbers = from n in DataLoader.NumbersC.SkipWhile(n => n % 3 != 0).Skip(1) select n;

            foreach(var number in numbers)
            {
                Console.WriteLine(number);
            }
        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        static void Exercise16()
        {
            var products = from p in DataLoader.LoadProducts().OrderBy(p => p.ProductName) select p;
            foreach(var product in products)
            {
                Console.WriteLine(product.ProductName);
            }
            
        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        static void Exercise17()
        {
            var products = DataLoader.LoadProducts().OrderByDescending(p => p.UnitsInStock);
            PrintProductInformation(products);
        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        static void Exercise18()
        {
            var products = DataLoader.LoadProducts().OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);
            PrintProductInformation(products);
        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        static void Exercise19()
        {
            var numbers = DataLoader.NumbersB.Reverse();
            foreach(var number in numbers)
            {
                Console.WriteLine(number);
            }
        }

        /// <summary>
        /// Group products by category, then print each category name and its products
        /// ex:
        /// 
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        /// </summary>
        static void Exercise20()
        {
            var categories = DataLoader.LoadProducts().GroupBy(p => p.Category);

            foreach (var category in categories)
            {
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("Category: {0}", category.Key);
                Console.WriteLine("---------------------------------------");

                foreach (var product in category)
                {
                    Console.WriteLine(product.ProductName);
                }
            }

        }

        /// <summary>
        /// Print all Customers with their orders by Year then Month
        /// ex:
        /// 
        /// Joe's Diner
        /// 2015
        ///     1 -  $500.00
        ///     3 -  $750.00
        /// 2016
        ///     2 - $1000.00
        /// </summary>
        static void Exercise21()
        {
            //skip this problem
        }

        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        static void Exercise22()
        {
            var uniques = from p in DataLoader.LoadProducts().Select(p => p.Category).Distinct() select p;
                          

            foreach(var unique in uniques)
            {
                Console.WriteLine(unique);
            }


        }
        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        static void Exercise23()
        {
            var products = DataLoader.LoadProducts().Any(p => p.ProductID == 789);
            //if(products==true)
            //{
            //    Console.WriteLine("true");
            //}
            //else
            //{
            //    Console.WriteLine("false");
            //}
            // Problem is solved, just used this as a way to check to make sure 
            // my logic was working the way I wanted it to :)
        }

        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        static void Exercise24()
        {
            var products = from p in DataLoader.LoadProducts().OrderBy(p => p.Category).Where(p => p.UnitsInStock == 0)
                           select new
                           {
                               Category = p.Category
                           };
            
            foreach(var product in products.Distinct())
            {
                Console.WriteLine(product.Category);
            }
        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        static void Exercise25()
        {
            var products = DataLoader.LoadProducts().GroupBy(p => p.Category).Where(pr => pr.All(p => p.UnitsInStock > 0));

            foreach( var product in products)
            {
                Console.WriteLine(product.Key);
            }
            
        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        static void Exercise26()
        {
            var numbers = DataLoader.NumbersA.Where(n => n % 2 == 1).Count();

            Console.WriteLine(numbers);
        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        static void Exercise27()
        {
            string lineFormat = "{0,-20 }{1,-20}";
            var orders = from o in DataLoader.LoadCustomers()
                         select new
                         {
                             CustomerID = o.CustomerID,
                             OrderCount = o.Orders
                         };

            Console.WriteLine(lineFormat, "Customer ID", "Number of Orders");
            Console.WriteLine("----------------------------------------");

            foreach (var order in orders)
            {
                Console.WriteLine(lineFormat, order.CustomerID, order.OrderCount.Count());
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        static void Exercise28()
        {
            string lineFormat = "{0,-40}{1,-30}";
            var categories = from c in DataLoader.LoadProducts().GroupBy(c => c.Category)
                             select new
                             {
                                 Category = c.Key,
                                 ProductCount = c.Count()
                             };

            Console.WriteLine(lineFormat, "Category", "Product Count");
            Console.WriteLine("----------------------------------------------------------");

            foreach(var category in categories)
            {
                Console.WriteLine(lineFormat, category.Category, category.ProductCount);
            }
        
        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        static void Exercise29()
        {
            string lineFormat = "{0,-40}{1,-30}";
            var categories = from c in DataLoader.LoadProducts().GroupBy(c => c.Category)
                             select new
                             {
                                 Category = c.Key,
                                 UnitCount = c.Sum(p => p.UnitsInStock)
                             };


            Console.WriteLine(lineFormat, "Category", "Units in Stock");
            Console.WriteLine("----------------------------------------------------------");

            foreach (var category in categories)
            {
                Console.WriteLine(lineFormat, category.Category, category.UnitCount);
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        static void Exercise30()
        {
            string lineFormat = "{0,-30}{1,-40}{2,-25:C}";
            var categories = from c in DataLoader.LoadProducts().GroupBy(c => c.Category)
                         select new
                         {
                             Category = c.Key,
                             MinUnit = c.Min(p => p.UnitPrice),
                             MinProduct = c.Where(p => p.UnitPrice == c.Min(pr => pr.UnitPrice)).First().ProductName
                         };

            Console.WriteLine(lineFormat, "Category", "Lowest Priced Product", "Product Price");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");

            foreach (var category in categories)
            {
                Console.WriteLine(lineFormat, category.Category, category.MinProduct, category.MinUnit);
            }
        }

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        static void Exercise31()
        {
            string lineFormat = "{0,-40}";
            var categories = DataLoader.LoadProducts().GroupBy(c => c.Category).OrderByDescending(c => c.Average(p => p.UnitPrice)).Take(3).Select(c => c.Key);


            //var categories = from c in DataLoader.LoadProducts().GroupBy(c => c.Category)
            //                 select new
            //                 {
            //                     Category = c.Key,
            //                     AvgPrice = c.Average(p => p.UnitPrice)
            //                 };
            //categories = categories.OrderByDescending(c => c.AvgPrice).Take(3);


            Console.WriteLine(lineFormat, "Top 3 Categories");
            Console.WriteLine("--------------------");

            foreach (var category in categories)
            {
                Console.WriteLine(lineFormat, category);
            }
        }
    }
}
