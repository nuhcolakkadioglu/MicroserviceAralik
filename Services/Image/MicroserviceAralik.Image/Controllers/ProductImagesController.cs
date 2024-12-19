using MicroserviceAralik.Image.Context;
using MicroserviceAralik.Image.Dtos.ProductImageDto;
using MicroserviceAralik.Image.Entities;
using MicroserviceAralik.Image.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceAralik.Image.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ProductImagesController(IFileUploder _fileUploder, ImageContext _context) : ControllerBase
{
    [HttpPost]
    [Authorize(Policy = "ImageFullAccess")]
    public async Task<IActionResult> UploadProductImages(CreateProductImageDto model)
    {
        string? result = await _fileUploder.UploadFile(model.ImageFile);
        if (result is not null)
        {
            ProductImage productImage = new ProductImage
            {
                ImageUrl = result,
                ProductId = model.ProductId,
            };

            _context.Add(productImage);
            await _context.SaveChangesAsync();
            return Ok("Created");
        }


        return BadRequest("Hataa");

    }

    [HttpGet]
    [Authorize(Policy = "ImageReadAccess")]

    public async Task<IActionResult> GetAllProductImages()
    {

        return Ok(await _context.ProductImages.ToListAsync());


    }
    [HttpGet("GetProductImageId")]
    [Authorize(Policy = "ImageReadAccess")]

    public async Task<IActionResult> GetProductImageId(string productId)
    {

        return Ok(await _context.ProductImages.FirstOrDefaultAsync(m => m.ProductId == productId));


    }
}
