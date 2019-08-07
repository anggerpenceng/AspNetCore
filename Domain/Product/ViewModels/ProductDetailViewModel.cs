using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrySimpleApi.Domain.Product.Entities;

namespace TrySimpleApi.Domain.Product.ViewModels
{
    public class ProductDetailViewModel
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
