using MicroserviceAralik.Image.Context;
using MicroserviceAralik.Image.Dtos.BrandImageDto;
using MicroserviceAralik.Image.Entities;
using MicroserviceAralik.Image.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceAralik.Image.Controllers;
[Route("api/[controller]")]
[Authorize]
[ApiController]
public class BrandImagesController(IFileUploder _fileUploder, ImageContext _context) : ControllerBase
{
    [HttpPost]
    [Authorize(Policy = "ImageFullAccess")]
    public async Task<IActionResult> UploadBrandes(CreateBrandImageDto model)
    {
        string? result = await _fileUploder.UploadFile(model.ImageFile);
        if (result is not null)
        {
            BrandImage Brande = new BrandImage
            {
                ImageUrl = result,
                BrandId = model.BrandId,
            };

            _context.Add(Brande);
            await _context.SaveChangesAsync();
            return Ok("Created");
        }


        return BadRequest("Hataa");

    }

    [HttpGet]
    [Authorize(Policy = "ImageReadAccess")]
    public async Task<IActionResult> GetAllBrandes()
    {

        return Ok(await _context.BrandImages.ToListAsync());


    }
    [HttpGet("GetBrandeId")]
    [Authorize(Policy = "ImageReadAccess")]

    public async Task<IActionResult> GetBrandeId(string productId)
    {

        return Ok(await _context.BrandImages.FirstOrDefaultAsync(m => m.BrandId == productId));


    }
}
