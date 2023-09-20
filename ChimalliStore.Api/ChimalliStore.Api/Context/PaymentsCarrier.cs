using System;
using System.Collections.Generic;

namespace ChimalliStore.Api.Context;

public partial class PaymentsCarrier
{
    public int PaymentCarrierId { get; set; }

    public string NamePaymentCarrier { get; set; } = null!;

    public string? DescriptionPaymentCarrier { get; set; }

    public string Country { get; set; } = null!;

    public string ObjectStatusId { get; set; } = null!;
}
