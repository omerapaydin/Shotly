using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shotly.Data.Abstract;
using Shotly.Entity;
using Shotly.ViewModel;

namespace Shotly.Components
{
    public class YourProfile:ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private IPostRepository _postRepository;

        public YourProfile(UserManager<ApplicationUser> userManager,IPostRepository postRepository)
        {
            _userManager = userManager;
            _postRepository = postRepository;
            
        }
        public async Task<IViewComponentResult> InvokeAsync()
    {
        var userId = _userManager.GetUserId(HttpContext.User);
        var posts = await _postRepository.Posts
            .Include(p => p.User)
            .Where(p => p.UserId == userId)
            .OrderByDescending(p => p.PublishedOn)
            .Take(6)
            .ToListAsync();

        var user = posts.FirstOrDefault()?.User;

        var viewModel = new UserProfileViewModel
        {
            User = user,
            Posts = posts
        };

        return View(viewModel);
    }
        }
    }