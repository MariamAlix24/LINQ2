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
        }
    }
}
