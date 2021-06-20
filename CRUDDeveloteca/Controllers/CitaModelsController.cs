using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUDDeveloteca.Datos;
using CRUDDeveloteca.Models;

namespace CRUDDeveloteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaModelsController : ControllerBase
    {
        private readonly contextoDB _context;

        public CitaModelsController(contextoDB context)
        {
            _context = context;
        }

        // GET: api/CitaModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CitaModel>>> Getcitas()
        {
            return await _context.citas.ToListAsync();
        }

        // GET: api/CitaModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CitaModel>> GetCitaModel(int id)
        {
            var citaModel = await _context.citas.FindAsync(id);

            if (citaModel == null)
            {
                return NotFound();
            }

            return citaModel;
        }

        // PUT: api/CitaModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCitaModel(int id, CitaModel citaModel)
        {
            if (id != citaModel.id)
            {
                return BadRequest();
            }

            _context.Entry(citaModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitaModelExists(id))
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

        // POST: api/CitaModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CitaModel>> PostCitaModel(CitaModel citaModel)
        {
            _context.citas.Add(citaModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCitaModel", new { id = citaModel.id }, citaModel);
        }

        // DELETE: api/CitaModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCitaModel(int id)
        {
            var citaModel = await _context.citas.FindAsync(id);
            if (citaModel == null)
            {
                return NotFound();
            }

            _context.citas.Remove(citaModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CitaModelExists(int id)
        {
            return _context.citas.Any(e => e.id == id);
        }
    }
}
