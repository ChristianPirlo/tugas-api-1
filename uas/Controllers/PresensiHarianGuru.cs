using BookStoreApi.Models;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BookStoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class PresensiHarianGuruController : ControllerBase
{
    private readonly PresensiHarianGuruService _PresensiHarianGuruService;

    public PresensiHarianGuruController(PresensiHarianGuruService PresensiHarianGuruService) =>
        _PresensiHarianGuruService = PresensiHarianGuruService;

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
        await _PresensiHarianGuruService.GetAsync();

  
    [HttpGet("{nip:length(24)}")]
    // [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status402PaymentRequired)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PresensiHarianGuru>> Get(string nip)
    {
        var keals = await _PresensiHarianGuruService.GetAsync(nip);

        if (PresensiHarianGuru is null)
        {
            return NotFound();
        }

        return PresensiHarianGuru;
    }

    
    [HttpPost]
    // [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status402PaymentRequired)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PresensiHarianGuru>> Post(PresensiHarianGuru newPresensiHarianGuru)
{
        await _PresensiHarianGuruService.CreateAsync(newPresensiHarianGuru);
        return CreatedAtAction(nameof(Get), new { nip = newPresensiHarianGuru.nip }, newPresensiHarianGuru);
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
    public async Task<IActionResult> Update(string nip, PresensiHarianGuru updatedPresensiHarianGuru)
    {
        var PresensiHarianGuru = await _PresensiHarianGuruService.GetAsync(nip);

        if (PresensiHarianGuru is null)
        {
            return NotFound();
        }

        updatedPresensiHarianGuru.nip = PresensiHarianGuru.nip;

        await _PresensiHarianGuruService.UpdateAsync(nip, updatedPresensiHarianGuru);

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
        var PresensiHarianGuru = await _PresensiHarianGuruService.GetAsync(nip);

        if (PresensiHarianGuru is null)
        {
            return NotFound();
        }

        await _PresensiHarianGuruService.RemoveAsync(nip);

        return NoContent();
    }
}