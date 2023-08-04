using Microsoft.EntityFrameworkCore;
using MusicShopDataAccessLayer;
using MusicShopDataAccessLayer.Repositories;
using MusicShopDataAccessLayer.UnitOfWorks;
using MusicShopEntities.IUnitOfWork;
using MusicShopEntities.Repositories;
using MusicShopEntities.Services;
using MusicShopService.Mappings;
using MusicShopService.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddScoped(typeof(ICustomerService), typeof(CustomerService));
builder.Services.AddScoped(typeof(ICustomerRepository),typeof(CustomerRepo));
builder.Services.AddAutoMapper(typeof(MapProfile));


builder.Services.AddDbContext<AppDBContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("AppDBContext"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDBContext)).GetName().Name);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
