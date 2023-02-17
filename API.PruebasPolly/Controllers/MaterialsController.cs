using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.PruebasPolly.Models;

namespace API.PruebasPolly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        private readonly PgsContext _context;

        public MaterialsController(PgsContext context)
        {
            _context = context;
        }

        // GET: api/Materials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PgstbMaterial>>> GetPgstbMaterials()
        {
            return await _context.PgstbMaterials.ToListAsync();
        }

        // GET: api/Materials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PgstbMaterial>> GetPgstbMaterial(Guid id)
        {
            var pgstbMaterial = await _context.PgstbMaterials.FindAsync(id);

            if (pgstbMaterial == null)
            {
                return NotFound();
            }

            return pgstbMaterial;
        }

        // PUT: api/Materials/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPgstbMaterial(Guid id, PgstbMaterial pgstbMaterial)
        {
            if (id != pgstbMaterial.CodMaterial)
            {
                return BadRequest();
            }

            _context.Entry(pgstbMaterial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PgstbMaterialExists(id))
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

        // POST: api/Materials
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PgstbMaterial>> PostPgstbMaterial(PgstbMaterial pgstbMaterial)
        {
            _context.PgstbMaterials.Add(pgstbMaterial);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PgstbMaterialExists(pgstbMaterial.CodMaterial))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPgstbMaterial", new { id = pgstbMaterial.CodMaterial }, pgstbMaterial);
        }

        // DELETE: api/Materials/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePgstbMaterial(Guid id)
        {
            var pgstbMaterial = await _context.PgstbMaterials.FindAsync(id);
            if (pgstbMaterial == null)
            {
                return NotFound();
            }

            _context.PgstbMaterials.Remove(pgstbMaterial);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PgstbMaterialExists(Guid id)
        {
            return _context.PgstbMaterials.Any(e => e.CodMaterial == id);
        }
    }
}
