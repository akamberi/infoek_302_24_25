public enum WarehouseType
{
    VIRTUAL,
    REAL
}
public class Warehouse
{
    //abcdef...., value.substring(0,2)
    //0123456....value.substring(2,3)
    //abcdef....,value.substring(5,2)
    private bool ContainsChars(string container, string checker)
    {
        foreach (var c in checker)
        {
            if (!container.Contains(c))
                throw new ArgumentOutOfRangeException("Nuk perputhet formati i pritshem");
        }
        return true;
    }

    public string Name { get; set; }

    private string _code;
    public string Code
    {
        get
        {
            return _code;
        }
        set
        {
            if (value.Length != 7)
                throw new ArgumentOutOfRangeException("Kodi i magazines duhet te jete me 7 karaktere");
            value = value.ToLower();
            string lowerCaseAlphabet = "abcdefghijklmnopqrstuvwxyz";
            string numericChars = "0123456789";

            //ContainsChars(lowerCaseAlphabet, value.Substring(0, 2));
            //ContainsChars(numericChars, value.Substring(2, 3));
            //ContainsChars(lowerCaseAlphabet, value.Substring(5));

            if (!lowerCaseAlphabet.Contains(value[0]) || !lowerCaseAlphabet.Contains(value[1]))
            {
                throw new ArgumentOutOfRangeException("2 karakteret e para duhet te jene germa");
            }
            if (!(numericChars.Contains(value[2]) &&
                numericChars.Contains(value[3]) &&
                numericChars.Contains(value[4]))
                )
            {
                throw new ArgumentOutOfRangeException("Ne mes te kodit duhen 3 numra");
            }
            if (!lowerCaseAlphabet.Contains(value[5]) || !lowerCaseAlphabet.Contains(value[6]))
            {
                throw new ArgumentOutOfRangeException("2 karakteret e fundit duhet te jene germa");
            }
            _code = value;
        }
    }
    public WarehouseType Type { get; set; }
    public decimal Xhiro { get; set; }


    public static Warehouse KrijoMagazine()
    {
        Console.Write("Jep emrin: ");
        string name = Console.ReadLine();
        Console.Write("Jep kodin: ");
        string code = Console.ReadLine();
        Console.Write("Jep tipin: 1 - Virtuale, 2 - Reale");
        int type = int.Parse(Console.ReadLine());
        WarehouseType wt = WarehouseType.REAL;
        if (type == 1) 
         wt = WarehouseType.VIRTUAL;
        Console.Write("Jep xhiron e magazines: ");
        decimal xhiro=decimal.Parse(Console.ReadLine());

        return new Warehouse
        {
            Name = name,
            Code = code,
            Type = wt,
            Xhiro = xhiro
        };
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Warehouse[] warehouses = new Warehouse[3];
        for (var i = 0; i < warehouses.Length; i++)
        {
            warehouses[i] = Warehouse.KrijoMagazine();
        }
        foreach (var wh in warehouses)
        {
            if (wh.Type == WarehouseType.REAL)
            {
                Console.WriteLine($"Magazina: {wh.Name}; Kodi: {wh.Code}");
            }
        }
        Warehouse warehouse = null;
        decimal maxxhiro = 0;
        foreach (var wh in warehouses)
        {
            if(wh.Xhiro > maxxhiro)
            {
                warehouse = wh;
                maxxhiro = wh.Xhiro;
            }
        }
        Console.WriteLine("Magazina me xhiron me te larte eshte: " + warehouse.Name);

    }
}
