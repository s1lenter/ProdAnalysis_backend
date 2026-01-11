using System.Net.Sockets;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProductionAnalysisBackend;
using ProductionAnalysisBackend.Mapping;
using ProductionAnalysisBackend.Middlewares;
using ProductionAnalysisBackend.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// var connectionString = builder.Configuration.GetConnectionString("LocalConnection");

builder.Services.AddAutoMapper(typeof(AppMapperProfile));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();

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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

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
app.UseAuthentication();
app.UseAuthorization();

app.Run();