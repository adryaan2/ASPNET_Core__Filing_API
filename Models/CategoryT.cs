using System;
using System.Collections.Generic;

namespace Filing_API.Models;

public partial class CategoryT
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<DocumentT> DocumentTs { get; set; } = new List<DocumentT>();
}
