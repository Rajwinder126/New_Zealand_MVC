using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using New_Zealand_MVC.Data;
using New_Zealand_MVC.Models;

namespace New_Zealand_MVC.Controllers
{
    public class BookingsController : Controller
    {
        private readonly New_Zealand_MVCDatabase _context;

        public BookingsController(New_Zealand_MVCDatabase context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            var new_Zealand_MVCDatabase = _context.Booking.Include(b => b.Attraction).Include(b => b.Event).Include(b => b.Hotel).Include(b => b.customer);
            return View(await new_Zealand_MVCDatabase.ToListAsync());
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking
                .Include(b => b.Attraction)
                .Include(b => b.Event)
                .Include(b => b.Hotel)
                .Include(b => b.customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
            ViewData["AttractionId"] = new SelectList(_context.Attraction, "Id", "Attraction_Address");
            ViewData["EventId"] = new SelectList(_context.Event, "Id", "Event_Address");
            ViewData["HotelId"] = new SelectList(_context.Famous_Hotel, "Id", "Address");
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Address");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,No_of_tickets,Ticket_price,CustomerId,HotelId,AttractionId,EventId")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AttractionId"] = new SelectList(_context.Attraction, "Id", "Attraction_Address", booking.AttractionId);
            ViewData["EventId"] = new SelectList(_context.Event, "Id", "Event_Address", booking.EventId);
            ViewData["HotelId"] = new SelectList(_context.Famous_Hotel, "Id", "Address", booking.HotelId);
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Address", booking.CustomerId);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            ViewData["AttractionId"] = new SelectList(_context.Attraction, "Id", "Attraction_Address", booking.AttractionId);
            ViewData["EventId"] = new SelectList(_context.Event, "Id", "Event_Address", booking.EventId);
            ViewData["HotelId"] = new SelectList(_context.Famous_Hotel, "Id", "Address", booking.HotelId);
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Address", booking.CustomerId);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,No_of_tickets,Ticket_price,CustomerId,HotelId,AttractionId,EventId")] Booking booking)
        {
            if (id != booking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AttractionId"] = new SelectList(_context.Attraction, "Id", "Attraction_Address", booking.AttractionId);
            ViewData["EventId"] = new SelectList(_context.Event, "Id", "Event_Address", booking.EventId);
            ViewData["HotelId"] = new SelectList(_context.Famous_Hotel, "Id", "Address", booking.HotelId);
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Address", booking.CustomerId);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking
                .Include(b => b.Attraction)
                .Include(b => b.Event)
                .Include(b => b.Hotel)
                .Include(b => b.customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Booking.FindAsync(id);
            _context.Booking.Remove(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
            return _context.Booking.Any(e => e.Id == id);
        }
    }
}
