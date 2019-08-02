using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrySimpleApi.Domain.Product.Entities;


namespace TrySimpleApi.Application.Product
{
    public interface IProductService
    {
        Task<object> Create(ProductModel model);
    }
}
