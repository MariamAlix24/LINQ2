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
        }
    }
}
