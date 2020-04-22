using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingBooking.API.Models
{
    public class GetBooking_PaymentDetails
    {
        public Guid BookingId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [Column("CarPlate#")]
        public string CarPlate { get; set; }
        public string BookedDates { get; set; }
        public int NumberofDaysBooked { get; set; }
        public DateTime? BookedOn { get; set; }
        public string PaymentTranscationId { get; set; }
        public int AmountPaid { get; set; }

    }
}
