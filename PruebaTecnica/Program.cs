using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using PruebaTecnica.Data;

using PruebaTecnica.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//Injections
builder.Services.AddScoped<ProductRepository>(provider => new ProductRepository(connectionString));
builder.Services.AddScoped<IProductService, ProductService>();

//FluentValidacion
builder.Services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());




builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mi API", Version = "v1" });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API V1");
    });
}
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();