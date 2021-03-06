﻿using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using TartineEtTech.Website.Models;
using TartineEtTech.Website.Repositories;

namespace TartineEtTech.Website.Pages
{
    public class SpeakersModel : PageModel
    {
        private readonly SpeakerRepository speakerRepository;

        public SpeakersModel(SpeakerRepository speakerRepository)
        {
            this.speakerRepository = speakerRepository;
        }

        public void OnGet()
        {

        }

        public IEnumerable<Speaker> Speakers
            => speakerRepository.GetSpeakers()
                                .OrderBy(c => c.Firstname)
                                .ThenBy(c => c.Lastname);
    }
}