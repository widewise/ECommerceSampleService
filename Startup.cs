using ECommerceSampleService.GraphQL;
using ECommerceSampleService.Repositories;
using GraphQL.Server;
using GraphQL.Server.Ui.Altair;
using GraphQL.SystemTextJson;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ECommerceSampleService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<DocumentWriter>();
            services.AddSingleton<QueryObject>();
            services.AddSingleton<ECommerceSchema>();

            services
                .AddGraphQL(
                    (options, provider) =>
                    {
                        // Load GraphQL Server configurations
                        var graphQLOptions = Configuration
                            .GetSection("GraphQL")
                            .Get<GraphQLOptions>();
                        options.ComplexityConfiguration = graphQLOptions.ComplexityConfiguration;
                        options.EnableMetrics = graphQLOptions.EnableMetrics;
                        // Log errors
                        var logger = provider.GetRequiredService<ILogger<Startup>>();
                        options.UnhandledExceptionDelegate = ctx =>
                            logger.LogError("{Error} occurred", ctx.OriginalException.Message);
                    })
                // Adds all graph types in the current assembly with a singleton lifetime.
                .AddGraphTypes()
                // Add GraphQL data loader to reduce the number of calls to our repository. https://graphql-dotnet.github.io/docs/guides/dataloader/
                .AddDataLoader()
                .AddSystemTextJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphQL<ECommerceSchema>();
            // Enables Altair UI at path /
            app.UseGraphQLAltair();

            app.UseHttpsRedirection();
        }
    }
}