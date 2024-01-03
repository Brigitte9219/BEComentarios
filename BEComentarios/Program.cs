using BEComentarios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Obtiene la cadena de conexion "DefaultConnection"
var conexion = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.

//Permite acceder a la BD
builder.Services.AddDbContext<AplicationDbContext>(options => options.UseMySql(conexion, ServerVersion.AutoDetect(conexion)));

//Configura la política CORS (Seguridad) permitiendo cualquier origen, método y encabezado
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
    builder => builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
});


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
