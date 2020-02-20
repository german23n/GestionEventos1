using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionEventos.models;

namespace GestionEventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvitadosController : ControllerBase
    {
        private readonly MyDBcontext _context;

        public InvitadosController(MyDBcontext context)
        {
            _context = context;
        }

        // GET: api/Invitados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invitados>>> Getinvitados()
        {
            return await _context.invitados.ToListAsync();
        }

        // GET: api/Invitados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Invitados>> GetInvitados(int id)
        {
            var invitados = await _context.invitados.FindAsync(id);

            if (invitados == null)
            {
                return NotFound();
            }

            return invitados;
        }

        // PUT: api/Invitados/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvitados(int id, Invitados invitados)
        {
            invitados.idInvitados = id;
            if (id != invitados.idInvitados)
            {
                return BadRequest();
            }

            _context.Entry(invitados).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvitadosExists(id))
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

        // POST: api/Invitados
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Invitados>> PostInvitados(Invitados invitados)
        {
            _context.invitados.Add(invitados);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvitados", new { id = invitados.idInvitados }, invitados);
        }

        // DELETE: api/Invitados/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Invitados>> DeleteInvitados(int id)
        {
            var invitados = await _context.invitados.FindAsync(id);
            if (invitados == null)
            {
                return NotFound();
            }

            _context.invitados.Remove(invitados);
            await _context.SaveChangesAsync();

            return invitados;
        }

        private bool InvitadosExists(int id)
        {
            return _context.invitados.Any(e => e.idInvitados == id);
        }
    }
}
