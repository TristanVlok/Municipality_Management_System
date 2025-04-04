using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Municipality_Management_System.Data;
using Municipality_Management_System.Models;

namespace Municipality_Management_System.Controllers
{
    public class CitizenController : Controller
    {
        //Declaring and Assigning DbContext
        private readonly ApplicationDbContext _context;
        
        public CitizenController(ApplicationDbContext context)
        {
            _context = context;
        }
        //List all Citizens
        public async Task<IActionResult> Index()
        {
            var citizens = await _context.Citizens.ToListAsync();
            return View(citizens);
        }

        //Creating new Citizen
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Citizen());
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(Citizen newCitizen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newCitizen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newCitizen);
        }

        //Getting Details of Citizen
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var citizen = await _context.Citizens.FindAsync(id);
            if (citizen == null)
                return NotFound();

            return View(citizen);
        }
        //Editing Citizen
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var citizen = await _context.Citizens.FindAsync(id);

            if (citizen == null)
                return NotFound();

            return View(citizen);
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Citizen editedCitizen)
        {

            if (id != editedCitizen.CitizenID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(editedCitizen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Citizens.Any(e => e.CitizenID == editedCitizen.CitizenID))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(editedCitizen);
        }

        //Delete Citizen
        public async Task<IActionResult> Delete(int id)
        {
            var citizen = await _context.Citizens.FindAsync(id);
            if (citizen != null)
            {
                _context.Citizens.Remove(citizen);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
