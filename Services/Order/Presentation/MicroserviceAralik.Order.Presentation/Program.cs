using MicroserviceAralik.Order.Persistence.Configurations;
using MicroserviceAralik.Order.Application.Services;
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

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

app.UseAuthorization();

app.MapControllers();

app.Run();
