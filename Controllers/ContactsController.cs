using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TutorialProject.Data;
using TutorialProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutorialProject.Controllers
{
   [Route("api/[controller]")]
[ApiController]
public class ContactsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ContactsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // POST: api/contacts
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Contacts contact)
    {
        if (contact == null)
            return BadRequest("Invalid data.");

        _context.Contacts.Add(contact);
        await _context.SaveChangesAsync();
        return Ok(new { message = "Contact saved successfully!" });
    }
}

}
