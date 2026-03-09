using NHL.Api.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// ------------------------------------
// Services
// ------------------------------------
builder.Services.AddControllers();
builder.Services.AddMemoryCache();
builder.Services.AddHttpClient<playerService>();
builder.Services.AddHttpClient<teamService>();
builder.Services.AddHttpClient<leagueService>();

// Configure CORS for Angular
builder.Services.AddCors(options =>
{
    options.AddPolicy("AngularPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "NHL API Proxy",
        Version = "v1",
        Description = "Proxy API for NHL data consumed by Angular frontend"
    });
});

var app = builder.Build();

// ------------------------------------
// Middleware
// ------------------------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "NHL API Proxy v1");
    });
}

app.UseHttpsRedirection();
app.UseCors("AngularPolicy");
app.UseAuthorization();
app.MapControllers();
app.Run();