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
        }
    }
}
