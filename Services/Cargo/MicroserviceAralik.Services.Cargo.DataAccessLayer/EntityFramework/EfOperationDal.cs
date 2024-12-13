using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroserviceAralik.Services.Cargo.DataAccessLayer.Abstract;
using MicroserviceAralik.Services.Cargo.DataAccessLayer.Concrete;
using MicroserviceAralik.Services.Cargo.DataAccessLayer.Repositories;
using MicroserviceAralik.Services.Cargo.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceAralik.Services.Cargo.DataAccessLayer.EntityFramework;
public class EfOperationDal : GenericRepository<Operation>, IOperationDal
{
    public EfOperationDal(AppDbContext context) : base(context)
    {
    }

    public Task<List<Operation>> GetOperationByBarcodeNumber(string barcode)
     => _context.Operations.Where(m => m.Barcode == barcode).ToListAsync();
}
