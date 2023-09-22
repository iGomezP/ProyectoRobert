using System;
using System.Collections.Generic;

namespace ChimalliStore.Api.Context;

public partial class UserResponses
{
    public int UserId { get; set; }

    public int PersonId { get; set; }

    public string Alias { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int? ObjectStatusId { get; set; }

    //public string? Password { get; set; }

    public ICollection<Address> Addresses { get; set; } = new List<Address>();

    public Person Person { get; set; } = null!;

}
