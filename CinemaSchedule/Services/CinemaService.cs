using CinemaSchedule.Interfaces;
using CinemaSchedule.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CinemaSchedule.Services
{
    public class CinemaService : ICinemaService
    {
        private readonly ICinemaDbConnection _dbConnection;
        private readonly CinemaDbModel _cinemaDb;

        public CinemaService(ICinemaDbConnection dbConnection, CinemaDbModel cinemaDb)
        {
            _dbConnection = dbConnection;
            _cinemaDb = cinemaDb;
        }

        public void EditSession(Session session, ActionType action)
        {
            var procedure = action == ActionType.AddSession ? "AddSession" : "DeleteSession";
            using (var dbConnection = _dbConnection.CreateConnection())
            {
                SqlCommand command = new SqlCommand(procedure, dbConnection as SqlConnection);
                command.CommandType = CommandType.StoredProcedure;

                var parameters = new List<SqlParameter>()
                 {
                     new SqlParameter("@theater", SqlDbType.VarChar) { Value = session.Theater },
                     new SqlParameter("@movie", SqlDbType.VarChar) { Value = session.Movie },
                     new SqlParameter("@date", SqlDbType.DateTime) { Value = DateTime.Parse(session.Date) },
                     new SqlParameter("@time", SqlDbType.Timestamp) { Value = TimeSpan.Parse(session.Time) }
                 };

                command.Parameters.AddRange(parameters.ToArray());
                command.ExecuteNonQuery();
            }
        }

        public List<IGrouping<string, Sessions>> GetSessions(DateTime date)
        {
            return _cinemaDb.Sessions.Where(d => d.Date == date).GroupBy(t => t.Theater).ToList();
        }

        public CinemaCatalog GetCatalog()
        {
            return new CinemaCatalog()
            {
                Theaters = _cinemaDb.Theaters.ToList(),
                Movies = _cinemaDb.Movies.ToList(),
            };
        }

        public bool CheckSession(Session session)
        {
            var sessions = _cinemaDb.Sessions.Where(s => s.Theater == session.Theater && s.Movie == session.Movie && s.Date.ToString() == session.Date).Select(t => t.Time).ToList();
            return sessions.Contains(TimeSpan.Parse(session.Time)) ? true : false;
        }
    }
}