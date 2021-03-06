namespace MyCalculatorWebApp
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>Class startup</summary>
    public class Startup
    {
        /// <summary>Initializes a new instance of the <see cref="Startup"/> class.</summary>
        /// <param name="configuration">The configuration.</param>
        private readonly IHostingEnvironment hosting;
        public Startup(IConfiguration configuration , IHostingEnvironment _hosting)
        {
            Configuration = configuration;
            hosting = _hosting;
        }

        /// <summary>Gets the configuration.</summary>
        /// <value>The configuration.</value>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>Configures the services.</summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddMvcOptions(options =>
                {
                    options.EnableEndpointRouting = false;
                }
)
                .SetCompatibilityVersion(CompatibilityVersion.Latest)
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressMapClientErrors = true; //removes the full error log
                });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Calculator Web App" + hosting.EnvironmentName,
                    Version = "v1",
                    Description = "Web API example, created with ASP.NET CORE",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Filipe Costa",
                        Url = new System.Uri("http://localhost")
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>Configures the specified application.</summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseMvc();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Calculator App");
            });
        }
    }
}
