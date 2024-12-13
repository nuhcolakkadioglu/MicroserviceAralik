using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceAralik.Services.Cargo.DtoLayer.Dtos.OperationDtos;
public class CreateOperationDto
{
    public string Barcode { get; set; }
    public string Description { get; set; }
    public DateTime OperationTime { get; set; }
}

public class UpdateOperationDto
{
    public int Id { get; set; }
    public string Barcode { get; set; }
    public string Description { get; set; }
    public DateTime OperationTime { get; set; }
}