using Microsoft.OpenApi.Models;
using TestEntityFrameworkMVCProj.Helpers;
using TestEntityFrameworkMVCProj.Models;
using TestEntityFrameworkMVCProj.Service;

namespace TestEntityFrameworkMVCProj
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            using (var client = new AzureStorageEmulatorDb510Context())
            {
                client.Database.EnsureCreated();
            }
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            //services.AddScoped<IPersonService, PeopleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddEntityFrameworkSqlServer().AddDbContext<AzureStorageEmulatorDb510Context>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TestEntityFrameworkMVCProj", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TestEntityFrameworkMVCProj v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
