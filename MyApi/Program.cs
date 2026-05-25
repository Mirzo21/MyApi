using MyApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

// ===== CORS =====
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// ===== Repository =====
builder.Services.AddSingleton<IProductRepository, JsonProductRepository>();

var app = builder.Build();

// ===== Static Files =====
app.UseDefaultFiles();
app.UseStaticFiles();

// ===== Swagger =====
app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.RoutePrefix = "swagger";
    c.InjectStylesheet("/swagger-ui/custom.css");
});

// ===== HTTPS =====
app.UseHttpsRedirection();

// ===== CORS =====
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

// ===== Open index.html =====
app.MapFallbackToFile("index.html");

app.Run();
