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
    public class ParkingSpotsController : ApiController
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
                            Id = reader["Id"].ToString(),
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

        public IEnumerable<ParkingSpot> GetAllSpotsFromASpecificPark(string parkId)
        {
            List<ParkingSpot> spots = new List<ParkingSpot>();

            using (SqlConnection conn = new SqlConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM parkingspotsinfo WHERE parkinglotid = @idpark";
                cmd.Parameters.AddWithValue("@idpark", parkId);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = conn;
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ParkingSpot spot = new ParkingSpot
                        {
                            Name = reader["name"].ToString(),
                        };
                        spots.Add(spot);
                    }
                    reader.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return spots;
        }

        public IEnumerable<ParkingSpot> GetParkingSpotsToBeReplaced()
        {
            List<ParkingSpot> spots = new List<ParkingSpot>();

            using (SqlConnection conn = new SqlConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM parkingspotsinfo WHERE batterystatus = 1", conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ParkingSpot spot = new ParkingSpot
                        {
                            Id = reader["Id"].ToString(),
                            Name = reader["name"].ToString(),
                        };
                        spots.Add(spot);
                    }
                    reader.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return spots;
        }

        [Route("api/parks/{id:string}")]
        public IHttpActionResult GetParkInformation(string id)
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
                        park.Id = reader["Id"].ToString();
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

        public IHttpActionResult GetParkOccupancyRate(string id)
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
