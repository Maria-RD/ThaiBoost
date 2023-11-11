using ThaiBoost.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ThaiBoost.Controllers
{
    public class CampaignsController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CampaignsController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "data_source.json");
            var json = System.IO.File.ReadAllText(jsonPath);
            var campaignList = JsonConvert.DeserializeObject<RootObject>(json);            

            return View(campaignList.data);
        }

        public IActionResult Details(string id)
        {
            var jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "data_source.json");
            var json = System.IO.File.ReadAllText(jsonPath);
            var rootObject = JsonConvert.DeserializeObject<RootObject>(json);

            var campaign = rootObject.data.Find(c => c.Id == id);

            if (campaign == null)
            {
                return NotFound();
            }

            return View("~/Pages/Campaigns/Details.cshtml", campaign);
        }

        [ValidateAntiForgeryToken]
        public IActionResult SaveDetails(Campaign campaign)
        {
            var json = System.IO.File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "data_source.json"));
            var rootObject = JsonConvert.DeserializeObject<RootObject>(json);

            var existingCampaign = rootObject.data.Find(c => c.Id == campaign.Id);
            if (existingCampaign != null)
            {
                existingCampaign.Name = campaign.Name;
                existingCampaign.Status = campaign.Status;
                existingCampaign.Objective = campaign.Objective;
                existingCampaign.Special_ad_category = campaign.Special_ad_category;
            }

            var updatedJson = JsonConvert.SerializeObject(rootObject);
            System.IO.File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "data_source.json"), updatedJson);

            return RedirectToAction("Index");
        }
    }
}
