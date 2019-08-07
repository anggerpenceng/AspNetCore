using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrySimpleApi.Domain.Product.Entities;
using TrySimpleApi.Infrastructure.Product.DataManagers;
using TrySimpleApi.Helpers;

namespace TrySimpleApi.Application.Product
{
    public class CreateProductService : ApplicationService , IProductService
    {

        private static Random random = new Random();

        public CreateProductService(ProductContext context) : base(context) { }

        public async Task<object> Create(ProductEntity model)
        {

            try
            {
                model.Id = RandomString(20);
                model.CreatedAt = DateTime.Now;
                _context.Add(model);
                await _context.SaveChangesAsync();
                return new { status = true, message = "Success create data" , data = model };
            }
            catch(Exception err)
            {
                return new { status = false, message = err.ToString() };
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
