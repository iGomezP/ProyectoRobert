using System;
using System.Collections.Generic;

namespace ChimalliStore.Api.Context;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public string ProducUrl { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public int ProducCategoryId { get; set; }

    public virtual ProductsCategory ProducCategory { get; set; } = null!;

    public virtual ICollection<ProductsXuser> ProductsXusers { get; set; } = new List<ProductsXuser>();
}
