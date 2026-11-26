using LINQ.DataSources;

namespace LINQ2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Q1
            var top3Expensive = Source.ProductList
           .OrderByDescending(p => p.UnitPrice)
           .Take(3);
            foreach (var product in top3Expensive)
            {
                Console.WriteLine($"Name: {product.ProductName}, Price: {product.UnitPrice}");
            }
            //Q2
            int pageSize = 5;
            int pageNumber = 2;
            var page2Products = Source.ProductList
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
            foreach (var product in page2Products)
            {
                Console.WriteLine(product.ProductName + " - " + product.UnitPrice);
            }
            //Q3
            var cheapProducts = Source.ProductList
           .OrderBy(p => p.UnitPrice)
           .TakeWhile(p => p.UnitPrice < 25);
            foreach (var product in cheapProducts)
            {
                Console.WriteLine(product.ProductName + " - " + product.UnitPrice);
            }
            //Q4
            var allSeafoodInStock = Source.ProductList
           .Where(p => p.Category == "Seafood")
           .All(p => p.UnitsInStock > 0);
            //Q5
            int[] ids = { 3, 9, 13, 18 };
            var hasNine = ids.Contains(9);
            Console.WriteLine(hasNine);
            //Q6
            var groupedProducts = Source.ProductList
            .GroupBy(p => p.Category);
            foreach (var group in groupedProducts)
            {
                Console.WriteLine(group.Key + " - Count: " + group.Count());
            }
            // Q7
            var productsByCategory = Source.ProductList
                .GroupBy(p => p.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    ProductNames = g.Select(p => p.ProductName)
                });
            foreach (var group in productsByCategory)
            {
                Console.WriteLine("Category: " + group.Category);
                foreach (var name in group.ProductNames)
                {
                    Console.WriteLine("  - " + name);
                }
            }
            // Q8
            var categoriesWithMoreThan3 = Source.ProductList
           .GroupBy(p => p.Category)
          .Where(g => g.Count() > 3)
          .Select(g => g.Key);
            foreach (var category in categoriesWithMoreThan3)
            {
                Console.WriteLine(category);
            }
            // Q9
            var customersByCountry = from c in Source.CustomerList
                                     group c by c.Country into g
                                     select new
                                     {
                                         Country = g.Key,
                                         Count = g.Count(),
                                         TotalOrderValue = g.SelectMany(c => c.Orders).Sum(o => o.Total)
                                     };
            // Q10
            var totalUnitsInStock = Source.ProductList
           .Sum(p => p.UnitsInStock);
            // Q11
            var cheapestPrice = Source.ProductList
           .Min(p => p.UnitPrice);
            var mostExpensivePrice = Source.ProductList
                .Max(p => p.UnitPrice);
            // Q12
            var distinctCategories = Source.ProductList
           .Select(p => p.Category)
            .Distinct();
            // Q13
            int[] setA = { 1, 3, 5, 7, 9, 11, 13 };
            int[] setB = { 3, 6, 9, 12, 15, 13 };
            var onlyInSetA = setA.Except(setB);
            foreach (var id in onlyInSetA)
            {
                Console.WriteLine(id);
            }
            // Q14
            string[] list1 = { "Germany", "France", "UK", "Spain" };
            string[] list2 = { "france", "SPAIN", "Italy" };
            var countriesOnlyInList1 = list1.Except(list2, StringComparer.OrdinalIgnoreCase);
            foreach (var country in countriesOnlyInList1)
            {
                Console.WriteLine(country);
            }
        }
    }
}
