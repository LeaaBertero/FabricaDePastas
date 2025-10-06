using AutoMapper;
using FabricaPastas.BD.Data;
using FabricaPastas.BD.Data.Entity;
using FabricaPastas.Server.Repositorio;
using FabricaPastas.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaPastas.Server.Controllers
{
    [ApiController]
    [Route("/api/Categoria_Producto")]
    public class Categoria_ProductoControllers : ControllerBase
    {
        private readonly ICategoria_ProductoRepositorio repositorio;

        //private readonly Context context;
        private readonly IMapper mapper;

        #region constructor
        public Categoria_ProductoControllers(ICategoria_ProductoRepositorio repositorio,
                                             IMapper mapper)
        {
            this.repositorio = repositorio;
            //this.context = context;
            this.mapper = mapper;
        }
        #endregion

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Categoria_Producto>>> Get()
        {
            return await repositorio.Select();
        }
        #endregion

        #region Método Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearCategoria_ProductoDTO entidadDTO)
        {
            try
            {
                //Usuario entidad = new Usuario();

                //entidad.Nombre = entidadDTO.Nombre;
                //entidad.Apellido = entidadDTO.Apellido;
                //entidad.Email = entidadDTO.Email;
                //entidad.Contraseña = entidadDTO.Contraseña;
                //entidad.Teléfono = entidadDTO.Teléfono;
                //entidad.Dirección = entidadDTO.Dirección;
                //entidad.Cuit_Cuil = entidadDTO.Cuit_Cuil;
                //entidad.Fecha_Registro = entidadDTO.Fecha_Registro;

                Categoria_Producto entidad = mapper.Map<Categoria_Producto>(entidadDTO);


                return await repositorio.Insert(entidad);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        #endregion

        #region Método Put
        //[HttpPut("{id:int}")]
        //public async Task<ActionResult> Put(int id, [FromBody] Categoria_Producto entidad)
        //{
        //    if (id != entidad.Id)
        //    {
        //        return BadRequest("Datos incorrectos");
        //    }

        //    var dammy = await repositorio.SelectById(id);

        //    if (dammy == null)
        //    {
        //        return NotFound("No se encontró la categoria buscada");
        //    }

        //    dammy.Nombre_Categoria = entidad.Nombre_Categoria;


        //    //dammy.Fecha_Registro = entidad.Fecha_Registro;

        //    try
        //    {
        //        await repositorio.Update(id, dammy);

        //        return Ok();

        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //}


        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Categoria_Producto entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var dammy = await repositorio.SelectById(id);

            if (dammy == null)
            {
                return NotFound("No se encontró la categoria buscada");
            }

            dammy.Tipo_Pasta = entidad.Tipo_Pasta;
            dammy.Forma = entidad.Forma; 
            dammy.Tamanio = entidad.Tamanio; 
            dammy.IngredientesBase = entidad.IngredientesBase; 
            dammy.ProcesoElaboracion = entidad.ProcesoElaboracion; 

            try
            {
                await repositorio.Update(id, dammy);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        #endregion

        #region Método Delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await repositorio.Existe(id);

            if (!existe)
            {
                return NotFound($"La categoría {id} no existe.");
            }
            if (await repositorio.Delete(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest("No se pudo eliminar la categoría");
            }
        }
        #endregion
       
    }
}
