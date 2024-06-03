using System;
using System.Collections.Generic;

namespace Filing_API.Models;

public partial class UserT
{
    public Guid Id { get; set; }

    public string UserName { get; set; } = null!;

    public string DisplayName { get; set; } = null!;

    public string Secret { get; set; } = null!;

    public string EMail { get; set; } = null!;
}
