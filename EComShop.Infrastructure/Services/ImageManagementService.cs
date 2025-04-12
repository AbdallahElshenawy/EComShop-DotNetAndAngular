﻿using EComShop.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComShop.Infrastructure.Services
{
    public class ImageManagementService(IFileProvider fileProvider) : IImageManagementService
    {
        public async Task<List<string>> AddImageAsync(IFormFileCollection files, string src)
        {
            var SaveImageSrc= new List<string>();
            var ImageDirectory = Path.Combine("wwwroot","Images", src);
            if (!Directory.Exists(ImageDirectory))
            {
                Directory.CreateDirectory(ImageDirectory);
            }
            foreach (var item in files)
            {
                if(item.Length>0)
                {
                    var ImageName = item.FileName;
                    var ImageSrc = $"Images/{src}/{ImageName}";
                    var root = Path.Combine(ImageDirectory, ImageName);
                    using (var fileStream = new FileStream(root, FileMode.Create))
                    {
                        await item.CopyToAsync(fileStream);
                    }
                    SaveImageSrc.Add(ImageSrc);
                }
            }
            return SaveImageSrc;
        }

        public void DeleteImageAsync(string src)
        {
            var info = fileProvider.GetFileInfo(src);
            var root = info.PhysicalPath;
            File.Delete(root);
        }
    }
}
