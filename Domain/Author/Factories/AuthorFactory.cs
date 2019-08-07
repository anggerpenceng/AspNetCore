using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrySimpleApi.Domain.Author.Entities;
using TrySimpleApi.Domain.Author.ViewModels;
using TrySimpleApi.Domain.Product.Entities;
using TrySimpleApi.Domain.Product.ViewModels;

namespace TrySimpleApi.Domain.Author.Factories
{
    public class AuthorFactory
    {

        public static AuthorDetailViewModel Make(AuthorEntity author)
        {
            ICollection<ProductDetailViewModel> products = new List<ProductDetailViewModel>();

            foreach (ProductEntity viewModel in author.Products)
            {
                products.Add(ProductMapper(viewModel));
            }

            return new AuthorDetailViewModel()
            {
                Id = author.Id,
                Name = author.Name,
                Position = author.Position,
                CreatedAt = author.CreatedAt,
                UpdatedAt = author.UpdatedAt,
                Products = products
            };
        }

        private static ProductDetailViewModel ProductMapper(ProductEntity entity)
        {
            return new ProductDetailViewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };

        }

    }
}
