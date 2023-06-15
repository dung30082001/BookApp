using System;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public partial class Review
    {
        public int ReviewId { get; set; }
        public int? UserId { get; set; }
        public string Information { get; set; }
        public int? BookId { get; set; }
    }
}
