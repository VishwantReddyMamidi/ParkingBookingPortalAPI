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
    public class BookingsTablesController : ControllerBase
    {
        private readonly ParkingBookingPortalContext _context;

        public BookingsTablesController(ParkingBookingPortalContext context)
        {
            _context = context;
        }

        // GET: api/BookingsTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingsTable>>> GetBookingsTable()
        {

            return await _context.BookingsTable
                .Include(a=>a.PaymentTranscationTable)
                .ToListAsync();

        }

        // GET: api/BookingsTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingsTable>> GetBookingsTable(Guid id)
        {
            var bookingsTable = await _context.BookingsTable.FindAsync(id);

            if (bookingsTable == null)
            {
                return NotFound();
            }

            return bookingsTable;
        }

        // PUT: api/BookingsTables/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingsTable(Guid id, BookingsTable bookingsTable)
        {
            if (id != bookingsTable.BookingId)
            {
                return BadRequest();
            }

            _context.Entry(bookingsTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingsTableExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BookingsTables
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<BookingsTable>> PostBookingsTable(BookingsTable bookingsTable)
        {
            _context.BookingsTable.Add(bookingsTable);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookingsTableExists(bookingsTable.BookingId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBookingsTable", new { id = bookingsTable.BookingId }, bookingsTable);
        }

        // DELETE: api/BookingsTables/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookingsTable>> DeleteBookingsTable(Guid id)
        {
            var bookingsTable = await _context.BookingsTable.FindAsync(id);
            if (bookingsTable == null)
            {
                return NotFound();
            }

            _context.BookingsTable.Remove(bookingsTable);
            await _context.SaveChangesAsync();

            return bookingsTable;
        }

        private bool BookingsTableExists(Guid id)
        {
            return _context.BookingsTable.Any(e => e.BookingId == id);
        }
    }
}
