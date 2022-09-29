using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAPI.Logging
{
    public class AboutModel : PageModel
    {
        private readonly ILogger _logger;
        public AboutModel(ILogger<AboutModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
            _logger.LogInformation("Bilgi Sayafası {DT}",
                DateTime.UtcNow.ToLongTimeString());
        }
    }
}
