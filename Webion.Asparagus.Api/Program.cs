using FastEndpoints.Swagger;
using Webion.Asparagus.Storage.FileSystem;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddSwaggerDoc();

services.AddFastEndpoints();
services.AddFileSystemStorage(options =>
{
    options.BasePath = "data";
});

var app = builder.Build();

app.UseFastEndpoints();
app.UseSwaggerGen();

app.Run();
