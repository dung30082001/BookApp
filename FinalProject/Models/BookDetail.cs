using System;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public partial class BookDetail
    {
        public int Id { get; set; }
        public int? BookId { get; set; }
        public string? Author { get; set; }
        public string? Detail { get; set; }
        public string? Image { get; set; }
    }
}
