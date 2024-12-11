using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceAralik.Services.Cargo.EntityLayer.Concrete;
public class Company
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<CargoDetail> CargoDetails { get; set; }
}
