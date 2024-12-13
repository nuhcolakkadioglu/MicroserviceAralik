using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceAralik.Services.Cargo.DtoLayer.Dtos.CargoDetailDtos;
public class CreateCargoDetailDto
{

    public int SenderCustomerId { get; set; }
    public int ReceiverCustomerId { get; set; }
    public string Barcode { get; set; }
    public int CompanyId { get; set; }
}
public class UpdateCargoDetailDto
{
    public int Id { get; set; }
    public int SenderCustomerId { get; set; }
    public int ReceiverCustomerId { get; set; }
    public string Barcode { get; set; }
    public int CompanyId { get; set; }
}