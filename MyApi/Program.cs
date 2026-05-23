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
// =================

// ===== Repository =====
builder.Services.AddSingleton<IProductRepository, JsonProductRepository>();
// ======================

var app = builder.Build();

// ===== Swagger Custom =====
app.UseStaticFiles();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.InjectStylesheet("/swagger-ui/custom.css");
});
// ==========================

app.UseHttpsRedirection();

// ===== CORS =====
app.UseCors("AllowAll");
// =================

app.UseAuthorization();

app.MapControllers();

app.Run();
