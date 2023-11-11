using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ThaiBoost.Models;
using Newtonsoft.Json;

namespace ThaiBoost.Pages.Campaigns
{
    public class CampaignsModel : PageModel
    {
        public IEnumerable<Campaign> CampaignsList { get; set; }

        public void OnGet()
        {
            var jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "data_source.json");
            var json = System.IO.File.ReadAllText(jsonPath);
            var campaignList = JsonConvert.DeserializeObject<RootObject>(json);

            CampaignsList = campaignList.data;
        }
    }
}
