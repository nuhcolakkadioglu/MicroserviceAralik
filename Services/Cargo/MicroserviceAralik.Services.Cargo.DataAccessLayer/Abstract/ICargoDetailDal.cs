using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroserviceAralik.Services.Cargo.EntityLayer.Concrete;

namespace MicroserviceAralik.Services.Cargo.DataAccessLayer.Abstract;
public interface ICargoDetailDal : IGenericDal<CargoDetail>
{
    Task<List<CargoDetail>> GetSendCargoDetailsByCustomerId(int customerId);
    Task<List<CargoDetail>> GetReceivedCargoDetailByCustomerId(int customerId);
}
