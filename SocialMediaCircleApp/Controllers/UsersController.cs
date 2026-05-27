using Microsoft.AspNetCore.Mvc;
using SocialMediaCircleApp.Controllers.Base;
using SocialMediaCircleApp.Data.Services;
using SocialMediaCircleApp.Data.Models;
using SocialMediaCircleApp.ViewModels.Users;
using Microsoft.AspNetCore.Identity;

namespace SocialMediaCircleApp.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUsersService _userService;
        private readonly UserManager<User> _userManager;
        public UsersController(IUsersService usersService, UserManager<User> userManager)
        {
            _userService = usersService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Details(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var userPosts = await _userService.GetUserPosts(userId);

            var userProfileVM = new GetUserProfileVM()
            {
                User = user,
                Posts = userPosts
            };

            return View(userProfileVM);

        }
    }
}
