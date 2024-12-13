using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroserviceAralik.Services.Cargo.BusinessLayer.Abstract;
using MicroserviceAralik.Services.Cargo.DataAccessLayer.Abstract;
using MicroserviceAralik.Services.Cargo.EntityLayer.Concrete;

namespace MicroserviceAralik.Services.Cargo.BusinessLayer.Concrete;
public class CargoDetailManager : GenericManager<CargoDetail>, ICargoDetailService
{
    private readonly ICargoDetailDal cargoDetailDal;
    public CargoDetailManager(IGenericDal<CargoDetail> _genericDal, ICargoDetailDal cargoDetailDal) : base(_genericDal)
    {
        this.cargoDetailDal = cargoDetailDal;
    }

    public async Task<List<CargoDetail>> GetReceivedCargoDetailByCustomerId(int customerId)
    {
        return await cargoDetailDal.GetReceivedCargoDetailByCustomerId(customerId);
    }

    public async Task<List<CargoDetail>> GetSendCargoDetailsByCustomerId(int customerId)
    {
        return await cargoDetailDal.GetSendCargoDetailsByCustomerId(customerId);
    }
}
