using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using TartineEtTech.Website.Models;
using TartineEtTech.Website.Repositories;

namespace TartineEtTech.Website.Pages
{
    public class VideosModel : PageModel
    {
        private readonly SessionRepository sessionRepository;

        public VideosModel(
            SessionRepository sessionRepository)
        {
            this.sessionRepository = sessionRepository;
        }

        public void OnGet()
        {

        }

        public IEnumerable<Session> Sessions 
            => sessionRepository.GetSessions().OrderByDescending(c => c.PublicationDate);
    }
}