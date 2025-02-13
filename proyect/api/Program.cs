
using api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var allowedOrigins = builder.Configuration.GetValue<string>("allowedOrigins")!.Split(",");

builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer("name=DefaultConnection");
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        });
});


//builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
 //   .AddNegotiate();

//builder.Services.AddAuthorization(options =>
//{
//    options.FallbackPolicy = options.DefaultPolicy;
//});

var app = builder.Build();
//app.UseAuthentication();
//app.UseAuthorization();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseCors("AllowFrontend");

app.UseCors(builder =>
    builder.AllowAnyOrigin()
         .AllowAnyMethod()
          .AllowAnyHeader());

app.MapControllers();

app.Run();