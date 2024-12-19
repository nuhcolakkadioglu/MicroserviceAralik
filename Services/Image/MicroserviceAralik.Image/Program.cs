using MicroserviceAralik.Image.Context;
using MicroserviceAralik.Image.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = builder.Configuration["IdentityServerUrl"];
        options.Audience = "ResourceImage";
        options.RequireHttpsMetadata = false;


    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ImageReadAccess", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "ImageReadPermission", "ImageFullPermission");
    });
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ImageFullAccess", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "ImageFullPermission");
    });
});


builder.Services.Configure<AWSSettings>(builder.Configuration.GetSection(nameof(AWSSettings)));
builder.Services.AddDbContext<ImageContext>();
builder.Services.AddScoped<IFileUploder, FileUploder>();

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
