using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shotly.Data.Abstract;

namespace Shotly.Controllers
{
    public class HomeController:Controller
    {
        private IPostRepository _postRepository;
        public HomeController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _postRepository.Posts.ToListAsync());
        }
    }
}