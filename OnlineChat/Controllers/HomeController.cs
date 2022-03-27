using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineChat.Models;
using OnlineChat.ViewModels;
using Services;
using System.Diagnostics;
using System.Security.Claims;

namespace OnlineChat.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<Users> _userManager;
        private readonly UsersService _usersService;
        private readonly MessagesService _messagesService;

        public HomeController(ILogger<HomeController> logger, UserManager<Users> userManager, UsersService services, UsersService usersService, MessagesService messagesService)
        {
            _logger = logger;
            _userManager = userManager;
            _usersService = usersService;
            _messagesService = messagesService;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            List<Users> users = _usersService.GetAll();
            HomeViewModel homeViewModel = new()
            {
                UserId = userId,
                users = users
            };
            return View(homeViewModel);
        }

        public List<Message> GetMyMessages(string otherId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _messagesService.GetMyMessages(userId, otherId);
        }


        public IActionResult Privacy()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}