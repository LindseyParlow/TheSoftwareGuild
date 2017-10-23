using DvdLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Data.Interfaces
{
    public interface IDvdRepository
    {
        List<Dvd> GetAllDvds();
        Dvd GetDvdById(int dvdId);
        List<Dvd> GetDvdByTitle(string title);
        List<Dvd> GetDvdByYear(int releaseYear);
        List<Dvd> GetDvdByDirector(string director);
        List<Dvd> GetDvdByRating(string rating);
        void CreateDvd(Dvd newDvd);
        void UpdateDvd(Dvd updatedDvd);
        void DeleleteDvd(int dvdId);
    }
}
