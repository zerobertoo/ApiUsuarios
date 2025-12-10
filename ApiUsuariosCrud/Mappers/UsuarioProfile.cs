using ApiUsuarios.DTOs;
using ApiUsuarios.Models;
using AutoMapper;

namespace ApiUsuarios.Mappers;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        // Mapeamento de Model para DTO
        CreateMap<Usuario, UsuarioDTO>();

        // Mapeamento de DTO para Model (Criação)
        CreateMap<CreateUsuarioDTO, Usuario>();

        // Mapeamento de DTO para Model (Atualização)
        CreateMap<UpdateUsuarioDTO, Usuario>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}
