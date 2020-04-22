using System;
using System.Collections.Generic;

namespace ParkingBooking.API.Models
{
    public partial class CalenderTable
    {
        public DateTime Date { get; set; }
        public int AvailableSlots { get; set; }
        public int BookedSlots { get; set; }
        public int TotalSlots { get; set; }
    }
}
