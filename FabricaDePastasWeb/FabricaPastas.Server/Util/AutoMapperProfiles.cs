using AutoMapper;
using FabricaDePastas.Shared.DTO;

namespace FabricaPastas.Server.Util
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CrearUsuarioDTO>();
        }


    }
}
