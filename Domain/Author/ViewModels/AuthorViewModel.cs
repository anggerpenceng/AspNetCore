using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrySimpleApi.Domain.Author.ViewModels
{
    public class AuthorViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Position { get; set; }

    }
}
