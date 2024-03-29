using BookStoreApi.Models;
using BookStoreApi.Services;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;


var builder = WebApplication.CreateBuilder(args);

var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy  =>
                      {
                          policy.WithOrigins("http://localhost:5038");
                      });
});

// Add services to the container.
    builder.Services.Configure<BookStoreDatabaseSettings>(
    builder.Configuration.GetSection("BookStoreDatabase"));

    builder.Services.Configure<BookStoreDatabaseSettings>(
    builder.Configuration.GetSection("KelasDatabase"));

    builder.Services.Configure<BookStoreDatabaseSettings>(
    builder.Configuration.GetSection("MapelDatabase"));

    builder.Services.Configure<BookStoreDatabaseSettings>(
    builder.Configuration.GetSection("GuruDatabase"));

    builder.Services.Configure<BookStoreDatabaseSettings>(
    builder.Configuration.GetSection("PresensiHarianGuruDatabase"));

    builder.Services.Configure<BookStoreDatabaseSettings>(
    builder.Configuration.GetSection("PresensiMengajarDatabase"));

    builder.Services.AddSingleton<BooksService>();

    builder.Services.AddSingleton<MapelService>();

    builder.Services.AddSingleton<GuruService>();

    // builder.Services.AddSingleton<PresensiHarianGuruService>();

    // builder.Services.AddSingleton<PresensiMengajarService>();

    builder.Services.AddSingleton<KelasService>();

//builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
builder.Services.AddControllers();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});
builder.Services.AddAuthorization();

//Add configuration from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "BookStore Api",
        Description = "An ASP.NET Core Web API for managing BookStore items",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
});



var app = builder.Build();

app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(MyAllowSpecificOrigins);

IConfiguration configuration = app.Configuration;

IWebHostEnvironment environment = app.Environment;

app.MapControllers();

app.Run();
