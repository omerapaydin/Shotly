using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shotly.Data.Abstract;
using Shotly.Data.Concrete.EfCore;
using Shotly.Entity;

namespace Shotly.Data.Concrete
{
    public class EfCommentRepository : ICommentRepository
    {
        private IdentityContext _context;

        public EfCommentRepository(IdentityContext context)
        {
            _context = context;
        }
        public IQueryable<Comment> Comments =>  _context.Comments;

        public void AddComment(Comment Comment)
        {
            _context.Comments.Add(Comment);
            _context.SaveChanges();
        }
    }
}