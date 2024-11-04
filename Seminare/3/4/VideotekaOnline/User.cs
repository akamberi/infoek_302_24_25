namespace ConsoleApp7;

internal class User
{
    public string Name { get; set; }
    public List<Film> Favourites { get; set; }
    public User()
    {
        Favourites = new List<Film>();
    }

    public void AddToFavourites(Film film)
    {
        Favourites.Add(film);
    }

    public void PrintFavourites()
    {
        foreach(var film in Favourites)
        {
            film.AfishoInformacion();
        }
    }
}
