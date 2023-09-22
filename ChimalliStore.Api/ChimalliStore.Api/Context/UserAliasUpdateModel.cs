namespace ChimalliStore.Api.Context
{
    /*
          datosOriginales  = {
        alias,
        email,

        name,
        lastName,
        maternalLastName,
        birthdate,
        genre,

        street,
        suburb,
        city,
        state,
        cp,
        country
    };
     */
    public class UserAliasUpdateModel
    {
        //Users
        public string Alias { get; set; }
        public string Email { get; set; }

        //People
        public string Name { get; set; }

        public string LastName { get; set; }

        public string MaternalLastName { get; set; } 

        public DateTime Birthdate { get; set; }

        public string Genre { get; set; }

        //Addresses
        public string Street { get; set; } 

        public string Suburb { get; set; } 

        public string City { get; set; } 

        public string State { get; set; } 

        public string Cp { get; set; } 

        public string Country { get; set; }
    }
}
