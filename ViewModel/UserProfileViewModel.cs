using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shotly.Entity;

namespace Shotly.ViewModel
{
    public class UserProfileViewModel
    {
         public ApplicationUser User { get; set; } // Kullanıcı bilgileri
         public List<Post> Posts { get; set; } // Gönderiler
    }
}