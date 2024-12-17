using MicroserviceAralik.Image.Context;
using MicroserviceAralik.Image.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<AWSSettings>(builder.Configuration.GetSection(nameof(AWSSettings)));
builder.Services.AddDbContext<ImageContext>();
builder.Services.AddScoped<IFileUploder,FileUploder>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



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
