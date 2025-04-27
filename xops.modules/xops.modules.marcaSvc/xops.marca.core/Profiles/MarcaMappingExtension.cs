using System;
using xops.marca.core.Dto;
using xops.marca.core.Entities;

namespace xops.marca.core.Profiles;

public static class MarcaMappingExtension
{
    public static MarcaDto toDto(this Marca marca){
        return new MarcaDto {
            Email = marca.Email,
            Name = marca.Name,
        };
    }

    public static Marca toMarca(this MarcaDto marcaDto){
        return new Marca{
            Email = marcaDto.Email,
            Name = marcaDto.Name
        };
    }

}
