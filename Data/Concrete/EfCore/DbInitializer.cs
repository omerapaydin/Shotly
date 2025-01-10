using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Shotly.Entity;

namespace Shotly.Data.Concrete.EfCore
{
    public static class DbInitializer
    {
        public static void Seed(IdentityContext context)
        {
            // Veritabanını oluştur (eğer mevcut değilse)
            context.Database.EnsureCreated();

            // Eğer daha önce veri eklenmişse işlemi sonlandır
            if (context.Posts.Any() || context.Comments.Any())
                return;

            // Kullanıcılar oluştur
            var users = new[]
            {
                new ApplicationUser { UserName = "john.doe", Email = "john.doe@example.com", FullName = "John Doe", ImageFile = "p1.jpg" },
                new ApplicationUser { UserName = "jane.doe", Email = "jane.doe@example.com", FullName = "Jane Doe", ImageFile = "p2.jpg" },
            };
            context.Users.AddRange(users);

            // Postlar oluştur
            var posts = new[]
            {
                new Post { Title = "First Post", Description = "This is the first post", Url = "first-post", Image = "1.jpg", PublishedOn = DateTime.Now, User = users[0] },
                new Post { Title = "Second Post", Description = "This is the second post", Url = "second-post", Image = "2.jpg", PublishedOn = DateTime.Now.AddMinutes(-30), User = users[1] },
            };
            context.Posts.AddRange(posts);

            // Yorumlar oluştur
            var comments = new[]
            {
                new Comment { Text = "Great post!", PublishedOn = DateTime.Now, User = users[1], Post = posts[0] },
                new Comment { Text = "Nice work!", PublishedOn = DateTime.Now.AddMinutes(-10), User = users[0], Post = posts[1] },
            };
            context.Comments.AddRange(comments);

            // Verileri kaydet
            context.SaveChanges();
        }
    }
}