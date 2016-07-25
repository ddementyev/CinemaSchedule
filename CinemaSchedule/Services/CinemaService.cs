using CinemaSchedule.Interfaces;
using CinemaSchedule.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CinemaSchedule.Services
{
    public class CinemaService : ICinemaService
    {
        private readonly ICinemaDbConnection _dbConnection;

        public CinemaService(ICinemaDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void EditSession(Session session, ActionType action)
        {
            var procedure = action == ActionType.AddSession ? "AddSession" : "DeleteSession";
            using (var dbConnection = _dbConnection.CreateConnection())
            {
                SqlCommand command = new SqlCommand(procedure, dbConnection as SqlConnection);        
                command.CommandType = CommandType.StoredProcedure;

                var prms = new List<SqlParameter>()
                 {
                     new SqlParameter("@theater", SqlDbType.VarChar) {Value = session.Theater},
                     new SqlParameter("@movie", SqlDbType.VarChar) {Value = session.Movie},
                     new SqlParameter("@date", SqlDbType.Date) {Value = session.Date},
                     new SqlParameter("@time", SqlDbType.Time) {Value = session.Time}
                 };

                command.Parameters.AddRange(prms.ToArray());
                command.ExecuteNonQuery();
            }
        }    
    }
}