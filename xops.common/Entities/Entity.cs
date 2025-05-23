using System;
using System.ComponentModel.DataAnnotations;

namespace xops.common.Entities;

public class Entity
{
    [Key]
    public Guid Id {get; private set;} = Guid.NewGuid();
    public DateTime CreatedAt {get; set;} = DateTime.Now;

}
