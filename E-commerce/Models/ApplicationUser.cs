﻿using Microsoft.AspNetCore.Identity;

namespace E_commerce.Models
{
    public class ApplicationUser:IdentityUser

    {
        public string fullname { get; set; }
    }
}
