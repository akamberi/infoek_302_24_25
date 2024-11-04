using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class Videoteka
    {
        public List<Film> Filma { get; set; }

        public void Shtofilm(Film film)
        {
            if (Filma == null)
            {
                Filma = new List<Film>();
            }
            Filma.Add(film);
        }
        public List<Film> Kerkofilma(string query)
        {
            List<Film> result = new List<Film>();
            foreach (var film in Filma)
            {
                if (film.Titulli.ToLower().Contains(query.ToLower()))
                {
                    result.Add(film);
                }
                else if (film.Zhanri.ToString().ToLower().Contains(query.ToLower()))
                {
                    result.Add(film);
                }
            }
            return result;
        }

        public void AfishoTeGjitheFilmat()
        {
            foreach(var film in Filma)
            {
                film.AfishoInformacion();
            }
        }


    }
}
