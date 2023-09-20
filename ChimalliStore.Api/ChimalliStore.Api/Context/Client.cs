using System;
using System.Collections.Generic;

namespace ChimalliStore.Api.Context;

public partial class Client
{
    public int ClientId { get; set; }

    public int UserId { get; set; }

    public string MobileNumber { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int ObjectStatusId { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual User User { get; set; } = null!;
}
