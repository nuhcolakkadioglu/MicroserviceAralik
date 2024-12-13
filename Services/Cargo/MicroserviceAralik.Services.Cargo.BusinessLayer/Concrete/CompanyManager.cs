using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroserviceAralik.Services.Cargo.BusinessLayer.Abstract;
using MicroserviceAralik.Services.Cargo.DataAccessLayer.Abstract;
using MicroserviceAralik.Services.Cargo.EntityLayer.Concrete;

namespace MicroserviceAralik.Services.Cargo.BusinessLayer.Concrete;
public class CompanyManager : GenericManager<Company>, ICompanyService
{
    public CompanyManager(IGenericDal<Company> genericDal) : base(genericDal)
    {
    }
}
