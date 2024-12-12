namespace MicroserviceAralik.Discount.Services;

using System.Threading.Tasks;
using AutoMapper;
using Grpc.Core;
using MicroserviceAralik.Discount.Entities;
using MicroserviceAralik.Discount.Protos;
using MicroserviceAralik.Discount.Services.CouponService;
using Microsoft.AspNetCore.Authorization;
using CouponServicesss = MicroserviceAralik.Discount.Protos.CouponService;

[Authorize]
public class CouponsService(IDiscountCouponService _discountCouponService, IMapper _mapper) : CouponServicesss.CouponServiceBase
{
    public override async Task<GetCouponResponse> CreateCoupon(CreateCouponRequest request, ServerCallContext context)
    {
        Coupon coupon = _mapper.Map<Coupon>(request.Coupon);
        Coupon result = await _discountCouponService.CreateCoupon(coupon);
        GetCouponResponse mappdValue = _mapper.Map<GetCouponResponse>(result);
        return mappdValue;
    }

    public override async Task<DeleteCouponResponse> DeleteCoupon(DeleteCouponRequest request, ServerCallContext context)
    {
        bool result = await _discountCouponService.DeleteCoupon(request.Id);

        return new DeleteCouponResponse
        {
            IsDeleted = result
        };
    }

    public override async Task<GetCouponResponses> GetAllCoupons(EmptyCoupon request, ServerCallContext context)
    {
        List<Coupon> values = await _discountCouponService.GetAllCoupons();
        List<GetCouponResponse> mapValues = _mapper.Map<List<GetCouponResponse>>(values);

        return new GetCouponResponses
        {
            Coupons = { mapValues! }
        };
    }

    public override async Task<GetCouponResponse> GetCouponById(GetCouponByIdRequest request, ServerCallContext context)
    {
        Coupon values = await _discountCouponService.GetCouponById(request.Id);
        GetCouponResponse mapValues = _mapper.Map<GetCouponResponse>(values);

        return mapValues;


    }

    public override async Task<GetCouponResponse> UpdateCoupon(UpdateCouponRequest request, ServerCallContext context)
    {
        Coupon mapValues = _mapper.Map<Coupon>(request.Coupon);

        Coupon values = await _discountCouponService.UpdateCoupon(mapValues);
        GetCouponResponse result = _mapper.Map<GetCouponResponse>(values);

        return result;
    }
}
