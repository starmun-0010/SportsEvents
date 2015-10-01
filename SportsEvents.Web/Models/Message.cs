using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsEvents.Web.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string SenderId { get; set; }
        [ForeignKey("SenderId")]
        public ApplicationUser Sender { get; set; }
        public string ReceiverId { get; set; }
        [ForeignKey("ReceiverId")]
        public ApplicationUser Receiver { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }
    }
}