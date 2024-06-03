using System;
using System.Collections.Generic;

namespace Filing_API.Models;

public partial class DocumentContactJ
{
    public Guid Id { get; set; }

    public Guid DocumentId { get; set; }

    public Guid ContactId { get; set; }

    public virtual ContactT Contact { get; set; } = null!;

    public virtual DocumentT Document { get; set; } = null!;
}
