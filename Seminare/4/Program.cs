internal class Program
{
    public static void Main(string[] args)
    {
        var garazhdi = new Garazhd();
        garazhdi.ShtoMakine(Makina.KrijoMakine());
        garazhdi.ShtoMakine(Makina.KrijoMakine());
        garazhdi.AfishoMakinat();
        Console.WriteLine("Kerko makine: ");
        string q = Console.ReadLine();
        garazhdi.KerkoMakine(q);
    }
}
internal class Makina
{

    public string Marka { get; set; }
    public string Modeli { get; set; }
    public int VitiRegjistrimit { get; set; }

    public Makina(string Marka, string Modeli, int VitiRegjistrimit)
    {
        this.Marka = Marka;
        this.Modeli = Modeli;
        this.VitiRegjistrimit = VitiRegjistrimit;
    }
    public void ShfaqDetajet()
    {
        Console.WriteLine($"Marka e makines: {Marka}\n" +
            $"Modeli i makines: {Modeli}\n" +
            $"Viti i regjistrimit: {VitiRegjistrimit}");
    }

    internal static Makina KrijoMakine()
    {
        Console.WriteLine("Jep marken e makines:  ");
        string marka = Console.ReadLine();
        Console.WriteLine("Jep modelin e makines:  ");
        string modeli = Console.ReadLine();
        Console.WriteLine("Jep vitin e prodhimi  te makines:  ");
        int vitiProdhimit = int.Parse(Console.ReadLine());
        var result = new Makina(marka, modeli, vitiProdhimit);
        return result;
    }
}
class Garazhd
{
    private List<Makina> Makinat = new List<Makina>();
    public void ShtoMakine(Makina makina)
    {
        Makinat.Add(makina);

    }
    public void AfishoMakinat()
    {
        foreach (var makina in Makinat)
        {
            makina.ShfaqDetajet();
        }

    }
    public void KerkoMakine(string query)
    {
        foreach (var makina in Makinat)
        {
            if (makina.Modeli.ToLower().Contains(query.ToLower())
                || makina.Marka.ToLower().Contains(query.ToLower())
                )
            {
                Console.WriteLine(makina);
            }
        }
    }
}
