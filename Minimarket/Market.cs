using MiniMarket;


internal class Market
{
    public List<Product> Products { get; set; }
    public List<Category> Categories { get; set; }
    public List<Unit> Units { get; set; }

    public Market()
    {
        Products = new List<Product>();
        Categories = new List<Category>
        {
            new Category
            {
               Name = "Bulmetra"
            },
            new Category
            {
                Name = "Fruta"
            },
            new Category
            {
                Name = "Kancelari"
            }
        };
        Units = new List<Unit>
        {
            new Unit
            {
                Name = "Kg"
            },
            new Unit
            {
                Name ="Liter"
            },
            new Unit
            {
                Name = "Cope"
            }
        };
    }

    public void AddProduct(Product product = null)
    {
        if (product == null)
            product = Product.KrijoProdukt();
        while (product.Category == null)
        {
            Console.WriteLine("Zgjidh kategorine: ");
            for (var i = 0; i < Categories.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Categories[i].Name}");
            }
            var cat = Console.ReadLine();
            foreach (var kategori in Categories)
            {
                if (cat == kategori.Name)
                {
                    product.Category = kategori;
                    break;
                }
            }
        }
        while (product.Unit == null)
        {
            Console.WriteLine("Zgjidh njesine: ");
            for (var i = 0; i < Units.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Units[i].Name}");
            }
            var unit = Console.ReadLine();
            foreach (var njesi in Units)
            {
                if (unit == njesi.Name)
                {
                    product.Unit = njesi;
                    break;
                }
            }
        }
        Console.WriteLine(product);
        Products.Add(product);
    }
}