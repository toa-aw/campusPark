using SmartPark.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace SmartPark.Controllers
{
    public class ParkingSpotsController : ApiController
    {
        string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["SmartPark.Properties.Settings.ConnStr"].ConnectionString;

        [Route("api/parkingSpots/park/{parkId:int}/{givenDate}/{givenTime}")]
        public IEnumerable<ParkingSpot> GetAllParkingSpotsStatusForAGivenMoment(int parkId, string givenDate, string givenTime)
        {
            List<ParkingSpot> spots = new List<ParkingSpot>();

            string[] dateParts = givenDate.Split('-');
            string[] timeParts = givenTime.Split('t');
            DateTime date = new DateTime(int.Parse(dateParts[2]), int.Parse(dateParts[1]), int.Parse(dateParts[0]), int.Parse(timeParts[0]), int.Parse(timeParts[1]), int.Parse(timeParts[2]));
            
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * " +
                                  "FROM parkingspotsinfo s " +
                                  "JOIN parkinglots p ON s.parkinglotid=p.id " +
                                  "JOIN spotshistory h ON s.id=h.parkingspotid " +
                                  "WHERE p.id = @idpark AND h.date = @time";
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
                            Id = (int)reader["Id"],
                            Name = reader["Name"].ToString(),
                            ParkingLotId = (int)reader["ParkingLotId"],
                            Location = reader["Location"].ToString(),
                            Status = reader["Status"].ToString(),
                            Timestamp = reader["LastUpdated"].ToString(),
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

        [Route("api/parkingSpots/park/{parkId:int}/{startDate}/{startTime}/{endDate}/{endTime}")]
        public IEnumerable<ParkingSpot> GetAllParkingSpotsStatusForAGivenTimePeriod(int parkId, string startDate, string startTime, string endDate, string endTime)
        {
            List<ParkingSpot> spots = new List<ParkingSpot>();

            string[] sDate = startDate.Split('-');
            string[] eDate = endDate.Split('-');
            string[] sTime = startTime.Split('t');
            string[] eTime = endTime.Split('t');
            DateTime dateS = new DateTime(int.Parse(sDate[2]), int.Parse(sDate[1]), int.Parse(sDate[0]), int.Parse(sTime[0]), int.Parse(sTime[1]), int.Parse(sTime[2]));
            DateTime dateE = new DateTime(int.Parse(eDate[2]), int.Parse(eDate[1]), int.Parse(eDate[0]), int.Parse(eTime[0]), int.Parse(eTime[1]), int.Parse(eTime[2]));


            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * " +
                                  "FROM parkingspotsinfo s " +
                                  "JOIN parkinglots p ON s.parkinglotid=p.id " +
                                  "JOIN spotshistory h ON s.id=h.parkingspotid " +
                                  "WHERE p.id = @idpark AND h.date BETWEEN @startdate AND @enddate";
                cmd.Parameters.AddWithValue("@idpark", parkId);
                cmd.Parameters.AddWithValue("@startdate", dateS);
                cmd.Parameters.AddWithValue("@enddate", dateE);
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
                            ParkingLotId = (int)reader["ParkingLotId"],
                            Location = reader["Location"].ToString(),
                            Status = reader["Status"].ToString(),
                            Timestamp = reader["LastUpdated"].ToString(),
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

        [Route("api/parkingSpots/park/{parkId:int}/free/{givenDate}/{givenTime}")]
        public IEnumerable<ParkingSpot> GetFreeSpotsFromAParkInAGivenMoment(int parkId, string givenDate, string givenTime)
        {
            List<ParkingSpot> spots = new List<ParkingSpot>();

            string[] dateParts = givenDate.Split('-');
            string[] timeParts = givenTime.Split('t');

            DateTime date = new DateTime(int.Parse(dateParts[2]), int.Parse(dateParts[1]), int.Parse(dateParts[0]), int.Parse(timeParts[0]), int.Parse(timeParts[1]), int.Parse(timeParts[2]));

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * " +
                                  "FROM parkingspotsinfo s " +
                                  "JOIN parkinglots p ON s.parkinglotid=p.id " +
                                  "JOIN spotshistory h ON s.id=h.parkingspotid " +
                                  "WHERE p.id = @idpark AND UPPER(s.status) = 'FREE' AND h.date = @time";
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
                            Id = (int)reader["Id"],
                            Name = reader["Name"].ToString(),
                            ParkingLotId = (int)reader["ParkingLotId"],
                            Location = reader["Location"].ToString(),
                            Status = reader["Status"].ToString(),
                            Timestamp = reader["LastUpdated"].ToString(),
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

        [Route("api/parkingSpots/park/{parkId:int}")]
        public IEnumerable<ParkingSpot> GetAllSpotsFromASpecificPark(int parkId)
        {
            List<ParkingSpot> spots = new List<ParkingSpot>();

            using (SqlConnection conn = new SqlConnection(strConn))
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
                            ParkingLotId = (int)reader["ParkingLotId"],
                            Location = reader["Location"].ToString(),
                            Status = reader["Status"].ToString(),
                            Timestamp = reader["LastUpdated"].ToString(),
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

        [Route("api/parkingSpots/{spotId:int}/{givenDate}")]
        public IHttpActionResult GetSpotInfoForAGivenMoment(int spotId, string givenDate)
        {
            ParkingSpot spot = new ParkingSpot();

            string[] dateParts = givenDate.Split('-');
            //string[] timeParts = givenTime.Split('t');

            DateTime date = new DateTime(int.Parse(dateParts[2]), int.Parse(dateParts[1]), int.Parse(dateParts[0]));

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * " +
                                  "FROM parkingspotsinfo s " +
                                  "JOIN spotshistory h ON s.id = h.parkingspotid " +
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
                        spot.ParkingLotId = (int)reader["ParkingLotId"];
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

        [Route("api/parkingSpots/replace")]
        public IEnumerable<ParkingSpot> GetParkingSpotsToBeReplaced()
        {
            List<ParkingSpot> spots = new List<ParkingSpot>();

            using (SqlConnection conn = new SqlConnection(strConn))
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
                            ParkingLotId = (int)reader["ParkingLotId"],
                            Location = reader["Location"].ToString(),
                            Status = reader["Status"].ToString(),
                            Timestamp = reader["LastUpdated"].ToString(),
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

        [Route("api/parkingSpots/park/{id:int}/replace")]
        public IEnumerable<ParkingSpot> GetParkingSpotsToBeReplacedInASpecificPark(int id)
        {
            List<ParkingSpot> spots = new List<ParkingSpot>();

            using (SqlConnection conn = new SqlConnection(strConn))
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
                            ParkingLotId = (int)reader["ParkingLotId"],
                            Location = reader["Location"].ToString(),
                            Status = reader["Status"].ToString(),
                            Timestamp = reader["LastUpdated"].ToString(),
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
