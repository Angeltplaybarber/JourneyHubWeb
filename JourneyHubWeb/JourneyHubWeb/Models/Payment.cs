﻿using System;
using System.Collections.Generic;

namespace JourneyHubWeb.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int? ReservationId { get; set; }

    public decimal Amount { get; set; }

    public DateOnly? PaymentDate { get; set; }

    public string? PaymentMethod { get; set; }

    public virtual Reservation? Reservation { get; set; }
}
