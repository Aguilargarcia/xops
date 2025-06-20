using System;
using System.ComponentModel.DataAnnotations;

namespace xops.session.core.Entities;

public class Login
{
    [EmailAddress]
    public required string Email { get; set; }
    public required string Password { get; set; }

}
