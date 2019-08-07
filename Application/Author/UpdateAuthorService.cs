using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrySimpleApi.Domain.Author.Entities;
using TrySimpleApi.Domain.Author.ViewModels;
using TrySimpleApi.Helpers;
using TrySimpleApi.Infrastructure.Author.Repositories;

namespace TrySimpleApi.Application.Author
{
    public class UpdateAuthorService : ApplicationService , IAuthorService<AuthorDetailViewModel>
    {

        public UpdateAuthorService(ProductContext context) : base(context) { }


        public async Task<object> Update(AuthorDetailViewModel model)
        {
            try
            {
                var author = _context.AuthorEntities.SingleOrDefault(a => a.Id == model.Id);

                author.Name = model.Name;
                author.Position = model.Position;
                author.UpdatedAt = DateTime.Now;
                _context.Update(author);
                await _context.SaveChangesAsync();

                return new { status = true, message = "Success update data", data = author };
                
            }
            catch (Exception exception)
            {
                return new { status = false, message = exception.ToString() };
            }
        }

        public Task<object> Create(AuthorDetailViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
