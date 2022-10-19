﻿using CloudinaryDotNet.Actions;
using ThirtyDaysOfShred.API.Interfaces;
using CloudinaryDotNet;
using Microsoft.Extensions.Options;
using ThirtyDaysOfShred.API.Helpers;

namespace ThirtyDaysOfShred.API.Services
{
    public class TabService : ITabService
    {
        private readonly Cloudinary _cloudinary;
        public TabService(IOptions<CloudinarySettings> config)
        {
            var acc = new Account
                (
                    config.Value.CloudName,
                    config.Value.ApiKey,
                    config.Value.ApiSecret
                );

            _cloudinary = new Cloudinary(acc);
        }
        public async Task<ImageUploadResult> AddFileAsync(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream)
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);

            }
            return uploadResult;
        }

        public async Task<DeletionResult> DeleteFileAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);

            var result = await _cloudinary.DestroyAsync(deleteParams);

            return result;
        }
    }
}
