using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using xops.common.Errors;
using xops.session.core.Entities;
using xops.session.core.Interfaces;
using xops.session.core.MappingProfiles;
using xops.user.core.Entities;
namespace xops.session.logic.Services;

public class SessionService : ISessionService
{

    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly ITokenService _tokenService;

    public SessionService(UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task<Session> Login(Login credentials)
    {
        var user = await _userManager.FindByEmailAsync(credentials.Email);
        if (user is null)
        {
            throw new NotFoundException();
        }
        var check = await _signInManager.CheckPasswordSignInAsync(user, credentials.Password, false);
        if (!check.Succeeded)
        {
            throw new UnAuthorizedException("password or email are wrong");
        }

        var roles = await _userManager.GetRolesAsync(user);
        return new Session { Token = _tokenService.CreateToken(user, roles) };
    }

    public async Task<Session> Registro(Registro registro)
    {
        var check = await _userManager.FindByEmailAsync(registro.Email);
        if (check is not null)
        {
            throw new BadRequestException("User with this email already exists");
        }
        var user = registro.toUser();
        var newUser = await _userManager.CreateAsync(user, registro.Password);
        if (!newUser.Succeeded)
        {
            throw new BadRequestException("Ups");
        }

        return new Session { Token = _tokenService.CreateToken(user, null) };
    }
}
