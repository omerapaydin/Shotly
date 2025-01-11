using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shotly.Entity;

namespace Shotly.Data.Abstract
{
    public interface ICommentRepository
    {
        IQueryable<Comment> Comments {get;}

        void AddComment(Comment Comment);
    }
}