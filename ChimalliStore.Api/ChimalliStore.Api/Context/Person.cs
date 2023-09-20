using System;
using System.Collections.Generic;

namespace ChimalliStore.Api.Context;

public partial class Person
{
    public int PersonId { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string MaternalLastName { get; set; } = null!;

    public DateTime Birthdate { get; set; }

    public string Genre { get; set; } = null!;

    public string Country { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int ObjectStatusId { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
