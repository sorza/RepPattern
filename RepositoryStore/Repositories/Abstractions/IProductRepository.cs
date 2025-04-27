﻿using RepositoryStore.Models;

namespace RepositoryStore.Repositories.Abstractions
{
    public interface IProductRepository
    {
        Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default);
        Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken = default);
        Task<Product> DeleteAsync(Product product, CancellationToken cancellationToken = default);
        Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<List<Product>?> GetAllAsync(int skip = 0, int take = 25, CancellationToken cancellationToken = default);
    }
}
