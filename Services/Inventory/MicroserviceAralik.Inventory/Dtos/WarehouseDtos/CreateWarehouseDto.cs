using MicroserviceAralik.Inventory.Entities;

namespace MicroserviceAralik.Inventory.Dtos.WarehouseDtos;

public class CreateWarehouseDto
{

    public string Name { get; set; }
    public string Location { get; set; }

}
public class ResultWarehouseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
}
