using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroserviceAralik.Services.Cargo.DataAccessLayer.Abstract;
using MicroserviceAralik.Services.Cargo.DataAccessLayer.Concrete;
using MicroserviceAralik.Services.Cargo.DataAccessLayer.Repositories;
using MicroserviceAralik.Services.Cargo.EntityLayer.Concrete;

namespace MicroserviceAralik.Services.Cargo.DataAccessLayer.EntityFramework;
public class EfCustomerDal : GenericRepository<Customer>, ICustomerDal
{
    public EfCustomerDal(AppDbContext context) : base(context)
    {
    }
}
