using System;
using System.Collections.Generic;

namespace JourneyHubWeb.Models;

public partial class Package
{
    public int PackageId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int? TypeId { get; set; }

    public virtual ICollection<PackagePricing> PackagePricings { get; set; } = new List<PackagePricing>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual PackageType? Type { get; set; }
}
