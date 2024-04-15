using System.Text.Json;

namespace Ksiazki
{
  public class Ksiazka
  {
    static List<Ksiazka>? ksiazki = new List<Ksiazka>();
    static string path = "Ksiazki.json";

    static Ksiazka() => RefreshData();

    public static void RefreshData() =>
      ksiazki = JsonSerializer.Deserialize<List<Ksiazka>>(File.ReadAllText(path));

    public static bool Exists(int id) {
      return ksiazki.Any(k => k.Id == id);
    }

    
    public static void Remove(int id)
    {
      if (!Exists(id)) {
        Console.WriteLine("Ksiazka nie istnieje.");
        return;
      }

      ksiazki.RemoveAll((k) => k.Id == id);
      NormalizeIds();

      File.WriteAllText(path, JsonSerializer.Serialize(ksiazki));
    }

    // Po usunieciu id ksiazki, ta funkcja naprawia id, zeby nagle sie nie okazalo ze jest jakas luka, np brakuje id 2, ale 1 i 3 istnieje.
    public static void NormalizeIds() => 
      ksiazki.ForEach(k => k.Id = ksiazki.IndexOf(k) + 1);

    public static void ShowAll()
    {
      ksiazki.ForEach(k =>
      {
        Info(k);
        Console.WriteLine("---------------------");
      });
    }
        public static void Show(int id)
        {
            if (!Exists(id))
            {
                Console.WriteLine("Ksiazka nie istnieje.");
                return;
            }
            Ksiazka k = ksiazki.Find(k => k.Id == id);

            Info(k);
        }
        public static void Info(Ksiazka k) {
      Console.WriteLine($"{k.Id} | {k.Tytul}");
      Console.WriteLine(k.Gatunek);
      Console.WriteLine(k.Autor);
      Console.WriteLine(k.RokWydania);
    }

        public int Id { get; set; }
        public string? Tytul { get; set; }
        public string? Autor { get; set; }
        public int RokWydania { get; set; }
        public string? Gatunek { get; set; }
    }

public static void Add(string tytul, string autor, int rokWydania, string gatunek)
{
    ksiazki.Add(
      new Ksiazka
      {
          Id = ksiazki.Count + 1,
          Tytul = tytul,
          Autor = autor,
          RokWydania = rokWydania,
          Gatunek = gatunek,
      });

    File.WriteAllText(path, JsonSerializer.Serialize(ksiazki));
}
}