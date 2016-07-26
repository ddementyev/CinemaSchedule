using CinemaSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CinemaSchedule.Interfaces
{
    public interface ICinemaService
    {
        void EditSession(Session session, ActionType action);
        List<IGrouping<string, Sessions>> GetSessions(DateTime date);
        CinemaCatalog GetCatalog();
        bool CheckSession(Session session);
    }
}