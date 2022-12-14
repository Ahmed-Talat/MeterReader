using MeterReader;
using MeterReader.Repos;
using MeterReader.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ReadingContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
});

builder.Services.AddGrpc(opt => opt.EnableDetailedErrors = true);
builder.Services.AddGrpcReflection();

builder.Services.AddScoped<IReadingRepository, ReadingRepository>();

var app = builder.Build();

app.MapGrpcService<MeterReadingService>();
app.MapGrpcReflectionService();

app.Run();