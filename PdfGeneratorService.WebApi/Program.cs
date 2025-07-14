using PdfGeneratorService.Infrastructure.Data.Configuration;
using PdfGeneratorService.WebApi.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();

builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddJwtAuthentication(builder.Configuration);

builder.Services.AddApplicationServices();
builder.Services.AddSwaggerConfig();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PDF Generator Service API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();