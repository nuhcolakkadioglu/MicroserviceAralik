using MicroserviceAralik.Services.Cargo.BusinessLayer.Abstract;
using MicroserviceAralik.Services.Cargo.DataAccessLayer.Abstract;
using MicroserviceAralik.Services.Cargo.EntityLayer.Concrete;

namespace MicroserviceAralik.Services.Cargo.BusinessLayer.Concrete;
public class CustomerManager : GenericManager<Customer>, ICustomerService
{
    public CustomerManager(IGenericDal<Customer> genericDal) : base(genericDal)
    {
    }
}
