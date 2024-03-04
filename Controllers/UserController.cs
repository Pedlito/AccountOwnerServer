using AccountOwnerServer.Contracts;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AccountOwnerServer.Controllers;

[ApiController]
[Route("api/users")]
public class UserController(IRepositoryWrapper repository, IMapper mapper) : ControllerBase
{
    private readonly IRepositoryWrapper _repository = repository;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> Get([FromQuery] UserParameters parameters)
    {
        var dbEnum = await _repository.User.GetAll(parameters);

        var metadata = dbEnum.getMetadata();

        Response.Headers.Append("Pagination", JsonConvert.SerializeObject(metadata));

        var result = _mapper.Map<IEnumerable<UserDto>>(dbEnum);
        return Ok(result);
    }

    [HttpGet("{id}", Name = "UserById")]
    public async Task<ActionResult<UserDto>> GetById(int id)
    {
        var dbItem = await _repository.User.GetById(id);
        if (dbItem is null)
        {
            return NotFound();
        }
        else
        {
            var result = _mapper.Map<UserDto>(dbItem);
            return Ok(result);
        }
    }

    [HttpPost]
    public async Task<ActionResult<UserDto>> Post([FromBody] UserPostDto data)
    {
        if (data is null)
        {
            return BadRequest("No se ingreso la información del propietario");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest("Objeto de modelo invalido");
        }

        var dbItem = _mapper.Map<User>(data);
        _repository.User.Create(dbItem);
        await _repository.SaveAsync();

        var createdItem = _mapper.Map<UserDto>(dbItem);
        return CreatedAtRoute("UserById", new { id = createdItem.Code }, createdItem);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] UserPutDto data)
    {
        var dbItem = await _repository.User.GetById(id);

        if (dbItem is null)
        {
            return NotFound();
        }

        if (data is null)
        {
            return BadRequest("No se ingreso la información del propietario");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest("Objeto de modelo invalido");
        }

        _mapper.Map(data, dbItem);
        _repository.User.Update(dbItem);
        await _repository.SaveAsync();

        return NoContent();
    }

}