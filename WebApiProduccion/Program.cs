using Microsoft.EntityFrameworkCore;
using WebApiProduccion.Data;

var builder = WebApplication.CreateBuilder(args);

// Registrar servicios en el contenedor
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar el DbContext con la cadena de conexión desde appsettings.json
builder.Services.AddDbContext<ProduccionDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Crear la aplicación
var app = builder.Build();

// Configurar el pipeline de middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
