using System;
using xops.session.core.Entities;

namespace xops.session.core.Interfaces;

public interface ISessionService
{
    Task<Session> Login(Login credentials);
    Task<Session> Registro(Registro registro);

}
