using System.Data;

namespace CinemaSchedule.Interfaces
{
    public interface ICinemaDbConnection
    {
        IDbConnection CreateConnection();
    }
}