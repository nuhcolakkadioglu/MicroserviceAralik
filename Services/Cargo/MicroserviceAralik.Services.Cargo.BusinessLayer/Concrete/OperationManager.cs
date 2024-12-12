using MicroserviceAralik.Services.Cargo.BusinessLayer.Abstract;
using MicroserviceAralik.Services.Cargo.DataAccessLayer.Abstract;
using MicroserviceAralik.Services.Cargo.EntityLayer.Concrete;

namespace MicroserviceAralik.Services.Cargo.BusinessLayer.Concrete;
public class OperationManager : GenericManager<Operation>, IOperationService
{

    private readonly IOperationDal _operationDal;
    public OperationManager(IGenericDal<Operation> genericDal, IOperationDal operationDal) : base(genericDal)
    {
        _operationDal = operationDal;
    }

    public async Task<List<Operation>> GetOperationByBarcodeNumber(string barcode)
    {
        return await _operationDal.GetOperationByBarcodeNumber(barcode);
    }
}
