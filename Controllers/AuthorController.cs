using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrySimpleApi.Infrastructure.Author.Repositories;
using TrySimpleApi.Infrastructure.Author.Repositories;
using TrySimpleApi.Application.Author;
using TrySimpleApi.Domain.Author.Entities;
using TrySimpleApi.Domain.Author.ViewModels;
using TrySimpleApi.Helpers;


namespace TrySimpleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : Controller
    {
        private readonly IResponseBuilder _helpers;
        private readonly IAuthorService<AuthorEntity> _createService;
        private readonly IAuthorService<AuthorDetailViewModel> _updateService;
        private readonly IAuthorRepositories _repository;

        public AuthorController(
            IAuthorService<AuthorEntity> createService, 
            IAuthorService<AuthorDetailViewModel> updateService,
            IAuthorRepositories repo, 
            IResponseBuilder helpers
        )
        {
            _createService = createService;
            _updateService = updateService;
            _helpers = helpers;
            _repository = repo;
        }

        [HttpGet]
        public ActionResult<AuthorEntity> Index()
        {
            return Ok(_helpers.SuccessResponse("Succes get all data author" , _repository.Index()));
        }

        [HttpGet("{id}")]
        public ActionResult<AuthorEntity> Show(Guid id)
        {
            return Ok(_helpers.SuccessResponse("Success Get Detail Author", _repository.Show(id)));
        }

        [HttpPost]
        public async Task<ActionResult<AuthorEntity>> Store(AuthorEntity author)
        {
            dynamic creating = await _createService.Create(author);

            if (creating.status == true)
            {
                return Ok(_helpers.SuccessResponse(creating.message, creating.data));
            }
            else
            {
                return StatusCode(500, _helpers.ErrorResponse("Error To create", new string[] { creating.message }));
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AuthorEntity>> Update(Guid id ,AuthorDetailViewModel author)
        {
            author.Id = id;
            dynamic updating = await _updateService.Update(author);

            if (updating.status == true)
            {
                return Ok(_helpers.SuccessResponse(updating.message, updating.data));
            }
            else
            {
                return StatusCode(500, _helpers.ErrorResponse("Error To create", new string[] { updating.message }));
            }
        }

    }
}