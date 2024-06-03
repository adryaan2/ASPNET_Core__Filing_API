using System;
using System.Collections.Generic;

namespace Filing_API.Models;

public partial class ContactModT
{
    public Guid Id { get; set; }

    public Guid ContactId { get; set; }

    public DateTime ModificationDate { get; set; }

    public string JsonData { get; set; } = null!;

    public virtual ContactT Contact { get; set; } = null!;
}
