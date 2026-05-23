using FinPay.API;
using FinPay.Application;
using FinPay.Infrastructure;

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

app.Run();