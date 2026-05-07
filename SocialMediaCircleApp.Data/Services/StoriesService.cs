using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SocialMediaCircleApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SocialMediaCircleApp.Data.Services
{
    public class StoriesService : IStoriesService
    {
        private readonly AppDbContext _context;
        public StoriesService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Story>> GetAllStoriesAsync()
        {
            var allStories = await _context.Stories
                .Where(n => n.DateCreated >= DateTime.UtcNow.AddHours(-24))
                .Include(s => s.User)
                .ToListAsync();

            return allStories;
        }

        public async Task<Story> CreateStoryAsync(Story story)
        {
            
            await _context.Stories.AddAsync(story);
            await _context.SaveChangesAsync();

            return story;
        }
    }
}
