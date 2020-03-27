using System.Collections.Generic;
using TartineEtTech.Website.Models;

namespace TartineEtTech.Website.Repositories
{
    public class SessionRepository
    {
        private readonly DataProvider dataProvider;

        public SessionRepository(DataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }

        public IEnumerable<Session> GetSessions()
        {
            return dataProvider.Sessions;
        }
    }
}
