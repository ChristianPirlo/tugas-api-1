using BookStoreApi.Models;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BookStoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class MapelController : ControllerBase
{
    private readonly MapelService _MapelService;

    public MapelController(MapelService MapelService) =>
        _MapelService = MapelService;

    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    [HttpGet]
    // [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status402PaymentRequired)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<List<Book>> Get() =>
        await _MapelService.GetAsync();

  
    [HttpGet("{nip:length(24)}")]
    // [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status402PaymentRequired)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Mapel>> Get(string nip)
    {
        var keals = await _MapelService.GetAsync(nip);

        if (Mapel is null)
        {
            return NotFound();
        }

        return Mapel;
    }

    
    [HttpPost]
    // [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status402PaymentRequired)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Mapel>> Post(Mapel newMapel)
{
        await _MapelService.CreateAsync(newMapel);
        return CreatedAtAction(nameof(Get), new { nip = newMapel.nip }, newMapel);
    // try
    // {
    //     if(newBook == null)
    //     {
    //         return BadRequest();
    //     }

    //     // Add custom model valnipation error
    //     var emp = _booksService.GetAsync(newBook.nip);

    //     if(emp != null)
    //     {
    //         ModelState.AddModelError("id", "id buku sudah digunakan ");
    //         return BadRequest(ModelState);
    //     }

    //     await _booksService.CreateAsync(newBook);

    //     return CreatedAtAction(nameof(Get), new { id = newBook.Id },
    //         newBook);
    // }
    // catch (Exception)
    // {
    //     return StatusCode(StatusCodes.Status500InternalServerError,
    //         "Error retrieving data from the database");
    // }
}

   
    [HttpPut("{id:length(24)}")]
    // [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status402PaymentRequired)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(string nip, Mapel updatedMapel)
    {
        var Mapel = await _MapelService.GetAsync(nip);

        if (Mapel is null)
        {
            return NotFound();
        }

        updatedMapel.nip = Mapel.nip;

        await _MapelService.UpdateAsync(nip, updatedMapel);

        return NoContent();
    }

    
    [HttpDelete("{nip:length(24)}")]
    // [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status402PaymentRequired)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string nip)
    {
        var Mapel = await _MapelService.GetAsync(nip);

        if (Mapel is null)
        {
            return NotFound();
        }

        await _MapelService.RemoveAsync(nip);

        return NoContent();
    }
}