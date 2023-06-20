using BookStoreApi.Models;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BookStoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class KelasController : ControllerBase
{
    private readonly KelasService _kelasService;

    public KelasController(KelasService kelasService) =>
        _kelasService = kelasService;

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
        await _kelasService.GetAsync();

  
    [HttpGet("{nip:length(24)}")]
    // [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status402PaymentRequired)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Kelas>> Get(string nip)
    {
        var keals = await _kelasService.GetAsync(nip);

        if (kelas is null)
        {
            return NotFound();
        }

        return kelas;
    }

    
    [HttpPost]
    // [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status402PaymentRequired)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<kelas>> Post(kelas newkelas)
{
        await _kelasService.CreateAsync(newkelas);
        return CreatedAtAction(nameof(Get), new { nip = newkelas.nip }, newkelas);
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
    public async Task<IActionResult> Update(string nip, kelas updatedkelas)
    {
        var kelas = await _kelasService.GetAsync(nip);

        if (kelas is null)
        {
            return NotFound();
        }

        updatedkelas.nip = kelas.nip;

        await _kelasService.UpdateAsync(nip, updatedkelas);

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
        var kelas = await _kelasService.GetAsync(nip);

        if (kelas is null)
        {
            return NotFound();
        }

        await _kelasService.RemoveAsync(nip);

        return NoContent();
    }
}