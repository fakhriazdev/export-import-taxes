using Microsoft.AspNetCore.Mvc;
using taxex_api.model;
using taxex_api.service;

namespace taxex_api.controller;
[Route("api/country")]
[ApiController]
public class CountryController :ControllerBase
{
  private readonly CountryService CountryService;

  public CountryController(CountryService countryService)
  {
    this.CountryService = countryService;
  }
  
  [HttpGet("/")]
  public IActionResult Index() {
    return Ok(CountryService.getall());
  }
        
  [HttpGet]
  [ProducesResponseType(200)]
  [ProducesResponseType(404)]
  [ProducesResponseType(400)]
  public ActionResult<Country> GetBarang([FromQuery] string country) {
    if (country == "" || country == null ) {
      return BadRequest();
    }
    var response = CountryService.getByName(country);
    if (response == null) {
      return NotFound();
    }
    return Ok(response);
  }

  
  
}