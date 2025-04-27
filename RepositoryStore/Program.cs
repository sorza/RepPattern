using Microsoft.EntityFrameworkCore;
using RepositoryStore.Data;
using RepositoryStore.Models;
using RepositoryStore.Repositories;
using RepositoryStore.Repositories.Abstractions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IProductRepository, ProductRepository>();

var app = builder.Build();


app.MapGet("/v1/products", async (IProductRepository repository, CancellationToken token) 
    => Results.Ok(await repository.GetAllAsync()));

app.MapGet("/v1/products/{id}", async (IProductRepository repository, CancellationToken token, int id) 
    =>Results.Ok(await repository.GetByIdAsync(id)));

app.MapPost("/v1/products", async (IProductRepository repository, CancellationToken token, Product product) 
    => Results.Ok(await repository.CreateAsync(product, token)));

app.MapPut("/v1/products", async (IProductRepository repository, CancellationToken token, Product product) 
    => Results.Ok(await repository.UpdateAsync(product, token)));

app.MapDelete("/v1/products/{id}", async (IProductRepository repository, CancellationToken token, int id) =>
{
    var product = await repository.GetByIdAsync(id, token);
    if (product is null) return Results.NotFound();
    return Results.Ok(await repository.DeleteAsync(product, token));
});
   

app.Run();
