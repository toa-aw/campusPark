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
        public IEnumerable<Park> GetAllParks()
        {
            List<Park> parks = new List<Park>();

            using (SqlConnection conn = new SqlConnection())
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
            using (SqlConnection conn = new SqlConnection())
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
                        park.OperatingHours = reader["OperatingHours"].ToString();
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
            decimal occupancyRate = 0;
            using (SqlConnection conn = new SqlConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT (occupied/free * 100) AS occupancyrate " +
                                  "FROM (SELECT COUNT(*) as occupied FROM parkingspotsinfo WHERE UPPER(value) = 'OCCUPIED' AND parkinglotid = @idpark), " +
                                  "(SELECT COUNT(*) as free FROM parkingspotsinfo WHERE UPPER(value) = 'FREE' AND parkinglotid = @idpark);";
                cmd.Parameters.AddWithValue("@idpark", id);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = conn;

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        occupancyRate = Convert.ToDecimal(reader["occupancyrate"]);
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
