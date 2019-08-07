using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrySimpleApi.Domain.Author.ViewModels;
using TrySimpleApi.Domain.Author.Entities;


namespace TrySimpleApi.Infrastructure.Author.Repositories
{
    public interface IAuthorRepositories
    {
        ICollection<AuthorDetailViewModel> Index();

        AuthorDetailViewModel Show(Guid id);
    }
}
