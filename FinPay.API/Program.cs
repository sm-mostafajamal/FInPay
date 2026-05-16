using FinPay.API;
using FinPay.Application;
using FinPay.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentation()
                .AddApplication()
                .AddInfrastructure();
                
var app = builder.Build();

app.MapControllers();
app.UseHttpsRedirection();

app.Run();