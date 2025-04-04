using Microsoft.AspNetCore.Mvc;
using Municipality_Management_System.Data;
using Municipality_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Municipality_Management_System.Controllers
{
    public class ServiceRequestController : Controller
    {
        //Declaring and Assigning DbContext
        private readonly ApplicationDbContext _context;

        public ServiceRequestController(ApplicationDbContext context)
        {
            _context = context;
        }
        //List all serviceRequests
        public async Task<IActionResult> Index()
        {
            var serviceRequests = await _context.ServiceRequests.ToListAsync();
            return View(serviceRequests);
        }

        //Creating new serviceRequests
        [HttpGet]
        public IActionResult Create()
        {
            return View(new ServiceRequest());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ServiceRequest newServiceRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newServiceRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newServiceRequest);
        }
        //Getting Details of ServiceRequest
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var serviceRequests = await _context.ServiceRequests.FindAsync(id);
            if (serviceRequests == null)
                return NotFound();

            return View(serviceRequests);
        }
        //Editing ServiceRequest
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var serviceRequests = await _context.ServiceRequests.FindAsync(id);

            if (serviceRequests == null)
                return NotFound();

            return View(serviceRequests);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ServiceRequest editedServiceRequests)
        {

            if (id != editedServiceRequests.ServiceRequestID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(editedServiceRequests);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.ServiceRequests.Any(e => e.ServiceRequestID == editedServiceRequests.ServiceRequestID))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(editedServiceRequests);
        }
        //Delete serviceRequests
        public async Task<IActionResult> Delete(int id)
        {
            var serviceRequests = await _context.ServiceRequests.FindAsync(id);
            if (serviceRequests != null)
            {
                _context.ServiceRequests.Remove(serviceRequests);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
