using APN.WebApi.Configurations;

using Application.Commands.RealizaLogin;

using MediatR;

namespace Api
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
            services.AddControllers();

            services.AddEndpointsApiExplorer()
            .AddSwaggerGen()
            .AddSingleton<IHttpContextAccessor, HttpContextAccessor>()
            .AddRepositories()
            .AddServices()
            .AddQueries()
            .AddNotifications()
            .AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(typeof(Startup).Assembly, typeof(LoginHandler).Assembly);
            ;
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection()
            .UseRouting()
            .UseAuthorization()
            .UseCors();

            app.MapControllers();
        }
    }
}