using HLHJZJ_ADT_2023241.Logic;
using HLHJZJ_ADT_2023241.Models;
using HLHJZJ_ADT_2023241.Repository;

namespace HLHJZJ_ADT_2023241.Endpoint
{
    public class StartUp
    {
        public StartUp(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<LegoDBContext>();

            services.AddTransient<IRepository<Topic>, TopicRepository>();
            
            services.AddTransient<ITopicLogic, TopicLogic>();
            


            services.AddCors();

            services.AddControllers();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }

            app.UseCors(x =>
                x.AllowCredentials()
                .AllowAnyHeader()
                .AllowAnyMethod()
                .WithOrigins("http://localhost:21071")
            );



            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
