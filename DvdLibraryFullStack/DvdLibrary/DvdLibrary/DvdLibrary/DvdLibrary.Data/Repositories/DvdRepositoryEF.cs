using DvdLibrary.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvdLibrary.Models;

namespace DvdLibrary.Data.Repositories
{
    public class DvdRepositoryEF : IDvdRepository
    {
        public void CreateDvd(Dvd newDvd)
        {
            using (var context = new DvdLibraryEntities())
            {
                if (context.Dvds.Any())
                {
                    newDvd.DvdId = context.Dvds.Max(d => d.DvdId) + 1;
                }
                else
                {
                    newDvd.DvdId = 0;
                }

                context.Dvds.Add(newDvd);
                context.SaveChanges();
            }
        }

        public void DeleleteDvd(int dvdId)
        {
            using (var context = new DvdLibraryEntities())
            {
                Dvd dvdToRemove = context.Dvds.Find(dvdId);

                context.Dvds.Remove(dvdToRemove);
                context.SaveChanges(); 
            }
        }

        public List<Dvd> GetAllDvds()
        {
            using (var context = new DvdLibraryEntities())
            {
                var dvds = from d in context.Dvds
                           select d;

                return dvds.ToList();
            }
        }

        public List<Dvd> GetDvdByDirector(string director)
        {
            using (var context = new DvdLibraryEntities())
            {
                return context.Dvds.Where(d => d.Director == director).ToList();
            }
        }

        public Dvd GetDvdById(int dvdId)
        {
            using (var context = new DvdLibraryEntities())
            {
                var dvd = (from d in context.Dvds where d.DvdId == dvdId select d).FirstOrDefault();

                return dvd;
            }

        }

        public List<Dvd> GetDvdByRating(string rating)
        {
            using (var context = new DvdLibraryEntities())
            {
                return context.Dvds.Where(d => d.Rating == rating).ToList();
            }
        }

        public List<Dvd> GetDvdByTitle(string title)
        {
            using (var context = new DvdLibraryEntities())
            {
                return context.Dvds.Where(d => d.Title == title).ToList();
            }
        }

        public List<Dvd> GetDvdByYear(int releaseYear)
        {
            using (var context = new DvdLibraryEntities())
            {
                return context.Dvds.Where(d => d.ReleaseDate == releaseYear).ToList();
            }
        }

        public void UpdateDvd(Dvd updatedDvd)
        {
            using (var context = new DvdLibraryEntities())
            {
                context.Entry(updatedDvd).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
