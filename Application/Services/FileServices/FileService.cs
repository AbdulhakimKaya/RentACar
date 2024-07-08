using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Application.Services.FileServices;

public class FileService : IFileService
{
    
    private readonly Cloudinary _cloudinary;
    private readonly Account _account;
    private readonly CloudinarySettings _cloudinarySettings;
    
    public FileService(IOptions<CloudinarySettings> cloudOptions)
    {
        _cloudinarySettings = cloudOptions.Value;
        _account = new Account(_cloudinarySettings.CloudName,_cloudinarySettings.ApiKey,_cloudinarySettings.ApiSecret);

        _cloudinary = new Cloudinary(_account);
        _cloudinary.Api.Client.Timeout = TimeSpan.FromMinutes(30);

    }

    public async Task<string> UploadImage(IFormFile file)
    {
        var uploadResult = new ImageUploadResult();
        if (file.Length > 0)
        {
            using var stream = file.OpenReadStream();
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName,stream),
                Folder = "rent-a-car-slider"
            };

            uploadResult = await _cloudinary.UploadAsync(uploadParams);
            string imageUrl = _cloudinary.Api.UrlImgUp.BuildUrl(uploadResult.PublicId);
            // string imageUrl = cloudinary.Api.UrlVideoUp.BuildUrl(uploadResult.PublicId);
            return imageUrl;
        }
        return "";
    }
}