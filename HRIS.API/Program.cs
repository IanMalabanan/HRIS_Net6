using HRIS.Infrastructure;
using HRIS.Application;
using MediatR;
using System.Reflection;
using HRIS.Application.Common.Interfaces.Services;
using HRIS.API.Services;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using HRIS.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();

builder.Services.AddCors();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(Assembly.Load("HRIS.Application"));
builder.Services.AddMediatR(Assembly.Load("HRIS.Infrastructure"));

builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.DocumentTitle = "HRIS - Rest API Services";
        c.SwaggerEndpoint("/swagger/HRIS/swagger.json", "HRIS");
    });
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
