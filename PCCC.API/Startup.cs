using PCCC.Data;
using PCCC.Repository.Interfaces;
using PCCC.Repository;
using PCCC.Service.Interfaces;
using PCCC.Service.Services;
using PCCC.Service;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;
using PCCC.API.Middleware;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using AutoMapper;
using PCCCC.Service.Services;
using Minio;

namespace PCCC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public IConfiguration Configuration { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var minio = Configuration.GetSection("minio");
            services.AddMinio(minio["MINIO_ACCESS_KEY"], minio["MINIO_SECRET_KEY"]);

            // Add Minio using the custom endpoint and configure additional settings for default MinioClient initialization
            services.AddMinio(configureClient =>
            {
                configureClient.WithEndpoint(minio["MINIO_END_POINT"]);
                configureClient.WithCredentials(minio["MINIO_ACCESS_KEY"], minio["MINIO_SECRET_KEY"]);
            });
            //services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews();
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
            });
           
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddDbContext<PcccContext>(options => options.UseNpgsql(Configuration.GetConnectionString("main")));

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(1);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            // Register the Swagger generator, defining 1 or more Swagger documents
            //check token [Authorize]
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("WebClient", new OpenApiInfo { Title = "WebClient API", Version = "WebClient" });
                c.SwaggerDoc("WebAdmin", new OpenApiInfo { Title = "Web Admin API", Version = "WebAdmin" });
                c.DocInclusionPredicate((docName, apiDesc) =>
                {
                    if (string.IsNullOrEmpty(apiDesc.GroupName))
                    {
                        if (docName == "WebClient")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (docName == apiDesc.GroupName)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }

                });

            });
            services.AddDistributedMemoryCache();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<MinioClient>();
            ConfigureCoreAndRepositoryService(services);
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            //sử dụng swagger
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/App/swagger.json", "App API");
            //    c.SwaggerEndpoint("/swagger/WebAdmin/swagger.json", "WebAdmin API");
            //    c.RoutePrefix = string.Empty;
            //    c.OAuthUseBasicAuthenticationWithAccessCodeGrant();
            //    c.DocExpansion(DocExpansion.None);
            //    c.DefaultModelsExpandDepth(-1);
            //});
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/WebClient/swagger.json", "WebClient API");
                options.SwaggerEndpoint("/swagger/WebAdmin/swagger.json", "WebAdmin API");
            });
            app.UseDeveloperExceptionPage();
            //app.UseMiddleware<JWTMiddleware>();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors("CorsPolicy");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=LoginWeb}/{id?}");
            });
        }
        private void ConfigureCoreAndRepositoryService(IServiceCollection services)
        {
            // basse
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IServices<>), typeof(BaseService<>));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IContentRepository, ContentRepository>();
            services.AddScoped<IContentService, ContentService>();
            services.AddScoped<INewRepository, NewRepository>();
            services.AddScoped<INewService, NewService>();        
            services.AddScoped<IBuildingRepository, BuildingRepository>();
            services.AddScoped<IBuildingService, BuildingService>();    
            services.AddScoped<IUpgradeAccRepository, UpgradeAccRepository>();
            services.AddScoped<IUpgradeAccService, UpgradeAccService>();

            // Add Mapter Singler 
            var mp = new MapperConfiguration((MapperContext) => MapperContext.AddProfile(new MappingProfile()));
            services.AddSingleton(mp.CreateMapper());

        }
    }
}
