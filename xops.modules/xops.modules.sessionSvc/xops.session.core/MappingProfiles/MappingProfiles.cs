using System;
using xops.session.core.Entities;
using xops.user.core.Entities;

namespace xops.session.core.MappingProfiles;

public static class MappingProfiles
{

    public static User toUser(this Registro registro)
    {
        return new User()
        {
            Email = registro.Email,
            Name = registro.Name,
            UserName = registro.UserName,
        };

    }



}
