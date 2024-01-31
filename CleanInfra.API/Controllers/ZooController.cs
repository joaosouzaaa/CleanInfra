using CleanInfra.API.Entities;
using CleanInfra.API.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CleanInfra.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public sealed class ZooController(IZooRepository zooRepository) : ControllerBase
{
    [HttpPost("add")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task<bool> AddAsync([FromBody] Zoo zoo) =>
        zooRepository.AddAsync(zoo);

    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task<bool> UpdateAsync([FromBody] Zoo zoo) =>
        zooRepository.UpdateAsync(zoo);

    [HttpDelete("delete")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task<bool> DeleteAsync([FromQuery] int id) =>
        zooRepository.DeleteAsync(id);

    [HttpGet("get-by-id")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Zoo))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task<Zoo?> GetByIdAsync([FromQuery] int id) =>
        zooRepository.GetByIdAsync(id);

    [HttpGet("get-all")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Zoo>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task<List<Zoo>> GetAllAsync() =>
        zooRepository.GetAllAsync();
}
