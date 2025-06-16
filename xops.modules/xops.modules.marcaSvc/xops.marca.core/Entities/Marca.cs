using Microsoft.AspNetCore.Identity;

namespace xops.marca.core.Entities;

public class Marca : IdentityUser
{
    public string Name { get; set; }
    public string Foto { get; set; }


}


