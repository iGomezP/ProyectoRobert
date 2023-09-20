using System;
using System.Collections.Generic;

namespace ChimalliStore.Api.Context;

public partial class ProductsXorder
{
    public int IdProductXorder { get; set; }

    public int IdOrder { get; set; }

    public int IdProduct { get; set; }

    public int Quantity { get; set; }

    public decimal Total { get; set; }

    public int ObjectStatusId { get; set; }

    public virtual Order IdOrderNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}
