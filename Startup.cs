using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TrySimpleApi.Helpers;
using TrySimpleApi.Application.Product;
using TrySimpleApi.Infrastructure.Product.DataManagers;
using TrySimpleApi.Application.Author;
using TrySimpleApi.Infrastructure.Author.Repositories;
using TrySimpleApi.Infrastructure.Author.DataManagers;
using TrySimpleApi.Domain.Author.Entities;
using TrySimpleApi.Domain.Author.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Web;

namespace TrySimpleApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<IResponseBuilder , ResponseBuilderHelper>();
            services.AddScoped<IProductService , CreateProductService>();
            services.AddScoped<IProductRepositories , ProductDAO>();
            services.AddTransient<IAuthorService<AuthorEntity> , CreateAuthorService>();
            services.AddTransient<IAuthorService<AuthorDetailViewModel> , UpdateAuthorService>();
            services.AddScoped<IAuthorRepositories , AuthorDAO>();
            services.AddDbContext<ProductContext>(options => options.UseSqlServer(Configuration["ConnectionString:DefaultConnection"]));

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (context) =>
                {
                    var errorsList = context.ModelState.Values.SelectMany(x => x.Errors.Select(p => p.ErrorMessage)).ToList();
                    var result = new
                    {
                        status = false,
                        message = "Validation errors",
                        errors = errorsList
                    };
                    return new BadRequestObjectResult(result);
                };
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
