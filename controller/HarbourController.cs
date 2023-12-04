using Microsoft.AspNetCore.Mvc;
using taxex_api.service;
using taxex_api.model;
namespace taxex_api.controller;

[Route("api/harbour")]
public class HarbourController: ControllerBase
{
    private readonly HarbourService harbourService;

    public HarbourController(HarbourService harbourService)
    {
        this.harbourService = harbourService;
    }
    
    [HttpGet("/")]
    public IActionResult Index() {
        return Ok(harbourService.getall());
    }
        
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public IActionResult GetItems([FromQuery] string harbour, [FromQuery] string kd_country) {
        if (harbour == "" || harbour == null ) {
            return BadRequest();
        }
        var response = harbourService.getByName(harbour, kd_country);
        if (response == null) {
            return NotFound();
        }
        return Ok(response);
    }
    
}