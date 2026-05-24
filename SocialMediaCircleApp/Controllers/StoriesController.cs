using Microsoft.AspNetCore.Mvc;
using SocialMediaCircleApp.Controllers.Base;
using SocialMediaCircleApp.Data.Models;
using SocialMediaCircleApp.Data.Services;
using SocialMediaCircleApp.ViewModels.Home;
using SocialMediaCircleApp.ViewModels.Stories;
using Microsoft.AspNetCore.Authorization;
using SocialMediaCircleApp.Data.Helpers.Enums;

namespace SocialMediaCircleApp.Controllers
{
    [Authorize]
    public class StoriesController : BaseController
    {
        private readonly IStoriesService _storiesService;
        private readonly IFilesService _filesService;
        public StoriesController(IStoriesService storiesService,
            IFilesService filesService)
        {
            _storiesService = storiesService;
            _filesService = filesService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStory(StoryVM storyVM)
        {
            var loggedInUserId = GetUserId();
            if (loggedInUserId == null) return RedirectToLogin();

            var imageUploadPath = await _filesService.UploadImageAsync(storyVM.Image, ImageFileType.StoryImage);

            var newStory = new Story
            {
                DateCreated = DateTime.UtcNow,
                IsDeleted = false,
                ImageUrl = imageUploadPath,
                UserId = loggedInUserId.Value
            };

            await _storiesService.CreateStoryAsync(newStory);

            return RedirectToAction("Index", "Home");
        }
    }
}
