using System;
using System.Collections.Generic;

namespace ChimalliStore.Api.Context;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int ShoppingCartId { get; set; }

    public decimal TotalShoppingCart { get; set; }

    public DateTime DatetimePayment { get; set; }

    public int PaymentCarrierId { get; set; }

    public string PaymentCarrierGuid { get; set; } = null!;

    public int ObjectStatusId { get; set; }

    public virtual PaymentsCarrier PaymentCarrier { get; set; } = null!;

    public virtual ShoppingCart ShoppingCart { get; set; } = null!;
}
