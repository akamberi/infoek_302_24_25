public class Program
{

    static bool IThjeshte(int nr)
    {
        for (int i = 2; i < nr; i++)
        {
            if (nr % i == 0)
                return false;
        }
        return true;
    }

    static void Rendit(int[] numrat)
    {
        for (int i = 0; i < numrat.Length; i++)
        {
            for (int j = i + 1; j < numrat.Length; j++)
            {
                if (numrat[i] < numrat[j])
                {
                    var tmp = numrat[i];
                    numrat[i] = numrat[j];
                    numrat[j] = tmp;
                }
            }
        }
    }

    static void AfishoVektor(int[] numrat)
    {
        Console.WriteLine("Elementet e vektorit");
        foreach (var nr in numrat)
            Console.Write($"{nr}\t");
        Console.WriteLine();
    }

    static void Ushtrimi1()
    {
        Console.Write("Jep nje numer: ");
        int n = int.Parse(Console.ReadLine());
        var numratEThjeshte = new int[n];
        int gjetur = 0;
        int numer = 1;
        while (gjetur < n)
        {
            if (IThjeshte(numer))
            {
                numratEThjeshte[gjetur] = numer;
                gjetur++;
            }
            numer++;
        }
        Rendit(numratEThjeshte);
        AfishoVektor(numratEThjeshte);
    }

    static int[] GjeneroFib(int n)
    {
        var result = new int[n];
        int k1 = 0;
        int k2 = 1;
        result[0] = k1;
        result[1] = k2;
        int gjetur = 2;
        for (; gjetur < n; gjetur++)
        {
            int k = k1 + k2;
            result[gjetur] = k;
            k1 = k2;
            k2 = k;

        }
        return result;
    }

    static int GjejShumaV(int[] nr)
    {
        int s = 0;
        foreach (var n in nr)
            s += n;
        return s;
    }

    static void Ushtrimi2()
    {
        Console.Write("Jep nje numer: ");
        int n = int.Parse(Console.ReadLine());
        var numratFib = GjeneroFib(n);
        AfishoVektor(numratFib);
        var shuma = GjejShumaV(numratFib);
        Console.WriteLine($"Shuma: {shuma}");
    }

    static int NRperseritje(int[] numrat, int n)
    {
        int count = 0;
        for (int i = 0; i < numrat.Length; i++)
        {
            if (numrat[i] == n)
            {
                count++;
            }
        }
        return count;
    }

    static void Ushtrimi3()
    {
        Dictionary<int, int> dict = new Dictionary<int, int>();
        var numra = new int[] { 1, 3, 7, 1, 7, 4, 4, 4 };
        foreach (var nr in numra)
        {
            if (!dict.ContainsKey(nr))
            {
                dict.Add(nr, NRperseritje(numra, nr));
            }
        }
        foreach (var nr in dict.Keys)
        {
            Console.WriteLine($"{nr}->{dict[nr]}");
        }
    }


    public static void Main(string[] args)
    {
        // Ushtrimi1(); 
        // Ushtrimi2();
        Ushtrimi3();
    }
}
