using BusinessLogicLayer.IServices;
using BusinessLogicLayer.Services;
using DataAccessLayer.Data;
using DataAccessLayer.IRepasitories;
using DataAccessLayer.Repasitories;
using DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

#region Adding services to DI
builder.Services.AddTransient<IContactHistoryInterface, ContactHistoryRepasitory>();
builder.Services.AddTransient<ICustomerInterface, CustomerRepasitory>();
builder.Services.AddTransient<IOrderInterface, OrderRepasitory>();
builder.Services.AddTransient<IProductInterface, ProductRepasitory>();
builder.Services.AddTransient<ICategoryRepasitory, CategoryRrepasitory>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IContactHistoryService, ContactHistoryService>();
builder.Services.AddTransient<ICategorySerivice, CategoryService>();


#endregion

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(AutoMapperProfile)); // Automapper elon qilinga essambly 

#region swagger qo'shish 
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});
#endregion  

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger(); // swagger
    app.UseSwaggerUI(c => // swagger
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); // swagger
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
