namespace Entities.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int AddressId { get; set; }

        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }

    public class Address
    {
        public string Street { get; set; }
        public string Suit { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public int GeoId { get; set; }

        public Geo Geo { get; set; }

    }

    public class Geo
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Company
    {
        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        public string Bs { get; set; }
    }
}
