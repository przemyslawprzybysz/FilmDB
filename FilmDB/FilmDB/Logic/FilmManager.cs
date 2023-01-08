using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmDB.Models;

namespace FilmDB.Logic
{
	public class FilmManager
	{
        public FilmManager AddFilm(FilmModel filmModel)
        {
            using (var context = new FilmContext())
            {
                context.Add(filmModel);
                context.SaveChanges();
            }
                return this;
        }

        public FilmManager RemoveFilm(int id)
        {
            using (var context = new FilmContext())
            {
                var filmToDelete = context.Films.SingleOrDefault(x => x.Id == id);
                context.Films.Remove(filmToDelete);
                context.SaveChanges();
            }
            return this;
        }

        public FilmManager UpdateFilm(FilmModel filmModel)
        {
            using (var context = new FilmContext())
            {
                context.Films.Update(filmModel);
                context.SaveChanges();
            }
            return this;
        }

        public FilmManager ChangeTitle(int id, string newTitle)
        {
            using (var context = new FilmContext())
            {
                var filmToChangeTitle = context.Films.Single(x => x.Id == id);
                if (string.IsNullOrEmpty(newTitle))
                {
                    newTitle = "Brak tytułu";
                }
                filmToChangeTitle.Name = newTitle;
                this.UpdateFilm(filmToChangeTitle);
            }
            return this;
        }

        public FilmModel GetFilm(int id)
        {
            FilmModel filmById;
            using (var context = new FilmContext())
            {
                filmById = context.Films.Single(x => x.Id == id);
            }
            return filmById;
        }

        public List<FilmModel> GetFilms()
        {
            using (var context = new FilmContext())
            {
                var filmList = context.Films.ToList();
                return filmList;
            }
        }
    }
}
