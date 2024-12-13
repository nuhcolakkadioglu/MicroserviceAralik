using MicroserviceAralik.Discount.Context;
using MicroserviceAralik.Discount.Mappings;
using MicroserviceAralik.Discount.Services;
using MicroserviceAralik.Discount.Services.CouponRedemptionServices;
using MicroserviceAralik.Discount.Services.CouponService;
using Microsoft.AspNetCore.Authentication.JwtBearer;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = builder.Configuration["IdentityServerUrl"];
        options.Audience = "ResourceDiscount";
        options.RequireHttpsMetadata = false;

    });


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("DiscountReadAccess", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "DiscountReadPermission", "DiscountFullPermission");
    });
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("DiscountFullAccess", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "DiscountFullPermission");
    });
});


builder.Services.AddScoped<IDiscountCouponService, DiscountCouponService>();
builder.Services.AddScoped<IDiscountCouponRedemptionService, DiscountCouponRedemptionService>();
builder.Services.AddAutoMapper(typeof(GeneralMapping));
builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddGrpc();

WebApplication app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapGrpcService<CouponsService>();
app.MapGrpcService<CouponRedemptionsService>();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");


app.Run();
