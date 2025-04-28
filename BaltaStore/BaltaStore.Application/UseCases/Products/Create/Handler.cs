using BaltaStore.Domain.Abstractions;
using BaltaStore.Domain.Entities;
using BaltaStore.Domain.Repositories;
using MediatR;

namespace BaltaStore.Application.UseCases.Products.Create
{
    public class Handler(IProductRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<Command, Result<Response>>
    {
        public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Title = request.title
            };

            await repository.CreateAsync(product, cancellationToken);
            await unitOfWork.CommitAsync();

            return new Response("Product created successfully.");
        }    
    }
}
