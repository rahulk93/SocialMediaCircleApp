using SocialMediaCircleApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMediaCircleApp.Data.Dtos;

namespace SocialMediaCircleApp.Data.Services
{
    public interface IFriendsService
    {
        Task SendRequestAsync(int senderId, int receiverId);
        Task UpdateRequestAsync(int requestId, string status);
        Task RemoveFriendAsync(int frienshipId);
        Task<List<UserWithFriendsCountDto>> GetSuggestedFriendsAsync(int userId);

        Task<List<FriendRequest>> GetSentFriendRequestAsync(int userId);
        Task<List<FriendRequest>> GetReceivedFriendRequestAsync(int userId);
        Task<List<Friendship>> GetFriendsAsync(int userId);
    }
}
