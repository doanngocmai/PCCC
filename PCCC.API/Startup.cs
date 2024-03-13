//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.IdentityModel.Logging;
//using Microsoft.OpenApi.Models;
//using PCCC.API.Entities;
//using PCCC.Common.Extensions;
//using PCCC.Data;
//using PCCC.Repository.Interfaces;

//namespace PCCC.API
//{
//    public class Startup
//    {
//        public Startup(IConfiguration configuration)
//        {
//            Configuration = configuration;
//        }

//        public IConfiguration Configuration { get; }

//        // This method gets called by the runtime. Use this method to add services to the container.
//        public void ConfigureServices(IServiceCollection services)
//        {
//            services.AddCors(
//                   opt => opt.AddPolicy("AllowAllHeaders",
//                       builder => builder
//                       .AllowAnyMethod()
//                       .AllowAnyHeader()
//                       .AllowAnyOrigin()
//                   )
//               );

//            services.AddDbContext<PcccContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("main")));

//            services.AddScoped(typeof(I), typeof(Data.PcccContext));
//            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

//            services.RegisterTransient(typeof(ITransientRepository));
//            services.RegisterTransient(typeof(ITransientService));

//            //IdentityModelEventSource.ShowPII = true;
//            //services.AddAuthentication(options =>
//            //{
//            //    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//            //    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//            //    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
//            //})
//            //.AddCookie()
//            //.AddOpenIdConnect(options =>
//            //{
//            //    options.Authority = Configuration["Authentication:oidc:Authority"];
//            //    options.ClientId = Configuration["Authentication:oidc:ClientId"];
//            //    options.ClientSecret = Configuration["Authentication:oidc:ClientSecret"];
//            //    options.RequireHttpsMetadata = false;
//            //    options.GetClaimsFromUserInfoEndpoint = true;
//            //    options.SaveTokens = true;
//            //    options.RemoteSignOutPath = "/swagger/index.html";
//            //    options.SignedOutRedirectUri = "Redirect-here";
//            //    options.ResponseType = "code";

//            //});

//            services.AddControllers();
//            services.AddSwaggerGen(c =>
//            {
//                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyrEdu.Admin.API", Version = "v1" });
//            });
//        }



//        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//            }
//            app.UseSwagger();
//            app.UseSwaggerUI(options =>
//            {
//                options.SwaggerEndpoint("/swagger/WebClient/swagger.json", "WebClient API");
//                options.SwaggerEndpoint("/swagger/WebAdmin/swagger.json", "WebAdmin API");
//            });

//            app.UseRouting();

//            app.UseAuthorization();

//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapControllers();
//            });
//            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
//            {
//                var context = serviceScope.ServiceProvider.GetRequiredService<Data.PcccContext>();
//                context.Database.EnsureCreated();
//            }
//        }

//    }
//}
