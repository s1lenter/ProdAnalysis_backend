using System.Net.Sockets;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProductionAnalysisBackend;
using ProductionAnalysisBackend.Dto;
using ProductionAnalysisBackend.Mapping;
using ProductionAnalysisBackend.Middlewares;
using ProductionAnalysisBackend.Models;
using ProductionAnalysisBackend.Services;
using ProductionAnalysisBackend.Services.Admin;
using ProductionAnalysisBackend.Services.CycleTables;
using ProductionAnalysisBackend.Services.Dictionary;
using ProductionAnalysisBackend.Services.Supervisor;
using ProductionAnalysisBackend.Services.Tables;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var connectionString = builder.Configuration.GetConnectionString("LocalConnection");

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddAutoMapper(typeof(AppMapperProfile));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<ISupervisorService, SupervisorService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IDictionaryService<Product, ProductDto, ProductCreateDto>, 
    DictionaryService<Product, ProductDto, ProductCreateDto>>();

builder.Services.AddScoped<IDictionaryService<User, UserDto, UserCreateDto>, UserService>();

builder.Services.AddScoped<IDictionaryService<Department, DepartmentDto, DepartmentCreateDto>, 
    DictionaryService<Department, DepartmentDto, DepartmentCreateDto>>();

builder.Services.AddSingleton<IPersonalKeyGenerator, PersonalKeyGenerator>();

builder.Services.AddSingleton<IPersonalKeyHasher, PersonalKeyHasher>();

builder.Services.AddScoped<IPowerPerHourTableService, PowerPerHourTableService>();
builder.Services.AddScoped<IRowService, RowService>();

builder.Services.AddScoped<IProductionCycleService, ProductionCycleService>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["AppSettings:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["AppSettings:Audience"],
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:TokenKey"]!)),
            ValidateIssuerSigningKey = true
        };
    });

var app = builder.Build();

// if (app.Environment.IsDevelopment())
// {
    // app.UseSwagger();
    // app.UseSwaggerUI();
// }

app.UseSwagger(c =>
{
    c.RouteTemplate = "api/swagger/{documentName}/swagger.json";
});

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint(
        "/api/swagger/v1/swagger.json",
        "API v1");
    c.RoutePrefix = "api/swagger";
});

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();
    
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        context.Database.Migrate();
        logger.LogInformation("Миграции успешно применены");
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Произошла ошибка при применении миграций");
    }
}

app.MapGet("/", () => "Hello World!");

app.UseHttpsRedirection();
app.UseMiddleware<TokenHeaderMiddleware>();
app.MapControllers();

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.Run();