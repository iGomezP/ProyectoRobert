using System;
using System.Collections.Generic;

namespace ChimalliStore.Api.Context;

public partial class Address
{
    public int AddressId { get; set; }

    public int UserId { get; set; }

    public string Street { get; set; } = null!;

    public string Suburb { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string Cp { get; set; } = null!;

    public string Country { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int ObjectStatusId { get; set; }

}