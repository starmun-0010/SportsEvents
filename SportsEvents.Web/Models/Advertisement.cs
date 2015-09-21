namespace SportsEvents.Web.Models
{
    public class Advertisement
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }
        public int Priority { get; set; }
        public string Keywords { get; set; }
        public bool Prelogin { get; set; }
    }
}