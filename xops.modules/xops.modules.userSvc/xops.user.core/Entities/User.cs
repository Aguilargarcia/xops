using Microsoft.AspNetCore.Identity;

namespace xops.user.core.Entities;

public class User : IdentityUser
{
    public string Name { get; set; }
    public string Image { get; set; }
    public Role Role { get; set; } = Role.USUARIO;

}
