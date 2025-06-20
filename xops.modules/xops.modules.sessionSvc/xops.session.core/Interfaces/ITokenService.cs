using System;
using xops.user.core.Entities;

namespace xops.session.core.Interfaces;

public interface ITokenService
{

    string CreateToken(User user, IList<string> roles);

}
