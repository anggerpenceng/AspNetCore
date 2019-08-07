using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrySimpleApi.Infrastructure.Author.Repositories;
using TrySimpleApi.Application;
using TrySimpleApi.Domain.Author.Entities;
using TrySimpleApi.Helpers;

namespace TrySimpleApi.Application.Author
{
    public class CreateAuthorService : ApplicationService, IAuthorService<AuthorEntity>
    {
        public CreateAuthorService(ProductContext context) : base(context) { }

        public async Task<object> Create(AuthorEntity model)
        {
            try
            {
                await _context.Database.BeginTransactionAsync();

                model.CreatedAt = DateTime.Now;
                _context.Add(model);
                await _context.SaveChangesAsync();

                _context.Database.CommitTransaction();

                return new { status = true, message = "Success create data" , data = model };
            }
            catch (Exception err)
            {
                return new { status = false, message = err.ToString() };
            }
        }

        public Task<object> Update(AuthorEntity model)
        {
            throw new NotImplementedException();
        }
    }
}
