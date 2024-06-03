using System;
using System.Collections.Generic;

namespace Filing_API.Models;

public partial class DocumentModT
{
    public Guid Id { get; set; }

    public Guid DocumentId { get; set; }

    public DateTime ModificationDate { get; set; }

    public string JsonData { get; set; } = null!;

    public virtual DocumentT Document { get; set; } = null!;
}
