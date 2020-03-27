using System.Collections.Generic;
using TartineEtTech.Website.Models;

namespace TartineEtTech.Website.Repositories
{
    public class SpeakerRepository
    {
        private readonly DataProvider dataProvider;

        public SpeakerRepository(DataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }

        public IEnumerable<Speaker> GetSpeakers()
        {
            return dataProvider.Speakers;
        }
    }
}
