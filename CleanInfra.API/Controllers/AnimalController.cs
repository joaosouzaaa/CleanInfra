﻿using CleanInfra.API.Entities;
using CleanInfra.API.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CleanInfra.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public sealed class AnimalController(IAnimalRepository animalRepository) : ControllerBase
{
    [HttpPost("add")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task<bool> AddAsync([FromBody] Animal animal) =>
        animalRepository.AddAsync(animal);

    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task<bool> UpdateAsync([FromBody] Animal animal) =>
        animalRepository.UpdateAsync(animal);

    [HttpDelete("delete")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task<bool> DeleteAsync([FromQuery] int id) =>
        animalRepository.DeleteAsync(id);

    [HttpGet("get-by-id")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Animal))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task<Animal?> GetByIdAsync([FromQuery] int id) =>
        animalRepository.GetByIdAsync(id);

    [HttpGet("get-all")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Animal>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task<List<Animal>> GetAllAsync() =>
        animalRepository.GetAllAsync();
}
