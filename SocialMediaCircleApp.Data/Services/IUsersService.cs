using SocialMediaCircleApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace SocialMediaCircleApp.Data.Services
{
    public interface IUsersService
    {
        Task<User> GetUser(int loggedInUserId);
        Task UpdateUserProfilePicture(int loggedInUserId, string profilePictureUrl);
        Task<List<Post>> GetUserPosts(int userId);
    }
}
