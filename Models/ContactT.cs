using System;
using System.Collections.Generic;

namespace Filing_API.Models;

public partial class ContactT
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Title { get; set; }

    public string? PhoneNumber { get; set; }

    public string? EMail { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<ContactModT> ContactModTs { get; set; } = new List<ContactModT>();

    public virtual ICollection<DocumentContactJ> DocumentContactJs { get; set; } = new List<DocumentContactJ>();
}
