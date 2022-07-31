using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCModels.DataModels;
using Front.Service.WishList;
using Front.Models.DTOModels.WishList;

namespace Front.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        private readonly IWishListService _service;

        public WishListController(IWishListService service)
        {
            _service = service;
        }


        // POST: api/WishList
        [HttpPost]
        [Route("Create")]
        public WishListApiOutputDTO CreaateWishList([FromBody] int roomId)
        {
            var userEmail = User.Identity.Name;
            var inputDto = new WishListApiInputDTO() { UserEmail = userEmail, RoomId = roomId };
            var outputDto = _service.CreateWishList(inputDto);
            //var result = new WishListApiOutputDTO() { IsSuccess=true};
            return outputDto;
        }

        // GET: api/WishList/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Room>> GetRoom(int id)
        //{
        //    var room = await _context.Rooms.FindAsync(id);

        //    if (room == null)
        //    {
        //        return NotFound();
        //    }

        //    return room;
        //}

        //// PUT: api/WishList/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutRoom(int id, Room room)
        //{
        //    if (id != room.RoomId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(room).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!RoomExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/WishList
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Room>> PostRoom(Room room)
        //{
        //    _context.Rooms.Add(room);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetRoom", new { id = room.RoomId }, room);
        //}

        //// DELETE: api/WishList/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteRoom(int id)
        //{
        //    var room = await _context.Rooms.FindAsync(id);
        //    if (room == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Rooms.Remove(room);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool RoomExists(int id)
        //{
        //    return _context.Rooms.Any(e => e.RoomId == id);
        //}
    }
}
