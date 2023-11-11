namespace ThaiBoost.Models
{
    public class Campaign
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Objective { get; set; }
        public List<string>? Special_ad_categories { get; set; }
        public string? Special_ad_category { get; set; }
    }
}
