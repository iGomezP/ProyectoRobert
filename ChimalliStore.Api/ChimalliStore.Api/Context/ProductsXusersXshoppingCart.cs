using System;
using System.Collections.Generic;

namespace ChimalliStore.Api.Context;

public partial class ProductsXusersXshoppingCart
{
    public int ProductXuserXshoppingCartId { get; set; }

    public int ShoppingCartId { get; set; }

    public int ProductXuserId { get; set; }

    public int ObjectStatus { get; set; }

    public virtual ProductsXuser ProductXuser { get; set; } = null!;

    public virtual ShoppingCart ShoppingCart { get; set; } = null!;
}
