using DvdLibrary.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvdLibrary.Models;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DvdLibrary.Data.Repositories
{
    public class DvdRepositoryADO : IDvdRepository
    {
        public void CreateDvd(Dvd newDvd)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdAddNew", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@DvdId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@Title", newDvd.Title);
                cmd.Parameters.AddWithValue("@Director", newDvd.Director);
                cmd.Parameters.AddWithValue("@Rating", newDvd.Rating);
                cmd.Parameters.AddWithValue("@Date", newDvd.ReleaseDate);
                cmd.Parameters.AddWithValue("@Notes", newDvd.Notes);

                cn.Open();

                cmd.ExecuteNonQuery();

                newDvd.DvdId = (int)param.Value;
            }
        }

        public void DeleleteDvd(int dvdId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@DvdId", dvdId);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public List<Dvd> GetAllDvds()
        {
            List<Dvd> dvds = new List<Dvd>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();
                        currentRow.DvdId = (int)dr["DvdId"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.Director = dr["Director"].ToString();
                        currentRow.Rating = dr["Rating"].ToString();
                        currentRow.ReleaseDate = (int)dr["ReleaseDate"];
                        currentRow.Notes = dr["Notes"].ToString();

                        dvds.Add(currentRow);
                    }
                }
                cn.Close();
            }
            return dvds;

        }

        public List<Dvd> GetDvdByDirector(string director)
        {
            List<Dvd> dvds = new List<Dvd>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdSelectByDirector", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Director", director);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd dvd = new Dvd();

                        dvd.DvdId = (int)dr["DvdId"];

                        if (dr["Title"] != DBNull.Value)
                            dvd.Title = dr["Title"].ToString();
                        if (dr["Director"] != DBNull.Value)
                            dvd.Director = dr["Director"].ToString();
                        if (dr["Rating"] != DBNull.Value)
                            dvd.Rating = dr["Rating"].ToString();
                        if (dr["Date"] != DBNull.Value)
                            dvd.ReleaseDate = (int)dr["Date"];
                        if (dr["Notes"] != DBNull.Value)
                            dvd.Notes = dr["Notes"].ToString();

                        dvds.Add(dvd);
                    }
                }
                cn.Close();
            }

            return dvds;
        }

        public Dvd GetDvdById(int dvdId)
        {
            Dvd dvd = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdSelectById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DvdId", dvdId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        dvd = new Dvd();

                        dvd.DvdId = (int)dr["DvdId"];
                        
                        if(dr["Title"] != DBNull.Value)
                            dvd.Title = dr["Title"].ToString();
                        if (dr["Director"] != DBNull.Value)
                            dvd.Director = dr["Director"].ToString();
                        if (dr["Rating"] != DBNull.Value)
                            dvd.Rating = dr["Rating"].ToString();
                        if (dr["Date"] != DBNull.Value)
                            dvd.ReleaseDate = (int)dr["Date"];
                        if (dr["Notes"] != DBNull.Value)
                            dvd.ReleaseDate = (int)dr["Notes"];


                    }
                }
                cn.Close();
            }

            return dvd;
        }

        public List<Dvd> GetDvdByRating(string rating)
        {
            List<Dvd> dvds = new List<Dvd>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdSelectByRating", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Rating", rating);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd dvd = new Dvd();

                        dvd.DvdId = (int)dr["DvdId"];

                        if (dr["Title"] != DBNull.Value)
                            dvd.Title = dr["Title"].ToString();
                        if (dr["Director"] != DBNull.Value)
                            dvd.Director = dr["Director"].ToString();
                        if (dr["Rating"] != DBNull.Value)
                            dvd.Rating = dr["Rating"].ToString();
                        if (dr["Date"] != DBNull.Value)
                            dvd.ReleaseDate = (int)dr["Date"];
                        if (dr["Notes"] != DBNull.Value)
                            dvd.ReleaseDate = (int)dr["Notes"];

                        dvds.Add(dvd);
                    }
                }
                cn.Close();
            }

            return dvds;
        }

        public List<Dvd> GetDvdByTitle(string title)
        {
            List<Dvd> dvds = new List<Dvd>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdSelectByTitle", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Title", title);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd dvd = new Dvd();

                        dvd.DvdId = (int)dr["DvdId"];

                        if (dr["Title"] != DBNull.Value)
                            dvd.Title = dr["Title"].ToString();
                        if (dr["Director"] != DBNull.Value)
                            dvd.Director = dr["Director"].ToString();
                        if (dr["Rating"] != DBNull.Value)
                            dvd.Rating = dr["Rating"].ToString();
                        if (dr["Date"] != DBNull.Value)
                            dvd.ReleaseDate = (int)dr["Date"];
                        if (dr["Notes"] != DBNull.Value)
                            dvd.ReleaseDate = (int)dr["Notes"];

                        dvds.Add(dvd);
                    }
                }
                cn.Close();
            }

            return dvds;
        }

        public List<Dvd> GetDvdByYear(int date)
        {
            List<Dvd> dvds = new List<Dvd>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdSelectByDate", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Date", date);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd dvd = new Dvd();

                        dvd.DvdId = (int)dr["DvdId"];

                        if (dr["Title"] != DBNull.Value)
                            dvd.Title = dr["Title"].ToString();
                        if (dr["Director"] != DBNull.Value)
                            dvd.Director = dr["Director"].ToString();
                        if (dr["Rating"] != DBNull.Value)
                            dvd.Rating = dr["Rating"].ToString();
                        if (dr["Date"] != DBNull.Value)
                            dvd.ReleaseDate = (int)dr["Date"];
                        if (dr["Notes"] != DBNull.Value)
                            dvd.ReleaseDate = (int)dr["Notes"];

                        dvds.Add(dvd);
                    }
                }
                cn.Close();
            }

            return dvds;
        }

        public void UpdateDvd(Dvd updatedDvd)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@DvdId", updatedDvd.DvdId);
                cmd.Parameters.AddWithValue("@Title", updatedDvd.Title);
                cmd.Parameters.AddWithValue("@Director", updatedDvd.Director);
                cmd.Parameters.AddWithValue("@Rating", updatedDvd.Rating);
                cmd.Parameters.AddWithValue("@Date", updatedDvd.ReleaseDate);
                cmd.Parameters.AddWithValue("@Notes", updatedDvd.Notes);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}
