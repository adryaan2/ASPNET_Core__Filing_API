using System;
using System.Collections.Generic;

namespace Filing_API.Models;

public partial class DocumentT
{
    public Guid Id { get; set; }

    public Guid IktatoszamId { get; set; }

    public string Iktatoszam { get; set; } = null!;

    public string FileName { get; set; } = null!;

    public string? FilePath { get; set; }

    public string? PhysicalLocation { get; set; }

    public Guid Category { get; set; }

    public Guid Direction { get; set; }

    public string? PartnerIktatoszam { get; set; }

    public Guid? DeliveryMode { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public virtual CategoryT CategoryNavigation { get; set; } = null!;

    public virtual DeliveryModeT? DeliveryModeNavigation { get; set; }

    public virtual DirectionT DirectionNavigation { get; set; } = null!;

    public virtual ICollection<DocumentContactJ> DocumentContactJs { get; set; } = new List<DocumentContactJ>();

    public virtual ICollection<DocumentModT> DocumentModTs { get; set; } = new List<DocumentModT>();

    public virtual IktatoszamT IktatoszamNavigation { get; set; } = null!;
}
