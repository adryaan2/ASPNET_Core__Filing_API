using System;
using System.Collections.Generic;

namespace Filing_API.Models;

public partial class PartnerT
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public virtual ICollection<IktatoszamT> IktatoszamTs { get; set; } = new List<IktatoszamT>();
}
