using FabricaPastas.BD.Data;
using FabricaPastas.Server.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace FabricaPastas.Server.Repositorios
{
    public class Repositorio<E> : IRepositorio<E>
                 where E : class, IEntityBase
    {
        private readonly Context context;

        #region constructor 
        public Repositorio(Context context)
        {
            this.context = context;
        }
        #endregion

        public async Task<bool> Existe(int id)
        {
            var existe = await context.Set<E>()
                             .AnyAsync(x => x.Id == id);
            return existe;
        }

        public async Task<List<E>> Select()
        {
            return await context.Set<E>().ToListAsync();
        }

        public async Task<E> SelectById(int id)
        {
            E? pepe = await context.Set<E>()
                .AsNoTracking()
                .FirstOrDefaultAsync(
                x => x.Id == id);
            return pepe;
        }

        public async Task<int> Insert(E entidad)
        {
            try
            {
                await context.Set<E>().AddAsync(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public async Task<bool> Update(int id, E entidad)
        {
            if (id != entidad.Id)
            {
                return false;
            }

            var pepe = await SelectById(id);

            if (pepe == null)
            {
                return false;
            }

            try
            {
                context.Set<E>().Update(entidad);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var pepe = await SelectById(id);

            if (pepe == null)
            {
                return false;
            }

            context.Set<E>().Remove(pepe);
            await context.SaveChangesAsync();
            return true;
        }

    }
}
