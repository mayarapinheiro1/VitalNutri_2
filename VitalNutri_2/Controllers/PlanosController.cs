using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VitalNutri_2.Models;

namespace VitalNutri_2.Controllers
{
    public class PlanosController : Controller
    {
        private readonly AppDbContext _context;
        public PlanosController(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dados = await _context.Planos.ToListAsync();
            
            return View(dados);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PlanoAlimentar planoAlimentar)
        {
            if (ModelState.IsValid)
            {
                _context.Planos.Add(planoAlimentar);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }


            return View(planoAlimentar);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id== null)
                return NotFound();

            var dados = await _context.Planos.FindAsync(id);

            if(dados==null)
                return NotFound();

            return View(dados);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PlanoAlimentar plano)
        {
            if(id != plano.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Planos.Update(plano);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
                return NotFound();
            
            var dados = await _context.Planos.FindAsync(id);

            if(dados == null)
                return NotFound();

            return View(dados);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Planos.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }

        [HttpPost, ActionName("Delete")]
        
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Planos.FindAsync(id);

            if (dados == null)
                return NotFound();

            _context.Planos.Remove(dados);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}