﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.EntityLayer.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String? ImageUrl { get; set; }
    }
}
  
