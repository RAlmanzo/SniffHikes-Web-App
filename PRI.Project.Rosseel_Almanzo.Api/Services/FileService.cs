using PRI.Project.Rosseel_Almanzo.Api.Services.Interfaces;

namespace PRI.Project.Rosseel_Almanzo.Api.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<FileService> _logger;

        public FileService(IWebHostEnvironment webHostEnvironment, ILogger<FileService> logger)
        {
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }

        public bool DeleteFile<T>(string filename)
        {
            if (filename == null)
            {
                return false;
            }
            //rebuild image path
            var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", nameof(T), filename);
            //delete the image
            try
            {
                File.Delete(imagePath);
            }
            catch (FileNotFoundException fileNotFoundException)
            {
                _logger.LogError(fileNotFoundException.Message);
                return false;
            }
            return true;
        }

        public async Task<string> StoreFile<T>(IFormFile file)
        {
            //unique filename
            var filename = $"{Guid.NewGuid()}_{file.FileName}";
            //filepath
            var pathToImages = Path.Combine(_webHostEnvironment.WebRootPath, "images", nameof(T));

            if (!Directory.Exists(pathToImages))
            {
                Directory.CreateDirectory(pathToImages);
            }
            //create path to file
            var pathToFile = Path.Combine(pathToImages, filename);
            //copy to location
            using (FileStream filestream = new FileStream(pathToFile, FileMode.Create))
            {
                try
                {
                    await file.CopyToAsync(filestream);
                }
                catch (FileNotFoundException fileNotFoundException)
                {
                    //log the error
                    _logger.LogError(fileNotFoundException.Message);
                    //Response.StatusCode = 500;
                    return "";
                }
            }
            return filename;
        }
    }
}
