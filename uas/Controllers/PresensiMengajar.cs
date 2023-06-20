using BookStoreApi.Models;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BookStoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class PresensiMengajarController : ControllerBase
{
    private readonly PresensiMengajarService _PresensiMengajarService;

    public PresensiMengajarController(PresensiMengajarService PresensiMengajarService) =>
        _PresensiMengajarService = PresensiMengajarService;

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
        await _PresensiMengajarService.GetAsync();

  
    [HttpGet("{nip:length(24)}")]
    // [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status402PaymentRequired)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PresensiMengajar>> Get(string nip)
    {
        var keals = await _PresensiMengajarService.GetAsync(nip);

        if (PresensiMengajar is null)
        {
            return NotFound();
        }

        return PresensiMengajar;
    }

    
    [HttpPost]
    // [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status402PaymentRequired)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PresensiMengajar>> Post(PresensiMengajar newPresensiMengajar)
{
        await _PresensiMengajarService.CreateAsync(newPresensiMengajar);
        return CreatedAtAction(nameof(Get), new { nip = newPresensiMengajar.nip }, newPresensiMengajar);
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
    public async Task<IActionResult> Update(string nip, PresensiMengajar updatedPresensiMengajar)
    {
        var PresensiMengajar = await _PresensiMengajarService.GetAsync(nip);

        if (PresensiMengajar is null)
        {
            return NotFound();
        }

        updatedPresensiMengajar.nip = PresensiMengajar.nip;

        await _PresensiMengajarService.UpdateAsync(nip, updatedPresensiMengajar);

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
        var PresensiMengajar = await _PresensiMengajarService.GetAsync(nip);

        if (PresensiMengajar is null)
        {
            return NotFound();
        }

        await _PresensiMengajarService.RemoveAsync(nip);

        return NoContent();
    }
}