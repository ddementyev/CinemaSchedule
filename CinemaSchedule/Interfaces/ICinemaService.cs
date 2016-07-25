using CinemaSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaSchedule.Interfaces
{
    public interface ICinemaService
    {
        void EditSession(Session session, ActionType action);
    }
}