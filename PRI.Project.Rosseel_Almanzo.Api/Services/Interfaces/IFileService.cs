namespace PRI.Project.Rosseel_Almanzo.Api.Services.Interfaces
{
    public interface IFileService
    {
        Task<string> StoreFile<T>(IFormFile file);
        bool DeleteFile<T>(string filename);
    }
}
