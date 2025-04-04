using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Municipality_Management_System.Data;
using Municipality_Management_System.Models;

namespace Municipality_Management_System.Controllers
{
    public class StaffController : Controller
    {
        //Declaring and Assigning DbContext
        private readonly ApplicationDbContext _context;

        public StaffController(ApplicationDbContext context)
        {
            _context = context;
        }
        //List all Staff
        public async Task<IActionResult> Index()
        {
            var staff = await _context.Staffs.ToListAsync();
            return View(staff);
        }

        //Creating new Staff
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Staff());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Staff newStaff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newStaff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newStaff);
        }

        //Getting Details of Staff
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var staff = await _context.Staffs.FindAsync(id);
            if (staff == null)
                return NotFound();

            return View(staff);
        }
        //Editing Staff
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var staff = await _context.Staffs.FindAsync(id);
            if (staff == null)
                return NotFound();

            return View(staff);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Staff editedStaff)
        {

            if (id != editedStaff.StaffID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(editedStaff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Staffs.Any(e => e.StaffID == editedStaff.StaffID))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(editedStaff);
        }

        //Delete Staff
        public async Task<IActionResult> Delete(int id)
        {
            var staff = await _context.Staffs.FindAsync(id);
            if (staff != null)
            {
                _context.Staffs.Remove(staff);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
