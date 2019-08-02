using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrySimpleApi.Domain.Product.Entities;
using TrySimpleApi.Infrastructure.Product.Interfaces;
using TrySimpleApi.Helpers;


namespace TrySimpleApi.Infrastructure.Product.Repositories
{
    public class ProductRepositories : IProductRepositories
    {

        private readonly ProductContext _context;

        public ProductRepositories(ProductContext context)
        {
            _context = context;
        }

        public List<ProductModel> Index()
        {
            return _context.ProductModel.ToList();
        }
    }
}
