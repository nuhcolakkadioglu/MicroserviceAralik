 
namespace MicroserviceAralik.Image.Services;

public interface IFileUploder
{

    Task<string> UploadFile(IFormFile formFile);
}
