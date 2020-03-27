using System;
using System.Collections.Generic;

namespace TartineEtTech.Website.Models
{
    public class Session
    {

        public Session()
        {
            Speakers = new List<Speaker>();
        }

        public string Title { get; internal set; }
        public string VideosUrl { get; internal set; }
        public IList<Speaker> Speakers { get; internal set; }
        public DateTime PublicationDate { get; internal set; }
        public string EmbeddedUrl { get; internal set; }
        public string Description { get; internal set; }
    }
}
