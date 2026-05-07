using Microsoft.AspNetCore.Http;
using SocialMediaCircleApp.Data.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMediaCircleApp.Data.Services
{
    public interface IFilesService
    {
        Task<string> UploadImageAsync(IFormFile file, ImageFileType imageFileType);
    }
}
