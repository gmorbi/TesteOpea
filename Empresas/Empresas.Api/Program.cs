using System.ComponentModel;
using Empresas.CrossCutting.InversionOfControl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
});

builder.Services.AddControllers()
                .AddNewtonsoftJson(options => 
                {
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
                });

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen( c => 
{
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddDatabaseDependency(builder.Configuration);

builder.Services.AddJwtDependency(builder.Configuration);

builder.Services.AddServicesDependency(builder.Configuration);

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI( c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your Endpoint Swagger"));

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
