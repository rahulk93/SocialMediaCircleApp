using SocialMediaCircleApp.Data.Models;

namespace SocialMediaCircleApp.ViewModels.Users
{
    public class GetUserProfileVM
    {
        public User User { get; set; }
        public List<Post> Posts { get; set; }
    }
}
