using DvdLibrary.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvdLibrary.Models;

namespace DvdLibrary.Data.Repositories
{
    public class DvdRepositoryMock : IDvdRepository
    {
        private static List<Dvd> _dvds;

        static DvdRepositoryMock()
        {
            _dvds = new List<Dvd>()
            {
                new Dvd { DvdId=1, Title="Finding Nemrod", Director="Judy Thao", Rating="G", ReleaseDate=2003},
                new Dvd { DvdId=2, Title="The Shawshank Hooray", Director="Jake Ganser", Rating="R", ReleaseDate=1994},
                new Dvd { DvdId=3, Title="Beauty and the Beast", Director="Javier Aguirre", Rating="G", ReleaseDate=1991},
                new Dvd { DvdId=4, Title="IT", Director="Mark Johnson", Rating="R", ReleaseDate=2017},
                new Dvd { DvdId=5, Title="Jurassic Park", Director="Nikolas Clay", Rating="PG-13", ReleaseDate=2005},
            };
        }


        public void CreateDvd(Dvd newDvd)
        {
            if (_dvds.Any())
            {
                newDvd.DvdId = _dvds.Max(d => d.DvdId) + 1;
            }
            else
            {
                newDvd.DvdId = 1;
            }

            _dvds.Add(newDvd);
        }

        public void DeleleteDvd(int dvdId)
        {
            _dvds.RemoveAll(d => d.DvdId == dvdId);
        }

        public List<Dvd> GetAllDvds()
        {
            return _dvds;
        }

        public List<Dvd> GetDvdByDirector(string director)
        {
            return _dvds.Where(d => d.Director == director).ToList();
        }

        public Dvd GetDvdById(int dvdId)
        {
            return _dvds.FirstOrDefault(d => d.DvdId == dvdId);
        }

        public List<Dvd> GetDvdByRating(string rating)
        {
            return _dvds.Where(d => d.Rating == rating).ToList();
        }

        public List<Dvd> GetDvdByTitle(string title)
        {
            return _dvds.Where(d => d.Title == title).ToList();
        }

        public List<Dvd> GetDvdByYear(int releaseYear)
        {
            return _dvds.Where(d => d.ReleaseDate == releaseYear).ToList();
        }

        public void UpdateDvd(Dvd updatedDvd)
        {
            _dvds.RemoveAll(d => d.DvdId == updatedDvd.DvdId);
            _dvds.Add(updatedDvd);
        }
    }
}
