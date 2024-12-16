using Microsoft.EntityFrameworkCore;
using WebApiProduccion.Data;
using WebApiProduccion.Models;
using System.Diagnostics;

namespace WebApiProduccion.Data
{
    public class ProduccionDbContext : DbContext
    {
        public ProduccionDbContext(DbContextOptions<ProduccionDbContext> options) : base(options) { }

         //DbSet para cada tabla de tu base de datos
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<OrdenProduccion> OrdenProduccion { get; set; }
        public DbSet<Almacen> Almacen { get; set; }
        public DbSet<Rechazo> Rechazo { get; set; }
        public DbSet<Maquina> Maquina { get; set; }
        public DbSet<MateriaPrima> MateriaPrima { get; set; }
        public DbSet<Proceso> Proceso { get; set; }
        public DbSet<Inventario> Inventario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
