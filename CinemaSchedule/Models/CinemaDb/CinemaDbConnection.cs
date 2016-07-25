using CinemaSchedule.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CinemaSchedule.Models
{
    public class CinemaDbConnection : ICinemaDbConnection
    {
        private readonly string _connectionString;

        public CinemaDbConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            var conn = new SqlConnection(_connectionString);
            conn.Open();
            return conn;
        }
    }
}