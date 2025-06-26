using Api_Antivirus.Config;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Logging.AzureAppServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.ConfigureServices(builder.Configuration);
builder.Services.ConfigureSwagger();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.ConfigureJwtAuthentication(builder.Configuration);
builder.Logging.ClearProviders();//Esto es nuevo, para limpiar los proveedores de logs por defecto
builder.Logging.AddConsole();//Esto es nuevo , para registrar logs en la consola
builder.Logging.AddDebug();//Esto es nuevo, para registrar logs en la consola de depuración
builder.Logging.AddAzureWebAppDiagnostics();//Esto es nuevo, para registrar logs en Azure
builder.Services.AddEndpointsApiExplorer();//Esto es nuevo, para generar la documentación de la API
builder.Services.AddSwaggerGen();// Esto es nuevo, para generar la documentación de la API


//configuracion de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });

    options.AddPolicy("AllowVercel", policy =>
    {
        policy.WithOrigins("http://localhost:5432", "https://frontend-antivi-git-c01c69-juan-felipe-restrepo-silvas-projects.vercel.app/",
        "https://frontend-antivirus-vercel.vercel.app/", "https://frontend-antivirus-vercel-138qlnggz.vercel.app/")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .SetIsOriginAllowedToAllowWildcardSubdomains();
    });
});

var app = builder.Build();


// Configuración de autenticación JWT (Esto es nuevo)
if (builder.Configuration["Jwt:Key"] != null)
{
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
            };
        });
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


// Middleware de manejo de errores global
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
        var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();

        if (exceptionHandlerPathFeature?.Error is Exception ex)
        {
            logger.LogError(ex, "Unhandled exception: {Message}", ex.Message);
        }

        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(new
        {
            error = "Internal server error occurred",
            timestamp = DateTime.UtcNow
        }));
    });
});

// Middleware de logging de requests
app.Use(async (context, next) =>
{
    var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
    var origin = context.Request.Headers["Origin"].FirstOrDefault();

    logger.LogInformation("Request: {Method} {Path} from Origin: {Origin}",
        context.Request.Method, context.Request.Path, origin ?? "null");

    await next();

    logger.LogInformation("Response: {StatusCode}", context.Response.StatusCode);
});

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Antivirus V1");
});

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger/index.html");
        return;
    }
    await next();
});


app.UseCors("AllowAllOrigins");
app.UseCors("AllowVercel");
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
