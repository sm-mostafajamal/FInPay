using FinApp.API;
using FinApp.Application;
using FinApp.Infrastructure;
using FinApp.Infrastructure.Seed;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentation()
                .AddApplication()
                .AddInfrastructure(builder.Configuration);
   
var app = builder.Build();

app.MapControllers();
app.UseHttpsRedirection();
app.UseExceptionHandler("/api/exception");
app.UseAuthentication();
app.UseAuthorization();
await app.Services.SuperAdminSeedAsync();

app.Run();