using Microsoft.AspNetCore.Authentication.JwtBearer;
using MicroserviceAralik.Services.Cargo.BusinessLayer.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = builder.Configuration["IdentityServerUrl"];
        options.Audience = "ResourceCargo";
        options.RequireHttpsMetadata = false;

    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CargoReadAccess", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "CargoReadPermission", "CargoFullPermission");
    });
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CargoFullAccess", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "CargoFullPermission");
    });
});

builder.Services.RegisterBusinessLayer();
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
