using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrySimpleApi.Domain.Author.Entities;

namespace TrySimpleApi.Domain.Product.Entities
{
    public partial class ProductEntity
    {
        [Key]
        public string Id { get; set; }
        [Required(ErrorMessage = "field name harus di isi")]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [Required(ErrorMessage = "Author Id Harus Di isi")]
        public Guid? AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        [Display(Name = "Author")]
        public AuthorEntity Author { get; set; }

    }
}
