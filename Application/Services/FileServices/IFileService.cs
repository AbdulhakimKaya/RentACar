using Microsoft.AspNetCore.Http;

namespace Application.Services.FileServices;

public interface IFileService
{
    Task<string> UploadImage(IFormFile formFile);
}