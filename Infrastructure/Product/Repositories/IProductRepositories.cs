using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrySimpleApi.Domain.Product.ViewModels;

namespace TrySimpleApi.Infrastructure.Product.DataManagers
{
    public interface IProductRepositories
    {
        List<ProductViewModel> Index();
    }
}
