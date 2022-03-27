using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineChat.ViewModels;

namespace OnlineChat.Controllers
{

    public class AuthController : Controller
    {
        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;


        public AuthController(UserManager<Users> userManager, SignInManager<Users> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {

          

            if (registerVM.Password == null)
            {
                return View();
            }
           

            Users user = new()
            {
                UserName = registerVM.Name,
                Name = registerVM.Name,
                Email = registerVM.Email,
            };

            
            IdentityResult result = await _userManager.CreateAsync(user, registerVM.Password);
            

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();

           
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

         [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            var user = await _userManager.FindByEmailAsync(loginVM.Email);
            if (user == null) return View();
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false,false);
            if (!result.Succeeded)
            {
                return RedirectToAction(nameof(Login));
            }

            return RedirectToAction("Index" , "Home");
        }


    }
}
