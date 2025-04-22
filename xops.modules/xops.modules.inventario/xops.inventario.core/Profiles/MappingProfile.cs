using System;
using AutoMapper;
using xops.inventario.core.Dto;
using xops.inventario.core.Entities;

namespace xops.inventario.core.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CategoriaDto, Categoria>();

        CreateMap<ProductoDto, Producto>().ForMember(des=> des.Id, opt=>opt.Ignore() ).ConstructUsing((src, ctx) => new Producto(src.Nombre, src.MarcaId, src.Precio,
                        ctx.Mapper.Map<Categoria>(src.Categoria))).ReverseMap();
    }

}
