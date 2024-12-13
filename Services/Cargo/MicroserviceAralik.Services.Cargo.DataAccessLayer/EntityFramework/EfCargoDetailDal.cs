using MicroserviceAralik.Services.Cargo.DataAccessLayer.Abstract;
using MicroserviceAralik.Services.Cargo.DataAccessLayer.Concrete;
using MicroserviceAralik.Services.Cargo.DataAccessLayer.Repositories;
using MicroserviceAralik.Services.Cargo.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceAralik.Services.Cargo.DataAccessLayer.EntityFramework;
public class EfCargoDetailDal : GenericRepository<CargoDetail>, ICargoDetailDal
{
    public EfCargoDetailDal(AppDbContext context) : base(context)
    {
    }

    public async Task<List<CargoDetail>> GetReceivedCargoDetailByCustomerId(int customerId)
          => await _context.CargoDetails
            .Where(m => m.ReceiverCustomerId == customerId)
            .ToListAsync();

    public async Task<List<CargoDetail>> GetSendCargoDetailsByCustomerId(int customerId)
          => await _context.CargoDetails
             .Where(m => m.SenderCustomerId == customerId)
             .ToListAsync();
}
