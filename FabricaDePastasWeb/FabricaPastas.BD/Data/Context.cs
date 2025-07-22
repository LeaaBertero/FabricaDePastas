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
        public Context(DbContextOptions<Context> options) : base(options)

        {

        }



        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<TipoCliente> TipoClientes { get; set; }
        public DbSet<FormaPago> FormasPago { get; set; }
        public DbSet<MetodoEntrega> MetodosEntrega { get; set; }
        public DbSet<EstadoPedido> EstadosPedido { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<DetallePedido> DetallesPedido { get; set; }
        public DbSet<CategoriaProducto> CategoriasProducto { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Promocion> Promociones { get; set; }
        public DbSet<PromocionProducto> PromocionesProducto { get; set; }
        public DbSet<PromocionUsuario> PromocionesUsuario { get; set; }
        public DbSet<ListaPrecio> ListasPrecio { get; set; }
        public DbSet<DetalleListaPrecio> DetallesListaPrecio { get; set; }


        #region Cascada
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Éste codigo sirve para evitar que se borren los datos en cascada en la base de datos
            var cascadeFKs = modelBuilder.Model.G­etEntityTypes()
                                            .SelectMany(t => t.GetForeignKeys())
                                            .Where(fk => !fk.IsOwnership
                                                        && fk.DeleteBehavior == DeleteBehavior.Casca­de);
            foreach (var fk in cascadeFKs)
            {        //Elimina el cmportamiento               
                fk.DeleteBehavior = DeleteBehavior.Restr­ict;
            }

            base.OnModelCreating(modelBuilder);
        }
        #endregion


    }
}
