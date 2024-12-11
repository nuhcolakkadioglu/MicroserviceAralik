using MicroserviceAralik.Discount.Context;
using MicroserviceAralik.Discount.Mappings;
using MicroserviceAralik.Discount.Services;
using MicroserviceAralik.Discount.Services.CouponRedemptionServices;
using MicroserviceAralik.Discount.Services.CouponService;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IDiscountCouponService, DiscountCouponService>();
builder.Services.AddScoped<IDiscountCouponRedemptionService, DiscountCouponRedemptionService>();
builder.Services.AddAutoMapper(typeof(GeneralMapping));
builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddGrpc();

WebApplication app = builder.Build();

app.MapGrpcService<CouponsService>();
app.MapGrpcService<CouponRedemptionsService>();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");


app.Run();
