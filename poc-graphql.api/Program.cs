using Microsoft.OpenApi.Models;
using poc_graphql.api.Models1;
using poc_graphql.infrasctructure.data.repositories.cliente.querys;
using poc_graphql.infrasctructure.extensions;
using poc_graphql.infrasctructure.ioc;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfraestructure(builder.Configuration);

builder.Services.AddSwaggerGen(options =>
{
    var title = builder.Configuration["OpenApi:info:title"];
    var version = builder.Configuration["OpenApi:info:version"];
    var description = builder.Configuration["OpenApi:info:description"];

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = title,
        Description = description,
    });

    options.SwaggerDoc("v2", new OpenApiInfo
    {
        Version = version,
        Title = title,
        Description = description,
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = System.IO.Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

var app = builder.Build();



if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Test"))
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint($"/swagger/v1/swagger.json", $"v1");
        c.SwaggerEndpoint($"/swagger/v2/swagger.json", $"v2");
    }
   );
}

app.ConfigureExceptionHandler();
app.MapControllers();
app.MapGraphQL("/graphql");

app.UseAuthorization();


app.Run();
