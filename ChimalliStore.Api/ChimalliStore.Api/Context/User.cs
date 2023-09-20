using System;
using System.Collections.Generic;

namespace ChimalliStore.Api.Context;

public partial class User
{
    public int UserId { get; set; }

    public int PersonId { get; set; }

    public string Alias { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int? ObjectStatusId { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual Person Person { get; set; } = null!;

    public virtual ICollection<ProductsXuser> ProductsXusers { get; set; } = new List<ProductsXuser>();

    public virtual ICollection<ShoppingCartsXuser> ShoppingCartsXusers { get; set; } = new List<ShoppingCartsXuser>();
}
