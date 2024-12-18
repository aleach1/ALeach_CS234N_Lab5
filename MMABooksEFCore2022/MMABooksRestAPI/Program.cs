using Microsoft.Extensions.DependencyInjection;
using MMABooksEFClasses.MODELS;

var builder = WebApplication.CreateBuilder(args);

// Add CORS policy - in a production app LOCK THIS DOWN!
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyOrigin()
            .WithMethods("POST", "PUT", "DELETE", "GET", "OPTIONS")
            .AllowAnyHeader();
        });
});
// Add services to the container.
// ADDING THE DBCONTEXT TO THE SERVICE
builder.Services.AddDbContext<MMABooksContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

//enables the cors policy
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
