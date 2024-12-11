using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using MicroserviceAralik.Discount.Entities;
using MicroserviceAralik.Discount.Protos;

namespace MicroserviceAralik.Discount.Mappings;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<Coupon, GetCouponResponse>().ReverseMap();
        CreateMap<Coupon, UpdateCouponRequest>().ReverseMap();
        CreateMap<CouponRedemption, GetCouponRedemptionResponse>().ReverseMap();

        CreateMap<Timestamp, DateTime>().ConvertUsing(t => t == null ? default : t.ToDateTime());
        CreateMap<DateTime, Timestamp>().ConvertUsing(t => Timestamp.FromDateTime(t.ToUniversalTime()));
    }
}
