using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Frontdesk6.Data;
using Frontdesk6.Models.Frontdesk;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Frontdesk6.Models.Frontdesk.VM;
using Frontdesk6.Models;

namespace Frontdesk6.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly Frontdesk6Context _context;
        private UserManager<AppUser> userManager; //mengambil data user yang terdaftar dari database AppUser

        public AppointmentsController(Frontdesk6Context context, UserManager<AppUser> userMgr)
        {
            userManager = userMgr;
            _context = context;
        }
        [Authorize(Roles = "PDAD")]
        // GET: Appointments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Appointment
                .Include(a => a.LayananFrontdesk)
                .Where(b => b.StatusFrontdesk != Appointment.status.selesai)
                .ToListAsync());
        }
        public async Task<IActionResult> Index2()
        {
            return View(await _context.Appointment
                .Include(a => a.LayananFrontdesk)
                .OrderBy(a => a.StartDate)
                

                .ToListAsync());
        }

        public async Task<IActionResult> Index3()
        {

            return View();
        }
        public async Task<IActionResult> Index4(string SearchString)
        {
            ViewData["CurrentFilter"] = SearchString;

            var appointment = from a in _context.Appointment.Include(a => a.LayananFrontdesk)
                              select a;
            if (!String.IsNullOrEmpty(SearchString))
            {
                appointment = appointment.Where(s => s.NomorApp.Equals(SearchString));
            }
            else
            {
                appointment = appointment.Take(0);
            }
            return View(await appointment.AsNoTracking()
                .ToListAsync());
        }
        public async Task<IActionResult> Informasi()
        {
            return View(await _context.Appointment
                .Include(a => a.LayananFrontdesk)
                .OrderBy(a => a.StartDate)
                .Where(a => a.NamaLayanan.Contains("HACCP") || a.NamaLayanan.Contains("CKIB") || a.NamaLayanan.Contains("KUSUKA") || a.NamaLayanan.Contains("PPK") || a.NamaLayanan.Contains("Sampel"))
                .Where(b => b.StatusFrontdesk != Appointment.status.selesai)

                .ToListAsync());
        }
        public async Task<IActionResult> Informasi2()
        {
            return View(await _context.Appointment
                .Include(a => a.LayananFrontdesk)
                .OrderBy(a => a.StartDate)
                .Where(a => a.NamaLayanan.Contains("HACCP") || a.NamaLayanan.Contains("CKIB") || a.NamaLayanan.Contains("KUSUKA") || a.NamaLayanan.Contains("PPK") || a.NamaLayanan.Contains("Sampel"))
                .Where(b => b.StatusFrontdesk == Appointment.status.selesai)

                .ToListAsync());
        }
        public async Task<IActionResult> Surat()
        {
            return View(await _context.Appointment
                .Include(a => a.LayananFrontdesk)
                .OrderBy(a => a.StartDate)
                .Where(o => o.NamaLayanan.Contains("Surat") || o.NamaLayanan.Contains("Lainnya"))
                .Where(b => b.StatusFrontdesk != Appointment.status.selesai)

                .ToListAsync());
        }
        public async Task<IActionResult> Surat2()
        {
            return View(await _context.Appointment
                .Include(a => a.LayananFrontdesk)
                .OrderBy(a => a.StartDate)
                .Where(o => o.NamaLayanan.Contains("Surat") || o.NamaLayanan.Contains("Lainnya"))
                .Where(b => b.StatusFrontdesk == Appointment.status.selesai)

                .ToListAsync());
        }
        public async Task<IActionResult> InSisterkaroline()
        {
            return View(await _context.Appointment
                .Include(a => a.LayananFrontdesk)
                .OrderBy(a => a.StartDate)
                .Where(o => o.NamaLayanan.Contains("Sisterkaroline"))
                .Where(b => b.StatusFrontdesk != Appointment.status.selesai)

                .ToListAsync());
        }
        public async Task<IActionResult> InSisterkaroline2()
        {
            return View(await _context.Appointment
                .Include(a => a.LayananFrontdesk)
                .OrderBy(a => a.StartDate)
                .Where(o => o.NamaLayanan.Contains("Sisterkaroline"))
                .Where(b => b.StatusFrontdesk == Appointment.status.selesai)

                .ToListAsync());
        }
        public async Task<IActionResult> Display()
        {
            return View(await _context.Appointment.ToListAsync());
        }
        // GET: Appointments/Details/5
        public ActionResult DetailsView(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewModel mymodel = new ViewModel();



            return View(mymodel);
        }
        public async Task<ActionResult> Count()
        {

            IQueryable<CountViewModel> data =
                from appointment in _context.Appointment.Where(a => a.StatusFrontdesk != Appointment.status.selesai)
                group appointment by appointment.Tanggal.Date into dategroup

                select new CountViewModel()
                {
                    TotalHari = dategroup.Key,
                    DateCount = dategroup.Count(),
                    yourlife = dategroup.Count() + 1

                };
            return View(await data.AsNoTracking().ToListAsync());
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }



            var appointment = await _context.Appointment
                .Include(a => a.LayananFrontdesk)
                .FirstOrDefaultAsync(m => m.AppointmentID == id);



            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET: Appointments/Create
        public IActionResult Create()
        {
           
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppointmentID,Nama,Email,NomorApp,Tanggal,Subject,Deskripsi,Tujuan")] Appointment appointment)
        {


            
            
            
            
                if (ModelState.IsValid)
                {


                    
                    appointment.StartDate = DateTime.Now;
                    appointment.StatusFrontdesk = Appointment.status.mulai;
                    

                    _context.Add(appointment);

                    await _context.SaveChangesAsync();
                    return RedirectToAction("NoAdd", new { id = appointment.AppointmentID });
                }
            
                

           
            return View(appointment);
        }
        [HttpGet("Appointments/NoAdd/{Id}")]

        public async Task<IActionResult> NoAdd(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monitoring = await _context.Appointment

                 .Include(c => c.LayananFrontdesk)
                


                .FirstOrDefaultAsync(m => m.AppointmentID == id);
            if (monitoring == null)
            {
                return NotFound();
            }
            PopulateLayananDropdownList(monitoring.NamaLayanan);
            
            return View(monitoring);
        }

        // POST: Pendoks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Appointments/NoAdd/{Id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNoSister(string? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }
            var monitaToUpdate = await _context.Appointment
                 .Include(c => c.LayananFrontdesk)
               


                  .FirstOrDefaultAsync(c => c.AppointmentID == id);
            var nomor = DateTime.Now.Ticks.ToString();
            var nomorl = nomor.Substring(nomor.Length - 5);
            var tjn = monitaToUpdate.NamaLayanan;
            var tjn2 = tjn.Substring(0, 1);
            if (await TryUpdateModelAsync<Appointment>(monitaToUpdate,
                "",
               a => a.NamaLayanan, b => b.Tujuan))
            {
                try
                {
                    monitaToUpdate.NomorApp = tjn2 + "-" + nomorl;
                    monitaToUpdate.StatusFrontdesk = Appointment.status.mulai;


                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes");
                }
                return RedirectToAction(nameof(Index));
            }
            PopulateLayananDropdownList(monitaToUpdate.NamaLayanan);
            

            return View(monitaToUpdate);
        }
        [HttpGet("Appointments/Sisterkaroline/{Id}")]

        public async Task<IActionResult> Sisterkaroline(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monitoring = await _context.Appointment

                 .Include(c => c.LayananFrontdesk)



                .FirstOrDefaultAsync(m => m.AppointmentID == id);
            if (monitoring == null)
            {
                return NotFound();
            }
            PopulateLayananDropdownList(monitoring.NamaLayanan);

            return View(monitoring);
        }

        // POST: Pendoks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Appointments/Sisterkaroline/{Id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSisterkaroline(string? id)
        {

            if (id == null)
            {
                return NotFound();
            }
           
            var monitaToUpdate = await _context.Appointment
                 .Include(c => c.LayananFrontdesk)



                  .FirstOrDefaultAsync(c => c.AppointmentID == id);
            var nomor = DateTime.Now.Ticks.ToString();
            var nomorl = nomor.Substring(nomor.Length - 5);
            var tjn = "Sisterkaroline";
            var tjn2 = tjn.Substring(0, 1);
            if (await TryUpdateModelAsync<Appointment>(monitaToUpdate,
                "",
               a => a.NamaLayanan, b => b.Tujuan))
            {
                try
                {
                    monitaToUpdate.NomorApp = tjn2 + "-" + nomorl;
                    monitaToUpdate.StatusFrontdesk = Appointment.status.mulai;
                    monitaToUpdate.NamaLayanan = "Sisterkaroline";

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes");
                }
                return RedirectToAction(nameof(Index));
            }
            PopulateLayananDropdownList(monitaToUpdate.NamaLayanan);


            return View(monitaToUpdate);
        }
        [HttpGet("Appointments/NoSisterkaroline/{Id}")]

        public async Task<IActionResult> NoSisterkaroline(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monitoring = await _context.Appointment

                 .Include(c => c.LayananFrontdesk)



                .FirstOrDefaultAsync(m => m.AppointmentID == id);
            if (monitoring == null)
            {
                return NotFound();
            }
            PopulateLayananDropdownList(monitoring.NamaLayanan);

            return View(monitoring);
        }

        // POST: Pendoks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Appointments/NoSisterkaroline/{Id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNoSisterkaroline(string? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var monitaToUpdate = await _context.Appointment
                 .Include(c => c.LayananFrontdesk)



                  .FirstOrDefaultAsync(c => c.AppointmentID == id);
            
            if (await TryUpdateModelAsync<Appointment>(monitaToUpdate,
                "",
               a => a.NamaLayanan, b => b.Tujuan))
            {
                try
                {
                    var nomor = DateTime.Now.Ticks.ToString();
                    var nomorl = nomor.Substring(nomor.Length - 5);
                    var tjn = monitaToUpdate.NamaLayanan;
                    var tjn2 = tjn.Substring(0, 1);

                    monitaToUpdate.NomorApp = tjn2 + "-" + nomorl;
                    monitaToUpdate.StatusFrontdesk = Appointment.status.mulai;


                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes");
                }
                return RedirectToAction(nameof(Index));
            }
            PopulateLayananDropdownList(monitaToUpdate.NamaLayanan);


            return View(monitaToUpdate);
        }
        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("AppointmentID,Nama,Email,NomorApp,Tanggal,Subject,Deskripsi,Tujuan,NamaLayanan,StartDate,EndDate,ProcessDate,StatusFrontdesk")] Appointment appointment)
        {
            if (id != appointment.AppointmentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.AppointmentID))
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
            return View(appointment);
        }
        public async Task<IActionResult> Proses(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pendok = await _context.Appointment
                 .Include(a => a.LayananFrontdesk)

                .FirstOrDefaultAsync(m => m.AppointmentID == id);
            if (pendok == null)
            {
                return NotFound();
            }
            ViewBag.returnUrl = Request.Headers["Referer"].ToString();
            return View(pendok);
        }

        // POST: Pendoks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Proses")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProsesApp(string id, string returnUrl)
        {
            if (id == null)
            {
                return NotFound();
            }
            var pendokToUpdate = await _context.Appointment
                .Include(a => a.LayananFrontdesk)


                .FirstOrDefaultAsync(m => m.AppointmentID == id);

            if (await TryUpdateModelAsync<Appointment>(pendokToUpdate,
                "",
               a => a.StatusFrontdesk))
            {
                try
                {
                    pendokToUpdate.StatusFrontdesk = Appointment.status.proses;
                    pendokToUpdate.ProcessDate = DateTime.Now;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes");
                }
                return Redirect(returnUrl);

            }


            return View(pendokToUpdate);
        }
        public async Task<IActionResult> Selesai(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pendok = await _context.Appointment
                 .Include(a => a.LayananFrontdesk)

                .FirstOrDefaultAsync(m => m.AppointmentID == id);
            if (pendok == null)
            {
                return NotFound();
            }
            ViewBag.returnUrl = Request.Headers["Referer"].ToString();
            return View(pendok);
        }

        // POST: Pendoks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Selesai")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SelesaiApp(string id, string returnUrl)
        {
            if (id == null)
            {
                return NotFound();
            }
            var pendokToUpdate = await _context.Appointment
                .Include(a => a.LayananFrontdesk)


                .FirstOrDefaultAsync(m => m.AppointmentID == id);

            if (await TryUpdateModelAsync<Appointment>(pendokToUpdate,
                "",
               a => a.StatusFrontdesk))
            {
                try
                {
                    pendokToUpdate.StatusFrontdesk = Appointment.status.selesai;
                    pendokToUpdate.EndDate = DateTime.Now;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes");
                }
                return Redirect(returnUrl);
            }


            return View(pendokToUpdate);
        }
        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment
                .FirstOrDefaultAsync(m => m.AppointmentID == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var appointment = await _context.Appointment.FindAsync(id);
            _context.Appointment.Remove(appointment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool AppointmentExists(string id)
        {
            return _context.Appointment.Any(e => e.AppointmentID == id);
        }

        private void PopulateLayananDropdownList(object selectedPendok = null)
        {
            var pendoksQuery = from d in _context.LayananFrontdesk
                               orderby d.NamaLayanan
                               select d;
            ViewBag.NamaLayanan = new SelectList(pendoksQuery.AsNoTracking(), "NamaLayanan", "NamaLayanan", selectedPendok);
        }
    }
}
