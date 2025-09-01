using AutoMapper;
using FabricaPastas.BD.Data;
using FabricaPastas.BD.Data.Entity;
using FabricaPastas.Server.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaPastas.Server.Controllers
{
    [ApiController]
    [Route("api/Metodo_Entrega")]
    public class Metodo_EntregaControllers : ControllerBase
    {
        private readonly IMetodo_EntregaRepositorio repositorio;

        //private readonly Context context;
        private readonly IMapper mapper;

        #region constructor
        public Metodo_EntregaControllers(IMetodo_EntregaRepositorio repositorio,
                                         IMapper mapper)
        {
            this.repositorio = repositorio;
            //this.context = context;
            this.mapper = mapper;
        }
        #endregion

         #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Metodo_Entrega>>> Get()
        {
            return await repositorio.Select();
        }
        #endregion

    }
}

        
