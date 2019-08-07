using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrySimpleApi.Domain.Product.ViewModels;
using TrySimpleApi.Domain.Author.ViewModels;
using TrySimpleApi.Helpers;
using Microsoft.EntityFrameworkCore;


namespace TrySimpleApi.Infrastructure.Product.DataManagers
{
    public class ProductDAO : IProductRepositories
    {

        private readonly ProductContext _context;

        public ProductDAO(ProductContext context)
        {
            _context = context;
        }

        public List<ProductViewModel> Index()
        {
            return _context.ProductEntities
                .Include(p => p.Author)
                .Select(p =>
            new ProductViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                CreatedAt = p.CreatedAt,
                Description = p.Description,
                Author = new AuthorViewModel()
                {
                    Id = p.Author.Id,
                    Name = p.Author.Name,
                    Position = p.Author.Position
                }
            }).ToList();

        }
    }
}
