using CarRent.Api.Extensions;
using CarRent.Application.Extensions;
using CarRent.Common.Extensions;
using CarRent.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Host
    .AddConfiguration();

builder.Services
    .AddAuthorization()
    .AddControllers().Services
    .AddDatabase()
    .AddApplicationServices()
    .AddInfrastructureServices()
    .AddMapping()
    .AddIdentityServices()
    .AddEndpointsApiExplorer()
    .AddMvc().Services
    .AddSwaggerGen()
    .AddApiVersion()
    .AddCORS();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseCors("CorsPolicy");

app.Run();
