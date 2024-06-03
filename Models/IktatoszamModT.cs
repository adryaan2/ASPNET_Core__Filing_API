using System;
using System.Collections.Generic;

namespace Filing_API.Models;

public partial class IktatoszamModT
{
    public Guid Id { get; set; }

    public Guid IktatoszamId { get; set; }

    public DateTime ModificationDate { get; set; }

    public string JsonData { get; set; } = null!;

    public virtual IktatoszamT Iktatoszam { get; set; } = null!;
}
