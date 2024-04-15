using Ksiazki;

void menu(string? message = "") {
  Console.Clear();

  if(!string.IsNullOrEmpty(message)) Console.WriteLine(message);
  Console.WriteLine("1. Wyswietl wszystkie ksiazki");
  Console.WriteLine("2. Wyswietl szczegolna ksiazke");
  Console.WriteLine("3. Dodaj ksiazke");
  Console.WriteLine("4. Usun ksiazke");

  int i = Convert.ToInt16(Console.ReadLine());
  
  switch (i)
  {
    default: 
      menu();
      break;

    case 1: 
      Ksiazka.ShowAll();
      Console.ReadKey();

      menu();
      break;

    case 2:
      Console.WriteLine("Podaj id ksiazki, ktora chcesz wyswietlic");
      Ksiazka.Show(Convert.ToInt16(Console.ReadLine()));
      Console.ReadKey();

      menu();
      break;

    case 3:
      Console.WriteLine("Podaj tytul");
      string title = Console.ReadLine();

      Console.WriteLine("Podaj autora");
      string author = Console.ReadLine();

      Console.WriteLine("Podaj rok wydania");
      int releaseDate = Convert.ToInt16(Console.ReadLine());

      Console.WriteLine("Podaj gatunek");
      string genre = Console.ReadLine();

      Ksiazka.Add(title, author, releaseDate, genre);

      menu("Ksiazka dodana!");
      break;

    case 4:
      Console.WriteLine("Podaj id ksiazki, ktora chcesz usunac");
      Ksiazka.Remove(Convert.ToInt16(Console.ReadLine()));

      menu("Ksiazka usunieta!");
      break;
  }
}
menu();
