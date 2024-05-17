using MediatR;
using Microsoft.EntityFrameworkCore;
using Note.API.Core.Automapper;
using ShopkeeperProject.Data;
using ShopkeeperProject.Interfaces;
using ShopkeeperProject.Repository;
using ShopkeeperProject.Services.Interfaces;
using ShopkeeperProject.Services.Providers;





var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//Db Connection
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite("Data Source=Shopkeeper.db")) ;








// Service Repositories
 builder.Services.AddScoped<ICustomerRepository,CustomerRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

//Repositories
 builder.Services.AddScoped<ICustomerRepository,CustomerRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

//Controllers configuration
builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(AutomapperConfigProfile));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();
app.Run();

