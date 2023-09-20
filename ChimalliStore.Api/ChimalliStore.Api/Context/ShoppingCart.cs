using System;
using System.Collections.Generic;

namespace ChimalliStore.Api.Context;

public partial class ShoppingCart
{
    public int ShoppingCartId { get; set; }

    public string? ShoppingCartGuid { get; set; }

    public DateTime? CreationDate { get; set; }

    public decimal? Total { get; set; }

    public int? ObjectStatusId { get; set; }

    public virtual ICollection<ProductsXusersXshoppingCart> ProductsXusersXshoppingCarts { get; set; } = new List<ProductsXusersXshoppingCart>();

    public virtual ICollection<ShoppingCartsXuser> ShoppingCartsXusers { get; set; } = new List<ShoppingCartsXuser>();
}
