using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Municipality_Management_System.Data;
using Municipality_Management_System.Models;

namespace Municipality_Management_System.Controllers
{
    public class ReportController : Controller
    {
        //Declaring and Assigning DbContext
        private readonly ApplicationDbContext _context;

        public ReportController(ApplicationDbContext context)
        {
            _context = context;
        }
        //List all Reports
        public async Task<IActionResult> Index()
        {
            var reports = await _context.Reports.ToListAsync();
            return View(reports);
        }

        //Creating new Report
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Report());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Report newReport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newReport);
        }
        //Getting Details of Report
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var report = await _context.Reports.FindAsync(id);
            if (report == null)
                return NotFound();

            return View(report);
        }
        //Editing report
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var report = await _context.Reports.FindAsync(id);

            if (report == null)
                return NotFound();

            return View(report);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Report editedReport)
        {

            if (id != editedReport.ReportID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(editedReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Reports.Any(e => e.ReportID == editedReport.ReportID))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(editedReport);
        }

            
        
        //Delete report
        public async Task<IActionResult> Delete(int id)
        {
            var report = await _context.Reports.FindAsync(id);
            if (report != null)
            {
                _context.Reports.Remove(report);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }

}
