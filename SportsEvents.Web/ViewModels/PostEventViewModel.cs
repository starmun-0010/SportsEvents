using System.Collections;
using System.Collections.Generic;
using SportsEvents.Web.Models;

namespace SportsEvents.Web.ViewModels
{
    public class PostEventViewModel
    {
        public List<Sport> Sports { get; set; }
        public int SportId { get; set; }
    }
}