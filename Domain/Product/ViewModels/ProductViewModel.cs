using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrySimpleApi.Domain.Author.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TrySimpleApi.Domain.Product.ViewModels
{
    public class ProductViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey("AuthorId")]
        public AuthorViewModel Author { get; set; }
    }
}
