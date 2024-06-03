using System;
using System.Collections.Generic;

namespace Filing_API.Models;

public partial class ProjectT
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Subject { get; set; }

    public virtual ICollection<IktatoszamT> IktatoszamTs { get; set; } = new List<IktatoszamT>();
}
