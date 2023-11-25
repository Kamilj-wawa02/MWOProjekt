using Bogus;

namespace LibraryWebAppMVC.Library
{
    public class BookSeeder
    {
        public static List<Book> GenerateBookData()
        {
            int productId = 1;
            var productFaker = new Faker<Book>()
                .UseSeed(123456)
                .RuleFor(x => x.Title, x => x.Commerce.ProductName())
                .RuleFor(x => x.Author, x => x.Name.FullName())
                .RuleFor(x => x.Description, x => x.Commerce.ProductDescription())
                .RuleFor(x => x.Id, x => productId++);
                

            return productFaker.Generate(10).ToList();
        }
    }
}