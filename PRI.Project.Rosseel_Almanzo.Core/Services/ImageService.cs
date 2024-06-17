using PRI.Project.Rosseel_Almanzo.Core.Entities;
using PRI.Project.Rosseel_Almanzo.Core.Interfaces.Repositories;
using PRI.Project.Rosseel_Almanzo.Core.Interfaces.Services;
using PRI.Project.Rosseel_Almanzo.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Image = PRI.Project.Rosseel_Almanzo.Core.Entities.Image;

namespace PRI.Project.Rosseel_Almanzo.Core.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;
        public ImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<ResultModel<Image>> DeleteImageAsync(int id)
        {
            //get the image
            var image = await _imageRepository.GetByIdAsync(id);
            //check if image excist in db
            if (image == null)
            {
                return new ResultModel<Image>
                {
                    Success = false,
                    Errors = new List<string> { "Image does not exist!" }
                };
            }

            var result = await _imageRepository.DeleteAsync(image);
            if (result)
            {
                return new ResultModel<Image> { Success = true };
            }

            return new ResultModel<Image>
            {
                Success = false,
                Errors = new List<string> { "Image not deleted!" }
            };
        }

        public async Task<ResultModel<Image>> GetByIdAsync(int id)
        {
            //get the image
            var image = await _imageRepository.GetByIdAsync(id);
            //create new resultmodel
            var imageResultModel = new ResultModel<Image>();
            //check if exists
            if (image == null)
            {
                imageResultModel.Success = false;
                imageResultModel.Errors = new List<string> { "No image found" };
                return imageResultModel;
            }

            //if image exists
            imageResultModel.Success = true;
            imageResultModel.Value = image;
            return imageResultModel;
        }
    }
}
