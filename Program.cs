using Microsoft.EntityFrameworkCore;
using StudentAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("Custom", x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});
#endregion
#region Configure Database
var con = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<StdDbontext>(options => options.UseSqlServer(con));
#endregion

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
app.UseCors("Custom");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
