//using ConsoleApp7;

//Film f1 = new Film
//{
//    Titulli = "Little",
//    Regjizori = "Blumberg",
//    Zhanri = ZhanriFilmit.DRAME,
//    Rating = 4.2f,
//    VitiPublikimit = 2020
//};
//f1.AfishoInformacion();
using ConsoleApp7;

Videoteka v1= new Videoteka();
v1.Shtofilm(Film.KrijoFilm());
v1.Shtofilm(Film.KrijoFilm());
v1.Shtofilm(Film.KrijoFilm());
v1.AfishoTeGjitheFilmat();
