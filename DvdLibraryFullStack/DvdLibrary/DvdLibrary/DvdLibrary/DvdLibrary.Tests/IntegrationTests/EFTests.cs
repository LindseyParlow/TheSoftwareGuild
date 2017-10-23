using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Data.SqlClient;
using System.Configuration;
using DvdLibrary.Data;
using DvdLibrary.Models;

namespace DvdLibrary.Tests.IntegrationTests
{
    [TestFixture]
    public class EFTests
    {
        [SetUp]
        public void Init()
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "DbReset";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        [Test]
        public void CanLoadDvds()
        {
            var repo = DvdRepositoryFactory.Create();

            //var repo = new DvdRepositoryADO();

            var dvds = repo.GetAllDvds();

            Assert.AreEqual(5, dvds.Count);
            Assert.AreEqual("Finding Nemo", dvds[0].Title);
            Assert.AreEqual("Judy Thao", dvds[0].Director);
            Assert.AreEqual("G", dvds[0].Rating);
            Assert.AreEqual(2003, dvds[0].ReleaseDate);
        }

        [Test]
        public void CanLoadDvdById()
        {
            var repo = DvdRepositoryFactory.Create();

            var dvd = repo.GetDvdById(1);

            Assert.IsNotNull(dvd);
            Assert.AreEqual(1, dvd.DvdId);
            Assert.AreEqual("Finding Nemo", dvd.Title);
            Assert.AreEqual("Judy Thao", dvd.Director);
            Assert.AreEqual("G", dvd.Rating);
            Assert.AreEqual(2003, dvd.ReleaseDate);
        }

        [Test]
        public void NotFoundListingReturnsNull()
        {
            var repo = DvdRepositoryFactory.Create();

            var dvd = repo.GetDvdById(1000);

            Assert.IsNull(dvd);
        }

        [Test]
        public void CanCreateNewDvd()
        {
            var repo = DvdRepositoryFactory.Create();
            Dvd dvdToAdd = new Dvd();

            dvdToAdd.Title = "Moana";
            dvdToAdd.Director = "Judy Thao";
            dvdToAdd.Rating = "G";
            dvdToAdd.ReleaseDate = 2016;

            repo.CreateDvd(dvdToAdd);

            Assert.AreEqual(6, dvdToAdd.DvdId);
        }

        [Test]
        public void CanUpdateDvd()
        {
            var repo = DvdRepositoryFactory.Create();
            Dvd dvdToAdd = new Dvd();

            dvdToAdd.Title = "Moana";
            dvdToAdd.Director = "Judy Thao";
            dvdToAdd.Rating = "G";
            dvdToAdd.ReleaseDate = 2016;

            repo.CreateDvd(dvdToAdd);

            dvdToAdd.Title = "Rudy";
            dvdToAdd.Director = "Rob Reynolds";
            dvdToAdd.Rating = "PG";
            dvdToAdd.ReleaseDate = 1993;

            repo.UpdateDvd(dvdToAdd);

            var updatedDvd = repo.GetDvdById(6);

            Assert.AreEqual("Rudy", updatedDvd.Title);
            Assert.AreEqual("Rob Reynolds", updatedDvd.Director);
            Assert.AreEqual("PG", updatedDvd.Rating);
            Assert.AreEqual(1993, updatedDvd.ReleaseDate);
        }

        [Test]
        public void CanDeleteDvd()
        {
            var repo = DvdRepositoryFactory.Create();
            Dvd dvdToAdd = new Dvd();

            dvdToAdd.Title = "Moana";
            dvdToAdd.Director = "Judy Thao";
            dvdToAdd.Rating = "G";
            dvdToAdd.ReleaseDate = 2016;

            repo.CreateDvd(dvdToAdd);

            var loaded = repo.GetDvdById(6);
            Assert.IsNotNull(loaded);

            repo.DeleleteDvd(6);
            loaded = repo.GetDvdById(6);

            Assert.IsNull(loaded);
        }

        [Test]
        public void CanLoadDvdByDate()
        {
            var repo = DvdRepositoryFactory.Create();

            var dvds = repo.GetDvdByYear(2017);

            Assert.IsNotNull(dvds);
            Assert.AreEqual(1, dvds.Count());

            Assert.AreEqual(4, dvds[0].DvdId);
            Assert.AreEqual("IT", dvds[0].Title);
            Assert.AreEqual("Mark Johnson", dvds[0].Director);
            Assert.AreEqual("R", dvds[0].Rating);
            Assert.AreEqual(2017, dvds[0].ReleaseDate);
        }

        [Test]
        public void CanLoadDvdByRating()
        {
            var repo = DvdRepositoryFactory.Create();

            var dvds = repo.GetDvdByRating("G");

            Assert.IsNotNull(dvds);
            Assert.AreEqual(2, dvds.Count());

            Assert.AreEqual(3, dvds[1].DvdId);
            Assert.AreEqual("Beauty and the Beast", dvds[1].Title);
            Assert.AreEqual("Javier Aguirre", dvds[1].Director);
            Assert.AreEqual("G", dvds[1].Rating);
            Assert.AreEqual(1991, dvds[1].ReleaseDate);
        }

        [Test]
        public void CanLoadDvdByDirector()
        {
            var repo = DvdRepositoryFactory.Create();

            var dvds = repo.GetDvdByDirector("Nikolas Clay");

            Assert.IsNotNull(dvds);
            Assert.AreEqual(1, dvds.Count());

            Assert.AreEqual(5, dvds[0].DvdId);
            Assert.AreEqual("Jurassic Park", dvds[0].Title);
            Assert.AreEqual("Nikolas Clay", dvds[0].Director);
            Assert.AreEqual("PG-13", dvds[0].Rating);
            Assert.AreEqual(2005, dvds[0].ReleaseDate);
        }

        [Test]
        public void CanLoadDvdByTitle()
        {
            var repo = DvdRepositoryFactory.Create();

            var dvds = repo.GetDvdByTitle("The Shawshank Redemption");

            Assert.IsNotNull(dvds);
            Assert.AreEqual(2, dvds[0].DvdId);
            Assert.AreEqual("The Shawshank Redemption", dvds[0].Title);
            Assert.AreEqual("Jake Ganser", dvds[0].Director);
            Assert.AreEqual("R", dvds[0].Rating);
            Assert.AreEqual(1994, dvds[0].ReleaseDate);
        }
    }
}
