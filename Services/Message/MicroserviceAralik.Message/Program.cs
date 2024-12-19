using System.Reflection;
using MicroserviceAralik.Message.Dal.Context;
using MicroserviceAralik.Message.Mapping;
using MicroserviceAralik.Message.Services.MessageServices;
using MicroserviceAralik.Message.Services.RabbitMqServices;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddControllers();
 builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<RabbitMQPublisher>();
builder.Services.AddHostedService<RabbitMQConsumer>();

var app = builder.Build();

 if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
