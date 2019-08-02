using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TrySimpleApi.Domain.Product.Entities
{
    public partial class ProductModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "field name harus di isi")]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
