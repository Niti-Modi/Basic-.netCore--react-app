using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppReact_Core.Models;

namespace WebAppReact_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DCandidateController : ControllerBase
    {
        private readonly DonationDBContext _context;

        public DCandidateController(DonationDBContext context)
        {
            _context = context;
        }

        // GET: api/DCandidate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DCandidate>>> GetDCandidates()
        {
            return await _context.DCandidates.ToListAsync();
        }

        // GET: api/DCandidate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DCandidate>> GetDCandidate(int id)
        {
            var dCandidate = await _context.DCandidates.FindAsync(id);

            if (dCandidate == null)
            {
                return NotFound();
            }

            return dCandidate;
        }

        // PUT: api/DCandidate/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDCandidate(int id, DCandidate dCandidate)
        {
            if (id != dCandidate.id)
            {
                return BadRequest();
            }

            _context.Entry(dCandidate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DCandidateExists(id))
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

        // POST: api/DCandidate
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DCandidate>> PostDCandidate(DCandidate dCandidate)
        {
            _context.DCandidates.Add(dCandidate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDCandidate", new { id = dCandidate.id }, dCandidate);
            //added data
            //added another
            //added from main 
            //sd
            //added data from subNiti
        }

        // DELETE: api/DCandidate/5
        [HttpDelete("{id}")]//
        public async Task<IActionResult> DeleteDCandidate(int id)
        {
            var dCandidate = await _context.DCandidates.FindAsync(id);
            if (dCandidate == null)
            {
                return NotFound();
            }

            _context.DCandidates.Remove(dCandidate);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpGet("findByName/{fullname}")]
        public async Task<ActionResult<DCandidate>> GetUserByName(string fullname) {
          

                var dCandidate = await _context.DCandidates.Where(s => s.fullname == fullname).FirstOrDefaultAsync();


            return dCandidate;
        }

        [HttpGet("findByName2/{fullname}")]
        public async Task<ActionResult<DCandidate>> GetUserByName2(string fullname)
        {

            var query = "Select * from DCandidates where fullname = '" + fullname + "'";
            //Console.WriteLine("Hey Niti");
            //Console.WriteLine("HI",query);
            System.Diagnostics.Debug.WriteLine("Niti's Window");
            System.Diagnostics.Debug.WriteLine("h12",query);


            var dCandidate = await _context.DCandidates.FromSqlRaw(query ).FirstOrDefaultAsync();
            if (dCandidate==null) {
                return NotFound();
            }

            return dCandidate;
        }




        private bool DCandidateExists(int id)
        {
            return _context.DCandidates.Any(e => e.id == id);
        }
    }
}
