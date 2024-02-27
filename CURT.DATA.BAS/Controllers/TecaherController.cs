using CURT.DATA.BAS.DataContext;
using CURT.DATA.BAS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CURT.DATA.BAS.Controllers
{
    public class TecaherController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TecaherController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task< IActionResult> Index()
        {
            var dat = await _context.Set<Teacher>().AsNoTracking().ToListAsync();
            return View(dat);
        }
        [HttpGet]
        public async Task<IActionResult> CertForm(int id)
        {
            if (id == 0)
            {
                return View( new Teacher());
            }
            else
            {
                var data = await _context.Set<Teacher>().FindAsync(id);
                return View(data);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CertForm(int id , Teacher teacher)
        {
            if (id == 0)
            {
                if(ModelState.IsValid)
                {
                    await _context.Set<Teacher>().AddRangeAsync(teacher);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                 _context.Set<Teacher>().Update(teacher);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            if(id != 0)
            {
                var data = await _context.Set<Teacher>().FindAsync(id);
                if(data != null)
                {
                     _context.Set<Teacher>().Remove(data);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
        public async  Task<IActionResult> Detiles(int id)
        {
           var dara = await _context.Set<Teacher>().FindAsync(id);
            return View(dara);
        }
             

        
    }
}
