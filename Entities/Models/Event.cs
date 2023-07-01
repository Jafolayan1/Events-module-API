using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Event
    {
        [Column("EventId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "EventTitle is required")]
        public string EventTitle { get; set; }

        [Required(ErrorMessage = "StartDate is required")]
        public DateTimeOffset StartDate { get; set; }

        [Required(ErrorMessage = "EndDate is required")]
        public DateTimeOffset EndDate { get; set; }

        [Required(ErrorMessage = "TimeZoneInfo is required")]
        public TimeZoneInfo TimeZone { get; set; }

        [Required(ErrorMessage = "EventDescription is required")]
        public string EventDescription { get; set; }
    }

    //public class Address
    //{
    //    [Column("AddressId")]

    //    public Guid Id { get; set; }
    //    public string Street { get; set; }
    //    public string Suit { get; set; }
    //    public string City { get; set; }
    //    public string ZipCode { get; set; }
    //    public int GeoId { get; set; }
    //    public Geo Geo { get; set; }

    //}

    //public class Geo
    //{
    //    [Column("GeoId")]

    //    public Guid Id { get; set; }
    //    public double lat { get; set; }
    //    public double lng { get; set; }
    //}

    //public class Company
    //{
    //    [Column("CompanyId")]

    //    public Guid Id { get; set; }
    //    public string Name { get; set; }
    //    public string CatchPhrase { get; set; }
    //    public string Bs { get; set; }
    //}
}