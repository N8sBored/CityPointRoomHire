namespace CityPoint_RoomHire.Models
{
    public class Venue
    {
        public int VenueId { get; set; }
        public string VenueName { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public int HourlyRate { get; set; }

        public ICollection<Booking>? Bookings { get; set; }
    }
}