using System;
using System.Collections.Generic;

namespace ChimalliStore.Api.Context;

public partial class ShoppingCartsXuser
{
    public int ShoppingCartXuserId { get; set; }

    public int UserId { get; set; }

    public int ShoppingCartId { get; set; }

    public int ObjectStatusId { get; set; }

    public virtual ShoppingCart ShoppingCart { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
