using System;

namespace SportsEvents.Web.Models
{
    public class Message
    {
        public int Id { get; set; }
        public ApplicationUser Sender { get; set; }
        public ApplicationUser Receiver { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }
    }
}