using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingBooking.API.Models;

namespace ParkingBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetBooking_PaymentDetailsController : ControllerBase
    {
        private readonly ParkingBookingPortalContext _context;

        public GetBooking_PaymentDetailsController(ParkingBookingPortalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GetBooking_PaymentDetails>> GetBooking_PaymentDetails()
        {
            return _context.GetBooking_PaymentDetails
            .FromSqlRaw<GetBooking_PaymentDetails>("GetBooking_PaymentDetails").ToList();

        }
    }
}