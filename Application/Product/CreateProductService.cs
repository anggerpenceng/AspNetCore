using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrySimpleApi.Domain.Product.Entities;
using TrySimpleApi.Helpers;

namespace TrySimpleApi.Application.Product
{
    public class CreateProductService : IProductService
    {

        private readonly ProductContext _context;
        private static Random random = new Random();

        public CreateProductService(ProductContext context)
        {
            _context = context;
        }

        public async Task<object> Create(ProductModel model)
        {

            try
            {
                model.Id = RandomString(20);
                model.CreatedAt = DateTime.Now;
                _context.Add(model);
                await _context.SaveChangesAsync();
                return new { status = true, message = "Success create data"};
            }
            catch(Exception err)
            {
                return new { status = false, message = err.Message };
            }

        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
