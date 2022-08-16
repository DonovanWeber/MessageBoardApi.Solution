using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MessageBoard.Models;
using System.Data.SqlClient.SqlConnection;

namespace MessageBoard.Controllers
{
  [Route("api/Messages")]
  [ApiController]
  public class MessagesController : ControllerBase
  {
    private readonly MessageBoardContext _db;
    private readonly SqlConnection _connectionString;

    public MessagesController(MessageBoardContext db)
    {
      _db = db;
    }

    // GET: api/MessageBoards
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Message>>> Get(string name, string comment, string user)
    {
      var query = _db.Messages.AsQueryable();
      
      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }

      if (comment != null)
      {
        query = query.Where(entry => entry.Comment == comment);
      }    

      if (user != null)
      {
        query = query.Where(entry => entry.User == user);
      }      

      return await query.ToListAsync();
    }

    // GET: api/Messages/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Message>> GetMessage(int id)
    {
        var message = await _db.Messages.FindAsync(id);

        if (message == null)
        {
            return NotFound();
        }

        return message;
    }

    // PUT: api/Messages/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Message message)
    {
      if (id != message.MessageId)
      {
        return BadRequest();
      }

      _db.Entry(message).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!MessageExists(id))
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

    // POST: api/Message
    [HttpPost]
    public async Task<ActionResult<Message>> Post(Message message)
    {
      DateTime date1 = DateTime.Now;
      var longDateValue = date1.ToLongDateString();
      message.PostDate = longDateValue;
      _db.Messages.Add(message);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetMessage), new { id = message.MessageId}, message);
    }

    // DELETE: api/Messages/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMessage(int id)
    {
      var message = await _db.Messages.FindAsync(id);
      if (message == null)
      {
        return NotFound();
      }

      _db.Messages.Remove(message);
      await _db.SaveChangesAsync();

      return NoContent();
    }
    
    

    private bool MessageExists(int id)
    {
      return _db.Messages.Any(e => e.MessageId == id);
    }
  }
}