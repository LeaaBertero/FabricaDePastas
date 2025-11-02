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
    [Route("api/Usuario")]

    public class UsuarioControllers : ControllerBase
    {
        private readonly IUsuarioRepositorio repositorio;

        //private readonly Context context;
        private readonly IMapper mapper;

        #region constructor
        public UsuarioControllers(IUsuarioRepositorio repositorio, 
                                  IMapper mapper)
        {
            this.repositorio = repositorio;
            //this.context = context;
            this.mapper = mapper;
        }
        #endregion

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            return await repositorio.Select();
        }
        #endregion

        #region Método Get por {id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Usuario>> Get(int id)
        {
            var dammy = await repositorio.SelectById(id);

            if (dammy == null)
            {
                return NotFound();
            }

            return dammy;
        }
        #endregion

        #region Método Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearUsuarioDTO entidadDTO)
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

                Usuario entidad = mapper.Map<Usuario>(entidadDTO);


                return await repositorio.Insert(entidad);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        #endregion

        #region Método Put
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Usuario entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var dammy = await repositorio.SelectById(id);

            if (dammy == null)
            {
                return NotFound("No se encontró el registro buscado");
            }

            dammy.Nombre = entidad.Nombre;
            dammy.Apellido = entidad.Apellido;
            dammy.Email = entidad.Email;
            dammy.Contraseña = entidad.Contraseña;
            dammy.Teléfono = entidad.Teléfono;
            dammy.Dirección = entidad.Dirección;
            dammy.Cuit_Cuil = entidad.Cuit_Cuil;
            //dammy.Fecha_Registro = entidad.Fecha_Registro;

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
                return NotFound($"El usuario {id} no existe.");
            }
            if (await repositorio.Delete(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest("No se pudo eliminar el usuario");
            }
        }
        #endregion


        #region Método Login
        [HttpPost("Login")]
        public async Task<ActionResult<LoginRespuestaDTO>> Login([FromBody] CrearLoginDTO loginDTO)
        {
            // Validación inicial
            if (loginDTO == null || string.IsNullOrEmpty(loginDTO.NombreUsuario) || string.IsNullOrEmpty(loginDTO.Contraseña))
            {
                return new LoginRespuestaDTO
                {
                    Exitoso = false,
                    Mensaje = "Debe ingresar nombre de usuario y contraseña."
                };
            }

            // Busca el usuario por nombre de usuario (case insensitive)
            var usuario = await repositorio.Query()
                .FirstOrDefaultAsync(u => u.NombreUsuario.ToLower() == loginDTO.NombreUsuario.ToLower());

            if (usuario == null)
            {
                return new LoginRespuestaDTO
                {
                    Exitoso = false,
                    Mensaje = "Usuario no encontrado."
                };
            }

            // Verificamos la contraseña (texto plano en este ejemplo; idealmente usar hash)
            if (usuario.Contraseña != loginDTO.Contraseña) // O PasswordHash si implementaste hash
            {
                return new LoginRespuestaDTO
                {
                    Exitoso = false,
                    Mensaje = "Contraseña incorrecta."
                };
            }

            // Login exitoso
            return new LoginRespuestaDTO
            {
                Exitoso = true,
                Mensaje = "Inicio de sesión exitoso.",
                // Token = "...", // Opcional si vas a implementar JWT
                // IdUsuario = usuario.Id // Puedes agregar info adicional si querés
            };
        }
        #endregion


    }
}
