using Microsoft.AspNetCore.Mvc;
using project_continuation.Data;
using project_continuation.Models;

namespace project_continuation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{
    private readonly AppDbContext _context;

    public ContactController(AppDbContext context)
    {
        _context = context;
    }

// POST: api/contact
    [HttpPost]
    public async Task<IActionResult> SendMessage(ContactMessage message)
    {
        _context.ContactMessages.Add(message);
        await _context.SaveChangesAsync();
        return Ok(new { message = "Message saved successfully" });
    }

// GET: api/contact
    [HttpGet]
    public IActionResult GetMessages()
    {
        return Ok(_context.ContactMessages.ToList());
    }
}