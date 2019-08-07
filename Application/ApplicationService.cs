using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrySimpleApi.Helpers;

namespace TrySimpleApi.Application
{
    public class ApplicationService
    {
        protected readonly ProductContext _context;

        public ApplicationService(ProductContext context)
        {
            _context = context;
        }
    }
}
