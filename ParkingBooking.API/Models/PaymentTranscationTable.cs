using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ParkingBooking.API.Models
{
    public partial class PaymentTranscationTable
    {
        public Guid BookingId { get; set; }
        public string PaymentTranscationId { get; set; }
        public int AmountPaid { get; set; }
        public string StripResponse { get; set; }
        public Guid Id { get; set; }

        [JsonIgnore]
        public virtual BookingsTable Booking { get; set; }
    }
}
