using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shotly.Entity
{
    public class Post
    {
        public int PostId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Url { get; set; }
        public string? Image { get; set; }
        public DateTime PublishedOn { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;
        public List<Comment> Comments { get; set; } = new List<Comment>();

    }
}