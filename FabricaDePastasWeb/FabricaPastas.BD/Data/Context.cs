using FabricaPastas.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FabricaPastas.BD.Data
{
    public class Context : DbContext
    {
        #region Constructor
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        #endregion

        #region Entidades

        public DbSet<Categoria_Producto> Categoria_Producto { get; set; }
        public DbSet<Detalle_Lista_Precio> Detalle_Lista_Precio { get; set; }
        public DbSet<Detalle_Pedido> Detalle_Pedido { get; set; }
        public DbSet<Estado_Pedido> Estado_Pedido { get; set; }
        public DbSet<Forma_Pago> Forma_Pago { get; set; }
        public DbSet<Lista_Precio> Lista_Precio { get; set; }
        public DbSet<Metodo_Entrega> Metodo_Entrega { get; set; } // ✅ nombre corregido
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Promocion> Promocion { get; set; }
        public DbSet<Promocion_Producto> Promocion_Producto { get; set; }
        public DbSet<Promocion_Usuario> Promocion_Usuario { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Tipo_Cliente> Tipo_Cliente { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        #endregion

        #region Configuración OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 🔧 Evita borrado en cascada
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);

            #region Relaciones entre entidades

            // 🧩 Relación Pedido - Detalle_Pedido
            modelBuilder.Entity<Detalle_Pedido>()
                .HasOne(dp => dp.Pedido)
                .WithMany(p => p.Detalles)
                .HasForeignKey(dp => dp.Pedido_Id)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region HasPrecision configuraciones decimales

            // Promocion_Producto
            modelBuilder.Entity<Promocion_Producto>()
                .Property(p => p.Descuento_Porcentaje)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Promocion_Producto>()
                .Property(p => p.Precio_Promocional)
                .HasColumnType("decimal(18,2)");

            // Detalle_Lista_Precio
            modelBuilder.Entity<Detalle_Lista_Precio>()
                .Property(p => p.Precio_Personalizado)
                .HasColumnType("decimal(18,2)");

            // Detalle_Pedido
            modelBuilder.Entity<Detalle_Pedido>()
                .Property(p => p.Precio_Unitario)
                .HasColumnType("decimal(18,2)");

            // 🔢 También configuramos Subtotal
            modelBuilder.Entity<Detalle_Pedido>()
                .Property(p => p.Subtotal)
                .HasColumnType("decimal(18,2)");

            // Pedido
            modelBuilder.Entity<Pedido>()
                .Property(p => p.Total)
                .HasColumnType("decimal(18,2)");

            // Producto
            modelBuilder.Entity<Producto>()
                .Property(p => p.PrecioBase)
                .HasColumnType("decimal(18,2)");

            #endregion
        }
        #endregion
    }
}
