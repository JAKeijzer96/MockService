#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MockService.Data;
using MockService.Models;

namespace MockService.Controllers
{
    [Route("api/contract/extension")]
    [ApiController]
    public class ContractExtensionController : ControllerBase
    {
        private readonly MockServiceContext _context;

        public ContractExtensionController(MockServiceContext context)
        {
            _context = context;
        }

        // GET: api/ContractExtension
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeContractExtension>>> GetEmployeeContractExtensions()
        {
            return await _context.EmployeeContractExtensions.ToListAsync();
        }

        // GET: api/ContractExtension/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeContractExtension>> GetEmployeeContractExtension(Guid id)
        {
            var employeeContractExtension = await _context.EmployeeContractExtensions.FindAsync(id);

            if (employeeContractExtension == null)
            {
                return NotFound();
            }

            return employeeContractExtension;
        }

        // PUT: api/ContractExtension/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeContractExtension(Guid id, EmployeeContractExtension employeeContractExtension)
        {
            if (id != employeeContractExtension.Id)
            {
                return BadRequest();
            }

            _context.Entry(employeeContractExtension).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeContractExtensionExists(id))
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

        // POST: api/ContractExtension
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeContractExtension>> PostEmployeeContractExtension(EmployeeContractExtension employeeContractExtension)
        {
            _context.EmployeeContractExtensions.Add(employeeContractExtension);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeContractExtension", new { id = employeeContractExtension.Id }, employeeContractExtension);
        }

        // DELETE: api/ContractExtension/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeContractExtension(Guid id)
        {
            var employeeContractExtension = await _context.EmployeeContractExtensions.FindAsync(id);
            if (employeeContractExtension == null)
            {
                return NotFound();
            }

            _context.EmployeeContractExtensions.Remove(employeeContractExtension);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeContractExtensionExists(Guid id)
        {
            return _context.EmployeeContractExtensions.Any(e => e.Id == id);
        }
    }
}