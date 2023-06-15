using System;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public partial class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Image { get; set; }
        public int? Status { get; set; }
        public string? Link { get; set; }
        public int? CateId { get; set; }
    }
}
