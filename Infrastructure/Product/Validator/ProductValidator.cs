using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using TrySimpleApi.Domain.Product.Entities;

namespace TrySimpleApi.Infrastructure.Product.Validator
{
    public class ProductValidator : AbstractValidator<ProductModel>
    {
        
        public ProductValidator()
        {
            
        }

    }
}
