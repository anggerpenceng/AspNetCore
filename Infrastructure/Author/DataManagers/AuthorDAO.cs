using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrySimpleApi.Domain.Author.ViewModels;
using TrySimpleApi.Domain.Author.Entities;
using TrySimpleApi.Domain.Product.ViewModels;
using TrySimpleApi.Infrastructure.Author.Repositories;
using TrySimpleApi.Helpers;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using TrySimpleApi.Domain.Product.Entities;
using TrySimpleApi.Domain.Author.Factories;

namespace TrySimpleApi.Infrastructure.Author.DataManagers
{
    public class AuthorDAO : IAuthorRepositories
    {

        private readonly ProductContext _context;

        public AuthorDAO(ProductContext context)
        {
            _context = context;
        }

        public ICollection<AuthorDetailViewModel> Index()
        {
            return _context.AuthorEntities.Include(a => a.Products)
                .Select(a => new AuthorDetailViewModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Position = a.Position,
                    CreatedAt = a.CreatedAt,
                    UpdatedAt = a.UpdatedAt
                })
                .ToList();

        }

        public AuthorDetailViewModel Show(Guid id)
        {
            var author = _context.AuthorEntities
                .Include(a => a.Products)
                .SingleOrDefault(a => a.Id == id);

            ICollection<ProductDetailViewModel> products = new List<ProductDetailViewModel>();

            return AuthorFactory.Make(author);

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
