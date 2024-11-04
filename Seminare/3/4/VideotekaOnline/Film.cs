namespace ConsoleApp7;

public enum ZhanriFilmit
{
    KOMEDI,
    AKSION,
    DRAME
}

internal class Film
{
    private string _titulli;
    public string Titulli
    {
        get
        {
            return _titulli;
        }
        set
        {
            if (string.IsNullOrEmpty(value) ||
                string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("Titulli i filmit duhet te jete jobosh");
                return;
            }
            _titulli = value;
        }
    }

    private string _regjizori;
    public string Regjizori
    {
        get
        {
            return _regjizori;
        }
        set
        {
            if (string.IsNullOrEmpty(value) ||
                string.IsNullOrWhiteSpace(value)
                )
            {
                Console.WriteLine("Duhet vendosur vlera per regjizorin");
                return;
            }
            _regjizori = value;
        }
    }

    private int _vitiPublikimit;
    public int VitiPublikimit
    {
        get
        {
            return _vitiPublikimit;
        }
        set
        {
            if (value < 1888 || value > DateTime.Now.Year + 5)
            {
                Console.WriteLine("Viti i publikimit duhet te jete 1888 deri ne 5 vite nga tani");
                return;
            }
            _vitiPublikimit = value;
        }
    }

    private float _rating;
    public float Rating
    {
        get
        {
            return _rating;
        }
        set
        {
            if (value < 0 || value > 5)
            {
                Console.WriteLine("Rating mund te jete midis [0.0-5.0]");
                return;
            }
            _rating = value;
        }
    }

    public ZhanriFilmit Zhanri { get; set; }

    public void AfishoInformacion()
    {
        Console.WriteLine($@"
===Te dhenat e filmit===
Titulli: {Titulli},
Regjizori: {Regjizori},
Viti: {VitiPublikimit},
Rating: {Rating:0.#}
Zhanri: {Zhanri}
");
    }

    public static Film KrijoFilm()
    {
        Console.WriteLine("Jep te dhenat e filmit:");
        Film result=new Film(); 
        do
        {
            Console.WriteLine("Jep titullin e filmitL");
            result.Titulli = Console.ReadLine();
        }
        while(string.IsNullOrEmpty(result.Titulli));
        do
        {
            Console.WriteLine("Jep regjisorin e filmit:");
            result.Regjizori= Console.ReadLine();
        }
        while (string.IsNullOrEmpty(result.Regjizori));
        do
        {
            Console.WriteLine("jep vitin e publikimit:");
            int.TryParse(Console.ReadLine(), out int viti);
            result.VitiPublikimit=viti;
        }while(result.VitiPublikimit==0);
        do
        {
            Console.WriteLine("jep vlersimin e filmit:");
            float.TryParse(Console.ReadLine(), out float rating );
            result.Rating = rating;
        } while (result.Rating == 0);

        Console.WriteLine("Opsionet e zhanrit jane: 1. Komedi, 2. Aksion , 3.Drame");
        string input=Console.ReadLine();
        switch(input[0])
        {
            case '1':result.Zhanri = ZhanriFilmit.KOMEDI;
                break;
            case '2':
                result.Zhanri = ZhanriFilmit.AKSION;
                break;
            case '3':
                result.Zhanri = ZhanriFilmit.DRAME;
                break;
            default: Console.WriteLine("Duhet te zgjedhesh opsionet 1,2 ose 3");
                break;
        }
        return result;
    }
}
