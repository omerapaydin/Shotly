using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Shotly.Entity
{
    public class ApplicationUser:IdentityUser
    {
        public string? FullName { get; set; }
        public string? ImageFile { get; set; } 
        public List<Post> Posts { get; set; } = new List<Post>();
        public List<Comment> Comments { get; set; } = new List<Comment>();

    }
}