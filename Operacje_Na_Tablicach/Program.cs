using System;

class Tablica
{
    private int[] data;
    private int count;

    public Tablica(int size)
    {
        if (size <= 0)
        {
            throw new ArgumentException("Rozmiar tablicy musi być większy od 0.");
        }

        count = size;
        data = new int[count];
        Random rand = new Random();

        for (int i = 0; i < count; i++)
        {
            data[i] = rand.Next(1, 1001); // 1..1000
        }
    }

    public void DisplayAll()
    {
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"{i}: {data[i]}");
        }
    }

    public int FindFirst(int value)
    {
        for (int i = 0; i < count; i++)
        {
            if (data[i] == value)
            {
                return i;
            }
        }
        return -1;
    }

    public int DisplayOdds()
    {
        int oddCount = 0;
        Console.WriteLine("Liczby nieparzyste:");
        for (int i = 0; i < count; i++)
        {
            if (data[i] % 2 != 0)
            {
                Console.WriteLine(data[i]);
                oddCount++;
            }
        }
        return oddCount;
    }

    public double Average()
    {
        long sum = 0;
        for (int i = 0; i < count; i++)
        {
            sum += data[i];
        }
        return (double)sum / count;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Tablica tablica = new Tablica(25);

        tablica.DisplayAll();

        // Wyszukiwanie wartości (opcjonalnie jak w zadaniu)
        Console.WriteLine("\nPodaj wartość do wyszukania:");
        if (int.TryParse(Console.ReadLine(), out int searchValue))
        {
            int index = tablica.FindFirst(searchValue);
            if (index != -1)
            {
                Console.WriteLine($"Wartość {searchValue} znaleziona na indeksie {index}.");
            }
        }

        Console.WriteLine();
        int oddCount = tablica.DisplayOdds();
        Console.WriteLine($"\nRazem nieparzystych: {oddCount}");

        double avg = tablica.Average();
        Console.WriteLine($"Średnia wszystkich elementów: {avg:F0}");
    }
}
