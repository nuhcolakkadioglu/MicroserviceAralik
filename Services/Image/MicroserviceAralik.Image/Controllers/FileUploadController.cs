using MicroserviceAralik.Image.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceAralik.Image.Controllers;
[Route("api/[controller]")]
[ApiController]
public class FileUploadController(IFileUploder _fileUploder) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post(IFormFile formFile)
    {
        var result = await _fileUploder.UploadFile(formFile);
        return Ok(result);
    }
}
