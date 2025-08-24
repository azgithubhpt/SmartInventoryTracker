using NSwag;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddOpenApiDocument(options =>
{
    options.PostProcess = document =>
    {
        document.Info = new OpenApiInfo
        {
            Title = "Smart Inventory Tracker API",
            Version = "v1",
            Description = "API for managing inventory items with Blob Storage integration",
            Contact = new OpenApiContact
            {
                Name = "Hitendra Tiwari",
                Url = "https://yourcompany.com/contact"
            },
            License = new OpenApiLicense
            {
                Name = "MIT",
                Url = "https://opensource.org/licenses/MIT"
            }
        };
    };
});

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();       // Serves /swagger/v1/swagger.json
    app.UseSwaggerUi();     // Serves Swagger UI at /swagger
    // Optional: app.UseReDoc(); // Serves ReDoc UI at /redoc
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
