using System;
using System.Collections.Generic;

namespace ParkingBooking.API.Models
{
    public partial class BookingsTable
    {
        public Guid BookingId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CarPlate { get; set; }
        public string BookedDates { get; set; }
        public int NumberofDaysBooked { get; set; }
        public DateTime? BookedOn { get; set; }

        public virtual PaymentTranscationTable PaymentTranscationTable { get; set; }
    }
}
