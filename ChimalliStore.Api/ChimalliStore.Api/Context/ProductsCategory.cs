using System;
using System.Collections.Generic;

namespace ChimalliStore.Api.Context;

public partial class ProductsCategory
{
    public int ProducCategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public int ObjectStatusId { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
