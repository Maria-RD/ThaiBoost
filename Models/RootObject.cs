using System.Net.NetworkInformation;

namespace ThaiBoost.Models
{
    public class RootObject
    {
        public List<Campaign> data { get; set; }
        public Paging paging { get; set; }
    }
}
