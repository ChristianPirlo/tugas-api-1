using BookStoreApi.Models;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BookStoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class GuruController : ControllerBase
{
    private readonly GuruService _guruService;

    public GuruController(GuruService guruService) =>
        _guruService = guruService;

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
        await _guruService.GetAsync();

  
    [HttpGet("{id:length(24)}")]
    // [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status402PaymentRequired)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Guru>> Get(string id)
    {
        var guru = await _guruService.GetAsync(id);

        if (guru is null)
        {
            return NotFound();
        }

        return guru;
    }

    
    [HttpPost]
    // [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status402PaymentRequired)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Guru>> Post(Guru newGuru)
{
        await _guruService.CreateAsync(newGuru);
        return CreatedAtAction(nameof(Get), new { id = newGuru.Id }, newGuru);
    // try
    // {
    //     if(newBook == null)
    //     {
    //         return BadRequest();
    //     }

    //     // Add custom model validation error
    //     var emp = _booksService.GetAsync(newBook.Id);

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
    public async Task<IActionResult> Update(string id, Guru updatedGuru)
    {
        var Guru = await _GuruService.GetAsync(id);

        if (Guru is null)
        {
            return NotFound();
        }

        updatedGuru.Id = guru.Id;

        await _guruService.UpdateAsync(id, updatedGuru);

        return NoContent();
    }

    
    [HttpDelete("{id:length(24)}")]
    // [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status402PaymentRequired)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string id)
    {
        var guru = await _guruService.GetAsync(id);

        if (guru is null)
        {
            return NotFound();
        }

        await _guruService.RemoveAsync(id);

        return NoContent();
    }
}