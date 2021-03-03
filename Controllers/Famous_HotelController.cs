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
    public class Famous_HotelController : Controller
    {
        private readonly New_Zealand_MVCDatabase _context;

        public Famous_HotelController(New_Zealand_MVCDatabase context)
        {
            _context = context;
        }

        // GET: Famous_Hotel
        public async Task<IActionResult> Index()
        {
            return View(await _context.Famous_Hotel.ToListAsync());
        }

        // GET: Famous_Hotel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var famous_Hotel = await _context.Famous_Hotel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (famous_Hotel == null)
            {
                return NotFound();
            }

            return View(famous_Hotel);
        }

        // GET: Famous_Hotel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Famous_Hotel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Hotal_Name,Address,Room_Price,Room_Type")] Famous_Hotel famous_Hotel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(famous_Hotel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(famous_Hotel);
        }

        // GET: Famous_Hotel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var famous_Hotel = await _context.Famous_Hotel.FindAsync(id);
            if (famous_Hotel == null)
            {
                return NotFound();
            }
            return View(famous_Hotel);
        }

        // POST: Famous_Hotel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Hotal_Name,Address,Room_Price,Room_Type")] Famous_Hotel famous_Hotel)
        {
            if (id != famous_Hotel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(famous_Hotel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Famous_HotelExists(famous_Hotel.Id))
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
            return View(famous_Hotel);
        }

        // GET: Famous_Hotel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var famous_Hotel = await _context.Famous_Hotel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (famous_Hotel == null)
            {
                return NotFound();
            }

            return View(famous_Hotel);
        }

        // POST: Famous_Hotel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var famous_Hotel = await _context.Famous_Hotel.FindAsync(id);
            _context.Famous_Hotel.Remove(famous_Hotel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Famous_HotelExists(int id)
        {
            return _context.Famous_Hotel.Any(e => e.Id == id);
        }
    }
}
