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
        public Context(DbContextOptions options) : base(options)
        {
        }

        #region OnModelCreating
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
        }
        #endregion

    }
}
