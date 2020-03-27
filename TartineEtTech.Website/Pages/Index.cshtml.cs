using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using TartineEtTech.Website.Models;
using TartineEtTech.Website.Repositories;

namespace TartineEtTech.Website.Pages
{
    public class IndexModel : PageModel
    {
        private readonly SessionRepository sessionRepository;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(
            SessionRepository sessionRepository,
            ILogger<IndexModel> logger)
        {
            this.sessionRepository = sessionRepository;
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public IEnumerable<Session> SessionsToDisplay 
            => sessionRepository.GetSessions().Take(2);
    }
}
