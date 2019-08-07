using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrySimpleApi.Domain.Author.Entities;


namespace TrySimpleApi.Infrastructure.Author.Repositories
{
    public interface IAuthorService<T>
    {
        Task<object> Create(T model);
        Task<object> Update(T model);
    }
}
