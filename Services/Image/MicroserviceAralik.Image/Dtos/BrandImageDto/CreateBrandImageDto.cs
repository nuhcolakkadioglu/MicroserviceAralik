namespace MicroserviceAralik.Image.Dtos.BrandImageDto;

public class CreateBrandImageDto
{
    public IFormFile ImageFile { get; set; }
    public string BrandId { get; set; }
}
public class UpdateBrandImageDto
{
    public int Id { get; set; }
    public string BrandId { get; set; }
    public string ImageUrl { get; set; }
}