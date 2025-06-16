using System;
using xops.user.core.Entities;

namespace xops.user.core.Interfaces;

public interface ITokenService
{

    public string CreateToken(User user, IList<string> roles);

}
