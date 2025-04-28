using BaltaStore.Domain.Abstractions;
using BaltaStore.Domain.Entities;
using System.Linq.Expressions;

namespace BaltaStore.Domain.Specifications.Products
{
    public class GetProductByIdSpecification(Guid id) : Specification<Product>
    {       
        public override Expression<Func<Product, bool>> ToExpression()
            => product => product.Id == id;
    }
}
