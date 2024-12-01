﻿using System;
using System.Collections.Generic;

namespace JourneyHubWeb.Models;

public partial class PackageType
{
    public int TypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Package> Packages { get; set; } = new List<Package>();
}
