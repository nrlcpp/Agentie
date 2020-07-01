using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Agentie.Models;

namespace Agentie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly ReservationsDbContext _context;

        public ReservationsController(ReservationsDbContext context)
        {
            _context = context;
        }

        // GET: api/Reservations
        /// <summary>
        /// Gets a list of all the reservations.
        /// </summary>
        /// <param name="from">Filter reservations that have departureTime after this date time (inclusive). Leave blank for no filter.</param>
        /// <param name="to">Filter reservations that have departureTime before this date time (inclusive). Leave blank for no filter.</param>
        /// <returns>A list of Reservations.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations(
            [FromQuery] DateTime? from = null,
            [FromQuery] DateTime? to = null)
        {
            //Filters results by date
            IQueryable<Reservation> result = _context.Reservations;

            //if (from != null)
            //{
            //    result = result.Where(e => from <= e.Date);
       
            //}
            //if (to != null)
            //{
            //    result = result.Where(e => e.Date <= to);
            //}

            if (from != null)
            {
                result = result.Where(e => from <= e.DepartureTime);

            }
            if (to != null)
            {
                result = result.Where(e => e.DepartureTime <= to);
            }

            var resultList = await result.ToListAsync();
            return resultList;

            //return await _context.Reservations.ToListAsync();
        }

        // GET: api/Reservations/5
        /// <summary>
        /// Return an Reservations.
        /// </summary>
        /// <param name="id">The id of the selected resarvation.</param>
        /// <returns>A reservation.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservation(long id)
        {
            var reservation = await _context.Reservations.FindAsync(id);

            if (reservation == null)
            {
                return NotFound();
            }

            return reservation;
        }

        // PUT: api/Reservations/5
        /// <summary>
        /// Update a specific Reservation.
        /// </summary>
        /// <param name="id">The id of the selected reservation.</param>
        /// <param name="reservation">The updated Reservation.</param>
        /// <returns>No content.</returns>
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservation(long id, Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return BadRequest();
            }

            _context.Entry(reservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(id))
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

        // POST: api/Reservations
        /// <summary>
        /// A new reservation.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// "id": 0,
        /// "Sum": 0,
        /// "Location": "string",
        /// "date": "2020-05-31T21:38:16.201Z",
        /// "currency": "lei",
        /// "type": "stay",
        /// "DepartureTime": "2020-05-31T21:38:16.201Z",
        /// "ArrivalTime": "2020-05-31T21:38:16.201Z",
        /// "Documents":boolean,
        /// </remarks>
        /// <param name="reservation">The reservation to be added.</param>
        /// <returns>Added reservation.</returns>
        /// <response code="201">Returns the newly created reservation.</response>
        /// <response code="400">If the reservation is null.</response> 
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Reservation>> PostReservation(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReservation", new { id = reservation.Id }, reservation);
        }

        // DELETE: api/Reservations/5
        /// <summary>
        /// Delete reservation.
        /// </summary>
        /// <param name="id">The id of the reservation wich will be deleted.</param>
        /// <returns>Deleteed reservation.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Reservation>> DeleteReservation(long id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();

            return reservation;
        }

        private bool ReservationExists(long id)
        {
            return _context.Reservations.Any(e => e.Id == id);
        }
    }
}
