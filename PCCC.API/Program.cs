using Microsoft.EntityFrameworkCore;
using PCCC.Data;
using PCCC.Repository.Interfaces;
using PCCC.Repository;
using PCCC.Service.Interfaces;
using PCCC.Service.Services;
using Swashbuckle.AspNetCore.SwaggerUI;
using PCCC.Service;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using PCCCC.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(1);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
builder.Services.AddSwaggerGen(c =>
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

builder.Services.AddDbContext<PcccContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("main")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped(typeof(IServices<>), typeof(BaseService<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();

builder.Services.AddDistributedMemoryCache();
// Add Mapper Singleton
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();
app.UseCors(builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});
app.UseDeveloperExceptionPage();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/WebClient/swagger.json", "WebClient API");
        options.SwaggerEndpoint("/swagger/WebAdmin/swagger.json", "WebAdmin API");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();