namespace CityPointRoomHire.Models
{
    public class Booking
    {
        public int BookingId { get; set; } //PK
        public string UserId { get; set; } //FK
        public int VenueId { get; set; } //FK
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalCost { get; set; }

        //Nav Property
        public Venue Venue { get; set; }
    }
}
