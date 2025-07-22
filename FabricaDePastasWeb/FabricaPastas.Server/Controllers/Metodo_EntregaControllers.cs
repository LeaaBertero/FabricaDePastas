using FabricaPastas.BD.Data;
using Microsoft.AspNetCore.Mvc;

namespace FabricaPastas.Server.Controllers
{
    [ApiController]
    [Route("api/Metodo_Entrega")]

    public class Metodo_EntregaControllers : ControllerBase
    {
        private readonly Context context;

        public Metodo_EntregaControllers(Context context)
        {
            this.context = context;
        }
    }
}
