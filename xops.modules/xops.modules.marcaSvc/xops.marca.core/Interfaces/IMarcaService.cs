using xops.marca.core.Dto;
using xops.marca.core.Entities;
namespace xops.marca.core.Interfaces;

public interface IMarcaService
{
    Task<Marca> CreateMarca(MarcaDto marcaDto);
    Task<Marca> GetMarcaProfile();
    Task<IReadOnlyCollection<Marca>> GetAllMarcas();
    Task UpdateMarca(MarcaDto marcaDto);
    Task DeleteMarca();
}
