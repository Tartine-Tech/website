using System;
using System.Collections.Generic;
using TartineEtTech.Website.Models;

namespace TartineEtTech.Website.Repositories
{
    public class DataProvider
    {
        private Speaker _maudLevy => new Speaker
        {
            Firstname = "Maud",
            Lastname = "Levy",
            PictureUrl = "https://pbs.twimg.com/profile_images/1209222325998104576/fOiNQTzP_400x400.jpg",
            Title = "DevRel Program Manager",
            Company = "Microsoft",
            TwitterAccount = "https://twitter.com/maudstweets"
        };

        private Speaker _olivierLeplus = new Speaker
        {
            Firstname = "Oliver",
            Lastname = "Leplus",
            TwitterAccount = "https://twitter.com/olivierleplus",
            Company = "Microsoft",
            Title = "DevRel Program Manager",
            PictureUrl = "https://pbs.twimg.com/profile_images/459265225221353473/xilGJIvG_400x400.jpeg"
        };

        private Speaker _tiffanySouterre = new Speaker
        {
            Firstname = "Tiffany",
            Lastname = "Souterre",
            TwitterAccount = "https://twitter.com/TiffanySouterre",
            Company = "Data explorer",
            Title = "JEMS datafactory",
            PictureUrl = "https://pbs.twimg.com/profile_images/1058358980517478400/TsXyt1PY_400x400.jpg"
        };

        private Speaker _yohanLasorsa = new Speaker
        {
            Firstname = "Yohan",
            Lastname = "Lasorsa",
            TwitterAccount = "https://twitter.com/sinedied",
            Company = "Fullstack Developer & Clou",
            Title = "Microsoft",
            PictureUrl = "https://pbs.twimg.com/profile_images/1222835099009454080/NB3VheUm_400x400.jpg"
        };

        private Session _session3 = new Session
        {
            Title = "Le Deep Learning et les GAN",
            PublicationDate = new DateTime(2020, 02, 21),
            VideosUrl = "https://www.youtube.com/watch?v=UB-p3Xey4qE&",
            EmbeddedUrl = "https://www.youtube.com/embed/UB-p3Xey4qE",
            Description = "Dans cet épisode de Tartine & Tech, Tiffany nous explique les réseaux de neurones et les GAN (Generative Adversarial Networks). "
        };

        private Session _session2 = new Session
        {
            Title = "Github Actions",
            PublicationDate = new DateTime(2020, 02, 20),
            VideosUrl = "https://www.youtube.com/watch?v=UB-p3Xey4qE",
            EmbeddedUrl = "https://www.youtube.com/embed/UB-p3Xey4qE",
            Description = "Dans cet épisode de Tartine & Tech, Yohan nous présente les Github Actions. Découvrez comment ça marche et comment les utiliser."
        };

        private Session _session1 = new Session
        {
            Title = "Les certifications Azure",
            PublicationDate = new DateTime(2020, 02, 18),
            VideosUrl = "https://www.youtube.com/watch?v=3Dx3wU0gJi4",
            EmbeddedUrl = "https://www.youtube.com/embed/3Dx3wU0gJi4",
            Description = "Dans cet épisode de Tartine & Tech, Maud nous partage son expérience après avoir obtenu sa certification AZ-900 et donne quelques conseils pour se préparer à l'examen."
        };

        public DataProvider()
        {
            Speakers = new List<Speaker>
            {
                _maudLevy,
                _olivierLeplus,
                _tiffanySouterre,
                _yohanLasorsa
            };

            _session1.Speakers.Add(_maudLevy);
            _session1.Speakers.Add(_olivierLeplus);
            _session2.Speakers.Add(_yohanLasorsa);
            _session2.Speakers.Add(_olivierLeplus);
            _session3.Speakers.Add(_tiffanySouterre);
            _session3.Speakers.Add(_olivierLeplus);

            Sessions = new List<Session>
            {
                _session1,
                _session2,
                _session3
            };
        }

        public IList<Speaker> Speakers { get; set; }
        public IList<Session> Sessions { get; set; }


    }
}
