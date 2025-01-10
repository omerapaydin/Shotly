using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shotly.Entity
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string? Text { get; set; }
        public DateTime PublishedOn { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;
         public int PostId { get; set; }
        public Post Post { get; set; } = null!;

    }
}