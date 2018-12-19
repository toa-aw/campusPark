using SmartPark.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartPark.Controllers
{
    public class ParksController : ApiController
    {
        string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["SmartPark.Properties.Settings.ConnStr"].ConnectionString;

        public IEnumerable<Park> GetAllParks()
        {
            List<Park> parks = new List<Park>();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM ParkingLots", conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Park park = new Park
                        {
                            Id = (int)reader["Id"],
                            Name = reader["Name"].ToString(),
                            Description = reader["Description"].ToString(),
                            NumberOfSpots = (int)reader["NumberOfSpots"],
                            OperatingHours = reader["OpeningHours"].ToString(),
                            NumberOfSpecialSpots = (int)reader["NumberOfSpecialSpots"],
                    };
                        parks.Add(park);
                    }
                    reader.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return parks;
        }

        [Route("api/parks/{id:int}")]
        public IHttpActionResult GetParkInformation(int id)
        {
            Park park = new Park();
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM ParkingLots WHERE id = @idpark";
                cmd.Parameters.AddWithValue("@idpark", id);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = conn;

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        park.Id = (int)reader["Id"];
                        park.Name = reader["Name"].ToString();
                        park.Description = reader["Description"].ToString();
                        park.NumberOfSpots = (int)reader["NumberOfSpots"];
                        park.OperatingHours = reader["OpeningHours"].ToString();
                        park.NumberOfSpecialSpots = (int)reader["NumberOfSpecialSpots"];
                        reader.Close();
                        return Ok(park);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return NotFound();
        }

        [Route("api/parks/{id:int}/occupancy")]
        public IHttpActionResult GetParkOccupancyRate(int id)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT occupied, totalSpots " +
                                  "FROM (SELECT COUNT(*) AS occupied FROM ParkingSpotsInfo WHERE UPPER(status) = 'OCCUPIED' AND parkinglotid = @idpark) AS t1, " +
                                       "(SELECT COUNT(*) AS totalSpots FROM ParkingSpotsInfo WHERE parkinglotid = @idpark) AS t2";
                cmd.Parameters.AddWithValue("@idpark", id);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = conn;

                decimal occupied;
                decimal free;

                decimal occupancyRate;

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        occupied = Convert.ToDecimal(reader["occupied"]);
                        free = Convert.ToDecimal(reader["totalSpots"]);

                        occupancyRate = (occupied / free) * 100;
                        reader.Close();
                        return Ok(occupancyRate);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return NotFound();
        }
    }
}
