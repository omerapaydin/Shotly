using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shotly.Data.Abstract;
using Shotly.Entity;
using Shotly.Models;

namespace Shotly.Controllers
{
    public class HomeController:Controller
    {
        private UserManager<ApplicationUser> _userManager;

        private IPostRepository _postRepository;
        private ICommentRepository _commentRepository;
        public HomeController(IPostRepository postRepository,UserManager<ApplicationUser> userManager,ICommentRepository commentRepository)
        {
            _postRepository = postRepository;
            _userManager = userManager;
            _commentRepository = commentRepository;

        }
        public async Task<IActionResult> Index()
        {
            return View(await _postRepository.Posts.Include(p=>p.User).OrderByDescending(p=>p.PublishedOn).Take(5).ToListAsync());
        }
         [Authorize]

         public async Task<IActionResult> CreatePost()
        {
            return View();
        }
        [HttpPost]
         [Authorize]

         public async Task<IActionResult> CreatePost(PostViewModel model,IFormFile imageFile)
        {
             
             var extension = "";

            if (imageFile != null)
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
                extension = Path.GetExtension(imageFile.FileName);

                if (!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("", "Geçerli bir resim seçiniz");
                    return View(model);
                }
            }
                else
                {
                    ModelState.AddModelError("", "Lütfen bir resim dosyası seçiniz");
                    return View(model); 
                }


                  if (ModelState.IsValid)
            
            {
                var randomFileName = $"{Guid.NewGuid()}{extension}";
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);
                  using (var stream = new FileStream(path, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }


                if (User.Identity!.IsAuthenticated)
            {
                // Kullanıcı giriş yapmış
                var userId = _userManager.GetUserId(User);
               
               
               var post = new Post
                    {
                        Title = model.Title,
                        Description = model.Description,
                       
                        Image = randomFileName,
                        PublishedOn = DateTime.Now,
                        UserId = userId,
                       
                    };
                         

                _postRepository.AddPost(post);


                return RedirectToAction("Index","Home");
   
            }
            


            }

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            return View(await _postRepository.Posts.Include(p => p.User).Include(p => p.Comments).FirstOrDefaultAsync(p=>p.PostId==id));
        }
    
        [HttpPost]
        public async Task<IActionResult> AddComment(int postId, string content)
        {
             var userId = _userManager.GetUserId(User);
             

            var comment = new Comment
            {
                Text = content,
                PublishedOn = DateTime.Now,
                UserId = userId,
                PostId = postId
            };

            _commentRepository.AddComment(comment);

            return RedirectToAction("Details", new { id = postId });
        }
    
    }
}