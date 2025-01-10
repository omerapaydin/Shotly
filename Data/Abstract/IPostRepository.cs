using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shotly.Entity;

namespace Shotly.Data.Abstract
{
    public interface IPostRepository
    {
        IQueryable<Post> Posts {get;}

        void AddPost(Post post);
    }
}