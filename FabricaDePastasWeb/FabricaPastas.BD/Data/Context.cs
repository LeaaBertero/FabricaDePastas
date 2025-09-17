using FabricaPastas.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricaPastas.BD.Data
{
    public class Context : DbContext
    {
        #region constructor
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        #endregion

        #region entidades
        
        public DbSet<Categoria_Producto> Categoria_Producto { get; set; }
        public DbSet<Detalle_Lista_Precio> Detalle_Lista_Precio { get; set; }
        public DbSet<Detalle_Pedido> Detalle_Pedido { get; set; }
        public DbSet<Estado_Pedido> Estado_Pedido { get; set; }
        public DbSet<Forma_Pago> Forma_Pago { get; set; }
        public DbSet<Lista_Precio> Lista_Precio { get; set; }
        public DbSet<Metodo_Entrega> Metodo_entrega { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Promocion> Promocion { get; set; }
        public DbSet<Promocion_Producto> Promocion_Producto { get; set; }
        public DbSet<Promocion_Usuario> Promocion_Usuario { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Tipo_Cliente> Tipo_Cliente { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        #endregion

        #region código para evitar qel borrado en cascada OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var cascadeFKs = modelBuilder.Model.G­etEntityTypes()
                                            .SelectMany(t => t.GetForeignKeys())
                                            .Where(fk => !fk.IsOwnership
                                                        && fk.DeleteBehavior == DeleteBehavior.Casca­de);
            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restr­ict;
            }

            base.OnModelCreating(modelBuilder);


            #region Has_Precision
            modelBuilder.Entity<Promocion_Producto>()
            .Property(p => p.Descuento_Porcentaje)
            .HasColumnType("decimal(18,2)");
                    
            modelBuilder.Entity<Promocion_Producto>()
                .Property(p => p.Precio_Promocional)
                .HasColumnType("decimal(18,2)");
            #endregion

        }
        #endregion


    }
}


