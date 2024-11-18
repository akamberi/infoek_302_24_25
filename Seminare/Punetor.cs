class Punetor
{
    public string Name { get; set; }
    public string Pozicioni { get; set; }
    private int _rroga;
    public int Rroga
    {
        get { return _rroga; }
        set
        {
            if (value > 500000)
            {
                throw new ArgumentException("RROGA NUK MUND TE JETE ME SHUME SE 500000");
            }
            else
            {
                //gjejme diferencen kohore
                var ts = DateTime.Now - DataEFillimit;
                if (ts.TotalDays / 365 >= 2)
                {
                    if (value < 100000)
                    {
                        throw new ArgumentException("RROGA NUK MUND TE JETE ME PAK...");
                    }
                }
            }
            _rroga = value;
        }
    }

    public DateTime DataEFillimit { get; set; }

    //private int NoYears => (int)((DataEFillimit - DateTime.Now).TotalDays / 365);
    private int NoYears
    {
        get
        {
            return (int)((DataEFillimit - DateTime.Now).TotalDays / 365);
        }
    }

    public void RivleresoRrogen()
    {
        var rritjaStd = (int)(3.5 / 100 * Rroga);
        if (NoYears >= 5)
        {
            if (Rroga < 350000)
            {
                Rroga = 350000;
                return;
            }
            else
            {
                rritjaStd = (int)(5 / 100 * Rroga);
            }
        }
        else if (NoYears >= 2)
        {
            var diff = 200000 - Rroga;
            rritjaStd = Math.Max(diff, rritjaStd);
        }
        Rroga += rritjaStd;
    }

    public static Punetor KrijoPunonjes()
    {
        Console.Write("Jep emrin e punonjesit: ");
        string name = Console.ReadLine();
        Console.Write("Jep pozicionin e punonjesit: ");
        string position = Console.ReadLine();
        Console.Write("Jep dt e fillimit (dd/MM/yyyy): ");
        string dtStr = Console.ReadLine();
        var dtStrParts = dtStr.Split('/');
        DateTime startDate = new DateTime(int.Parse(dtStrParts[2]), int.Parse(dtStrParts[1]), int.Parse(dtStrParts[0]));
        Console.Write("Rroga: ");
        int rroga = int.Parse(Console.ReadLine());
        return new Punetor
        {
            Name = name,
            DataEFillimit = startDate,
            Pozicioni = position,
            Rroga = rroga,
        };
    }
}

public class Program
{
    static void Main(string[] args)
    {
        List<Punetor> employees = new List<Punetor>();
        do
        {
            employees.Add(Punetor.KrijoPunonjes());
            Console.WriteLine("Deshironi te shtoni punonjes tjeter? (po per te shtuar, ose cdo gje tjeter per te ndaluar)");
        } while (Console.ReadLine() == "po");

        foreach (var employee in employees)
        {
            Console.WriteLine($"Emri: {employee.Name};");
        }

        decimal avgSalary = 0;
        Punetor maxSalaryEmployee = null, minSalaryEmployee = null;
        foreach (var employee in employees)
        {
            if (maxSalaryEmployee == null)
            {
                maxSalaryEmployee = employee;
            }
            if (minSalaryEmployee == null)
            {
                minSalaryEmployee = employee;
            }

            if (maxSalaryEmployee.Rroga < employee.Rroga)
            {
                maxSalaryEmployee = employee;
            }
            if (minSalaryEmployee.Rroga > employee.Rroga)
            {
                minSalaryEmployee = employee;
            }

            avgSalary += employee.Rroga;
        }
        Console.WriteLine($"Punonjesi me rrogen me te larte: {maxSalaryEmployee.Name}");
        Console.WriteLine($"Punonjesi me rrogen me te ulet: {minSalaryEmployee.Name}");
        Console.WriteLine($"Rroga mesatare: {(avgSalary / employees.Count):0.00}");
    }
}
