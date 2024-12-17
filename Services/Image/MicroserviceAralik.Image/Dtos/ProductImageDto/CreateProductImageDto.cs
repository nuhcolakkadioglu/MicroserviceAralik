namespace MicroserviceAralik.Image.Dtos.ProductImageDto;

public class CreateProductImageDto
{
    public IFormFile ImageFile { get; set; }
    public string ProductId { get; set; }

}

public class UpdateProductImageDto
{
    public int Id { get; set; }
    public string ProductId { get; set; }
    public string ImageUrl { get; set; }

}