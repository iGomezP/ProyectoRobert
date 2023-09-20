using System;
using System.Collections.Generic;

namespace ChimalliStore.Api.Context;

public partial class Order
{
    public int OrderId { get; set; }

    public int ClientId { get; set; }

    public decimal? Total { get; set; }

    public int ObjectStatusId { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual ICollection<ProductsXorder> ProductsXorders { get; set; } = new List<ProductsXorder>();
}
