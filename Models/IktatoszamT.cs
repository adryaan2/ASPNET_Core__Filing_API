using System;
using System.Collections.Generic;

namespace Filing_API.Models;

public partial class IktatoszamT
{
    public Guid Id { get; set; }

    public string Iktatoszam { get; set; } = null!;

    public Guid? ProjectId { get; set; }

    public Guid? PartnerId { get; set; }

    public virtual ICollection<DocumentT> DocumentTs { get; set; } = new List<DocumentT>();

    public virtual ICollection<IktatoszamModT> IktatoszamModTs { get; set; } = new List<IktatoszamModT>();

    public virtual PartnerT? Partner { get; set; }

    public virtual ProjectT? Project { get; set; }
}
