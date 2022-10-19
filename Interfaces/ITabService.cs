using CloudinaryDotNet.Actions;

namespace ThirtyDaysOfShred.API.Interfaces
{
    public interface ITabService
    {
        Task<ImageUploadResult> AddFileAsync(IFormFile file);
        Task<DeletionResult> DeleteFileAsync(string publicId);
    }
}
