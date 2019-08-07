using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrySimpleApi.Domain.Product.Entities;
using TrySimpleApi.Infrastructure.Product.DataManagers;

namespace TrySimpleApi.Domain.Author.Entities
{
    public partial class AuthorEntity
    {

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Position { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<ProductEntity> Products { get; set; }
    }
}
