using Entity.DTOs;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Diagnostics;

namespace Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepo userRepo;
        private readonly ITokenService tokenService;
        public HomeController(IUserRepo userRepo, ITokenService tokenService)
        {
            this.userRepo = userRepo;
            this.tokenService = tokenService;
        }
        public IActionResult Index()
        {
            var token = Request.Cookies["token"];
            if (tokenService.IsTokenValid(token)) {
                return Redirect("/courses");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginDto loginDto)
        {
            var user = await userRepo.GetUser(loginDto.Email, loginDto.Password);   
            if (user == null) {
                ModelState.AddModelError("", "Invalid username or password.");
                return  View();
            }
            var token = tokenService.CreateToken(user);
            Response.Cookies.Append("token", token);
            return Redirect("/courses");
        }
        [HttpGet("/register")]
        public IActionResult Register()
        {
            var token = Request.Cookies["token"];
            if (tokenService.IsTokenValid(token))
            {
                return Redirect("/courses");
            }
            return View();
        }

        [HttpPost("/register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (ModelState.IsValid)
            {
                var user = await userRepo.AddUser(registerDto);
                var token = tokenService.CreateToken(user);
                Response.Cookies.Append("token", token);
                return Redirect("/courses");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
