using Gestao.Cadastro.Digital.CrossCutting.IoC;
using Microsoft.OpenApi;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDatabaseInfrastructure(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddApplicationServices();

builder.Services.AddControllers();

builder.Services.AddMediatorConfiguration();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Api Gestão de Cadastro Digital",
        Version = "v1",
        Description = "API responsável pelo cadastro digital",
        Contact = new OpenApiContact
        {
            Name = "Time de Backend",
            Email = "backend@empresa.com"
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();