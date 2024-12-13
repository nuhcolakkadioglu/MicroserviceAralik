using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceAralik.Services.Cargo.DtoLayer.Dtos.CompayDtos;
public class CreateCompanyDto
{
    public string Name { get; set; }
}
public class UpdateCompanyDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}
