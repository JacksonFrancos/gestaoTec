using gestaoTec.Application.Services.Impls;
using gestaoTec.Application.Services.Iservices;
using gestaoTec.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

// <- MUITO IMPORTANTE
app.MapFallbackToFile("index.html");

app.Run();
