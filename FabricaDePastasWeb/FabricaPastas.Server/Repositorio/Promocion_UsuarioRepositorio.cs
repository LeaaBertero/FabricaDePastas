using FabricaPastas.BD.Data;
using FabricaPastas.BD.Data.Entity;

namespace FabricaPastas.Server.Repositorio
{
    public class Promocion_UsuarioRepositorio : Repositorio<Promocion_Usuario>, IPromocion_UsuarioRepositorio
    {
        public Promocion_UsuarioRepositorio(Context context) : base(context)
        {
        }
    }
}
