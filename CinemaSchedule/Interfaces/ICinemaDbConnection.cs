using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CinemaSchedule.Interfaces
{
    public interface ICinemaDbConnection
    {
        IDbConnection CreateConnection();
    }
}