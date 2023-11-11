using ThaiBoost.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace ThaiBoost.Pages.Campaigns
{
    public class DetailsModel : PageModel
    {
        public Campaign CampaignDetail { get; set; }
        public void OnGet()
        {

        }
    }
}
