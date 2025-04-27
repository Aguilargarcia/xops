using Microsoft.AspNetCore.Identity;
using xops.marca.core.Dto;

namespace xops.marca.core.Entities;

public class Marca : IdentityUser
{
    public string Name { get; set; }
    public string Foto { get; set; }


}


