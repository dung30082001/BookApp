﻿using System;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public int? Role { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? FullName { get; set; }
    }
}
