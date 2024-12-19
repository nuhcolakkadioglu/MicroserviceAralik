using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Polly;
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


builder.Services.AddAuthentication().AddJwtBearer("OcelotAuthenticationScheme", options =>
{
    options.Authority = builder.Configuration["IdentityServerUrl"];
    options.Audience = "ResourceOcelot";
    options.RequireHttpsMetadata = false;

});

builder.Configuration.AddJsonFile("ocelot.json");
builder.Services.AddOcelot().AddPolly();
WebApplication app = builder.Build();

app.MapGet("/", () => "Hello World!");

//app.UseAuthentication();
//app.UseAuthorization();
await app.UseOcelot();
app.Run();
