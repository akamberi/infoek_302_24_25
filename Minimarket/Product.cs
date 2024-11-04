using MiniMarket;

internal class Product
{
    private string _name;
    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Emri i produktit nuk mund te jete bosh");
            }
            _name = value;
        }
    }
    public string Barcode { get; set; }
    public decimal Quantity { get; set; }

    private decimal _priceOut;
    public decimal PriceOut
    {
        get
        {
            return _priceOut;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Cmimi i shitjes duhet te jete vlere 0 ose pozitive");
            }
            _priceOut = value;
        }
    }

    private decimal _priceIn;
    public decimal PriceIn
    {
        get
        {
            return _priceIn;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Cmimi i blerjes duhet te jete 0 ose pozitiv");
            }
            _priceIn = value;
        }
    }

    public DateTime? ExpiresOn { get; set; }
    public decimal? ExpiringQuantity { get; set; }

    public Category Category { get; set; }
    public Unit Unit { get; set; }

    public override string ToString()
    {
        return @$"
===Produkt===
Emri: {Name},
Barkodi: {Barcode},
Gjendja: {Quantity:0.00},
Kosto: {PriceIn:0.##},
Cm. Shitjes: {PriceOut:0.##},
{(ExpiresOn.HasValue ? "DtSkadence: " + ExpiresOn.Value.ToString("dd/MM/yyyy") + "," : "")}
Kategoria: {Category?.Name},
Njesia: {Unit?.Name}
";
    }

    public static Product KrijoProdukt()
    {
        Console.WriteLine("===KRIJIMI I NJE PRODUKTI");
        Product result = new Product();
        do
        {
            try
            {
                Console.Write("Jep emrin e produktit: ");
                result.Name = Console.ReadLine();
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        } while (true);
        Console.Write("Jep barkodin: ");
        result.Barcode = Console.ReadLine();

        do
        {
            try
            {
                Console.Write("Jep cmimin e shitjes: ");
                result.PriceOut = decimal.Parse(Console.ReadLine());
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        } while (true);
        return result;
    }
}
