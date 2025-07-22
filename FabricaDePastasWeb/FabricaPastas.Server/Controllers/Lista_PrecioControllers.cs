using FabricaPastas.BD.Data;
using Microsoft.AspNetCore.Mvc;

namespace FabricaPastas.Server.Controllers
{
    [ApiController]
    [Route("api/Lista_Precio")]

    public class Lista_PrecioControllers
    {
        private readonly Context context;

        public Lista_PrecioControllers(Context context)
        {
            this.context = context;
        }
    }
}
