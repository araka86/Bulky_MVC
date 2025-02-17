﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Models
{
    public class AplicationUser: IdentityUser
    {
        [Required]
        public string Name { get; set; }

        public string? StreetAdress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PastalCode { get; set; }
        public string StreetAddress { get; set; }
    }
}
