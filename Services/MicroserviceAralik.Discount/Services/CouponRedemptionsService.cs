namespace MicroserviceAralik.Discount.Services;

using System.Threading.Tasks;
using AutoMapper;
using Grpc.Core;
using MicroserviceAralik.Discount.Entities;
using MicroserviceAralik.Discount.Protos;
using MicroserviceAralik.Discount.Services.CouponRedemptionServices;
using Microsoft.AspNetCore.Authorization;
using DiscountCouponRedemptionsServicess = MicroserviceAralik.Discount.Protos.CouponRedemptionService;

[Authorize]
public class CouponRedemptionsService(IDiscountCouponRedemptionService _discountCouponRedemptionService, IMapper _mapper) : DiscountCouponRedemptionsServicess.CouponRedemptionServiceBase
{


    public override async Task<GetCouponRedemptionResponse> CreateRedemption(CreateRedemptionRequest request, ServerCallContext context)
    {
        CouponRedemption create = _mapper.Map<CouponRedemption>(request.Redemption);

        CouponRedemption add = await _discountCouponRedemptionService.CreateCouponRedemption(create);

        GetCouponRedemptionResponse mapValue = _mapper.Map<GetCouponRedemptionResponse>(add);

        return mapValue;
    }



    public override async Task<DeleteRedemptionResponse> DeleteRedemption(DeleteRedemptionRequest request, ServerCallContext context)
    {
        bool dell = await _discountCouponRedemptionService.DeleteCouponRedemption(request.Id);

        return new DeleteRedemptionResponse { IsDeleted = dell };
    }


    public override async Task<GetCouponRedemptionResponses> GetAllRedemptions(EmptyRedemption request, ServerCallContext context)
    {
        List<CouponRedemption> data = await _discountCouponRedemptionService.GetAllCouponRedemption();

        List<GetCouponRedemptionResponse> mapData = _mapper.Map<List<GetCouponRedemptionResponse>>(data);

        return new GetCouponRedemptionResponses { Redemptions = { mapData } };
    }



    public override async Task<GetCouponRedemptionResponse> GetCouponRedemptionById(GetCouponRedemptionByIdRequest request, ServerCallContext context)
    {
        CouponRedemption data = await _discountCouponRedemptionService.GetCouponRedemptionById(request.Id);

        GetCouponRedemptionResponse map = _mapper.Map<GetCouponRedemptionResponse>(data);

        return map;

    }


    public override async Task<GetCouponRedemptionResponse> UpdateRedemption(UpdateRedemptionRequest request, ServerCallContext context)
    {
        CouponRedemption mapdata = _mapper.Map<CouponRedemption>(request.Redemption);
        CouponRedemption up = await _discountCouponRedemptionService.UpdateCouponRedemption(mapdata);

        GetCouponRedemptionResponse mapReturn = _mapper.Map<GetCouponRedemptionResponse>(up);
        return mapReturn;

    }
}
