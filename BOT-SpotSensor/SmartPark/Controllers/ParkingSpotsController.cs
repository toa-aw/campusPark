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
        public IEnumerable<ParkingSpot> GetAllParkingSpotsStatusForAGivenMoment(string parkId, string date)
        {
            List<ParkingSpot> spots = new List<ParkingSpot>();

            using (SqlConnection conn = new SqlConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * " +
                                  "FROM parkingspotsinfo s " +
                                  "JOINS parkinglots p ON s.parkinglotid=p.id" +
                                  "JOINS spotshistory h ON s.id=h.parkingspotid " +
                                  "WHERE p.name = @idpark AND h.date = @time";
                cmd.Parameters.AddWithValue("@idpark", parkId);
                cmd.Parameters.AddWithValue("@time", date);
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
                            Name = reader["Name"].ToString(),
                            Status = reader["Status"].ToString(),
                            BatteryStatus = (int)reader["BatteryStatus"],
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

        public IEnumerable<ParkingSpot> GetAllParkingSpotsStatusForAGivenTimePeriod(string parkId, string startDate, string endDate)
        {
            List<ParkingSpot> spots = new List<ParkingSpot>();

            using (SqlConnection conn = new SqlConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * " +
                                  "FROM parkingspotsinfo s " +
                                  "JOINS parkinglots p ON s.parkinglotid=p.id" +
                                  "JOINS spotshistory h ON s.id=h.parkingspotid " +
                                  "WHERE p.name = @idpark AND h.date BETWEEN @startdate AND @enddate";
                cmd.Parameters.AddWithValue("@idpark", parkId);
                cmd.Parameters.AddWithValue("@startdate", startDate);
                cmd.Parameters.AddWithValue("@enddate", endDate);
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
                            Name = reader["Name"].ToString(),
                            Status = reader["Status"].ToString(),
                            BatteryStatus = (int)reader["BatteryStatus"],
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

        public IEnumerable<ParkingSpot> GetFreeSpotsFromAParkInAGivenMoment(string parkId, string date)
        {
            List<ParkingSpot> spots = new List<ParkingSpot>();

            using (SqlConnection conn = new SqlConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * " +
                                  "FROM parkingspotsinfo s " +
                                  "JOINS parkinglots p ON s.parkinglotid=p.id" +
                                  "JOINS spotshistory h ON s.id=h.parkingspotid " +
                                  "WHERE p.name = @idpark AND UPPER(s.status) = 'FREE' AND h.date = @time";
                cmd.Parameters.AddWithValue("@idpark", parkId);
                cmd.Parameters.AddWithValue("@time", date);
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
                            Name = reader["Name"].ToString(),
                            Status = reader["Status"].ToString(),
                            BatteryStatus = (int)reader["BatteryStatus"],
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
                            Id = (int)reader["Id"],
                            Name = reader["Name"].ToString(),
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

        public IHttpActionResult GetSpotInfoForAGivenMoment(string spotId, string date)
        {
            ParkingSpot spot = new ParkingSpot();
            using (SqlConnection conn = new SqlConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * " +
                                  "FROM parkingspotinfo s " +
                                  "JOINS spotshistory h ON s.id = h.parkingspotid " +
                                  "WHERE s.id = @idspot AND h.date = @time";
                cmd.Parameters.AddWithValue("@idspot", spotId);
                cmd.Parameters.AddWithValue("@time", date);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = conn;

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        spot.Id = (int)reader["Id"];
                        spot.Name = reader["Name"].ToString();
                        spot.Location = reader["Location"].ToString();
                        spot.Status = reader["Status"].ToString();
                        spot.Timestamp = reader["LastUpdated"].ToString();
                        spot.BatteryStatus = (int)reader["BatteryStatus"];
                        reader.Close();
                        return Ok(spot);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return NotFound();
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
                            Id = (int)reader["Id"],
                            Name = reader["Name"].ToString(),
                            BatteryStatus  = (int)reader["BatteryStatus"],
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

        public IEnumerable<ParkingSpot> GetParkingSpotsToBeReplacedInASpecificPark(string id)
        {
            List<ParkingSpot> spots = new List<ParkingSpot>();

            using (SqlConnection conn = new SqlConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM parkingspotsinfo WHERE batterystatus = 1 AND parkinglotid = @parkId";
                cmd.Parameters.AddWithValue("@parkId", id);
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
                            Id = (int)reader["Id"],
                            Name = reader["Name"].ToString(),
                            BatteryStatus = (int)reader["BatteryStatus"],
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
    }
}
