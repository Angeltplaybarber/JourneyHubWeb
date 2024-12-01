using System;
using System.Collections.Generic;

namespace JourneyHubWeb.Models;

public partial class Reservation
{
    public int ReservationId { get; set; }

    public int? ClientId { get; set; }

    public int? PackageId { get; set; }

    public DateOnly? ReservationDate { get; set; }

    public int NumberOfPeople { get; set; }

    public decimal TotalPrice { get; set; }

    public string? Status { get; set; }

    public virtual Client? Client { get; set; }

    public virtual Package? Package { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
