using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using xops.marca.core.Dto;
using xops.marca.core.Entities;
using xops.marca.core.Interfaces;
using xops.marca.core.Profiles;
using xops.marca.logic.Repositories;

namespace xops.marca.logic.Services;

public class MarcaService : IMarcaService
{

    private readonly IMarcaRepository _marcaRepository;
    private readonly UserManager<IdentityUser> _userManager;


    public MarcaService(IMarcaRepository marcaRepository, UserManager<IdentityUser> userManager)
    {
        _marcaRepository = marcaRepository;
        _userManager = userManager;
    }


    public Task<Marca> CreateMarca(MarcaDto marcaDto)
    {
        var marca = marcaDto.toMarca();
        
        _userManager.CreateAsync(marca);
        throw new NotImplementedException();
    }

    public Task DeleteMarca()
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyCollection<Marca>> GetAllMarcas()
    {
        throw new NotImplementedException();
    }

    public Task<Marca> GetMarcaProfile()
    {
        throw new NotImplementedException();
    }

    public Task UpdateMarca(MarcaDto marcaDto)
    {
        throw new NotImplementedException();
    }
}
