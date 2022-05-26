using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppFredy.SoalDua.Data;
using AppFredy.SoalDua.Models;

namespace AppFredy.SoalDua.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TbTestsController : ControllerBase
    {
        private readonly dbFredyDevtestContext _context;

        public TbTestsController(dbFredyDevtestContext context)
        {
            _context = context;
        }

        // GET: api/TbTests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbTest>>> GetTbTest()
        {
            if (_context.TbTest == null)
            {
                return NotFound();
            }
            return await _context.TbTest.ToListAsync();
        }

        // GET: api/TbTests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbTest>> GetTbTest(long id)
        {
            if (_context.TbTest == null)
            {
                return NotFound();
            }

            if (!checkId(id)) //check ID
            {
                return Unauthorized();
            }

            var tbTest = await _context.TbTest.FindAsync(id);

            if (tbTest == null)
            {
                return NotFound();
            }

            return tbTest;
        }

        // PUT: api/TbTests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbTest(long id, TbTest tbTest)
        {
            if (id != tbTest.Id)
            {
                return BadRequest();
            }

            if (!checkId(id)) //check ID
            {
                return Unauthorized();
            }

            _context.Entry(tbTest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbTestExists(id))
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

        // POST: api/TbTests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbTest>> PostTbTest(TbTest tbTest)
        {
            if (_context.TbTest == null)
            {
                return Problem("Entity set 'dbFredyDevtestContext.TbTest'  is null.");
            }

            #region SET ID

            string checkIdentity = Request.HttpContext.Connection.RemotePort.ToString();
            string idPart1 = DateTime.Now.ToString("yyMMddHHmmssf");


            string idtemp = idPart1 + checkIdentity;

            tbTest.Id = Convert.ToInt64(idtemp);

            #endregion

            _context.TbTest.Add(tbTest);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbTestExists(tbTest.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbTest", new { id = tbTest.Id }, tbTest);
        }

        // DELETE: api/TbTests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbTest(long id)
        {
            if (_context.TbTest == null)
            {
                return NotFound();
            }

            if (!checkId(id)) //check ID
            {
                return Unauthorized();
            }

            var tbTest = await _context.TbTest.FindAsync(id);
            if (tbTest == null)
            {
                return NotFound();
            }

            _context.TbTest.Remove(tbTest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbTestExists(long id)
        {
            return (_context.TbTest?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        #region CHECK AUTH FOR RUD
        private bool checkId(long id)
        {
            bool result = true;
            string checkIdString = id.ToString().Remove(0, 13);
            string userId = Request.HttpContext.Connection.RemotePort.ToString();

            if (checkIdString != userId)
            {
                result = false;
            }
            return result;
        }
        #endregion
    }
}
