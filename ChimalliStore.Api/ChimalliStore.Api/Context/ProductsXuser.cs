using System;
using System.Collections.Generic;

namespace ChimalliStore.Api.Context;

public partial class ProductsXuser
{
    public int ProductXuserId { get; set; }

    public int ProductId { get; set; }

    public int UserId { get; set; }

    public int Quantity { get; set; }

    public decimal Subtotal { get; set; }

    public int ObjectStatusId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual ICollection<ProductsXusersXshoppingCart> ProductsXusersXshoppingCarts { get; set; } = new List<ProductsXusersXshoppingCart>();

    public virtual User User { get; set; } = null!;
}
