using MicroserviceAralik.Order.Application.Services;
using MicroserviceAralik.Order.Persistence.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = builder.Configuration["IdentityServerUrl"];
        options.Audience = "ResourceOrder";
        options.RequireHttpsMetadata = false;

    });


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("OrderReadAccess", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "OrderReadPermission", "OrderFullPermission");
    });
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("OrderFullAccess", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "OrderFullPermission");
    });
});


builder.Services.AddGenericServices();
builder.Services.AddMediator();
builder.Services.AddAutoMapper();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
