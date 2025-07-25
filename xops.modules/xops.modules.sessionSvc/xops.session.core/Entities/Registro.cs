using System;
using System.ComponentModel.DataAnnotations;

namespace xops.session.core.Entities;

public class Registro
{

    public required string UserName { get; set; }
    [EmailAddress]
    public required string Email { get; set; }
    public required string Name { get; set; }
    public required string Password { get; set; }
}
