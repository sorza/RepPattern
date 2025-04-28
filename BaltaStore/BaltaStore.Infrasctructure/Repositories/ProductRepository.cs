using BaltaStore.Domain.Abstractions;
using BaltaStore.Domain.Entities;
using BaltaStore.Domain.Repositories;
using BaltaStore.Infrasctructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BaltaStore.Infrasctructure.Repositories
{
    public class ProductRepository(AppDbContext context) : IProductRepository
    {
        public async Task<Product?> GetByIdAsync(Specification<Product> specification, CancellationToken cancellationToken = default)
         => await context.Products.Where(specification.ToExpression()).FirstOrDefaultAsync(cancellationToken);

        public async Task CreateAsync(Product product, CancellationToken cancellationToken = default)
         => await context.Products.AddAsync(product, cancellationToken);
        
    }
}
