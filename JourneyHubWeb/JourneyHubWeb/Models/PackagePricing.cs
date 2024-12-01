using System;
using System.Collections.Generic;

namespace JourneyHubWeb.Models;

public partial class PackagePricing
{
    public int PriceId { get; set; }

    public int? PackageId { get; set; }

    public decimal PricePerPerson { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public virtual Package? Package { get; set; }
}
