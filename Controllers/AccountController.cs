using AccountOwnerServer.Contracts;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AccountOwnerServer.Controllers;

[ApiController]
[Route("api/accounts")]
public class AccountController(IRepositoryWrapper repository, IMapper mapper) : ControllerBase
{
    private readonly IRepositoryWrapper _repository = repository;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AccountDto>>> Get([FromQuery] AccountParameters parameters)
    {
        var dbEnum = await _repository.Account.GetAll(parameters);

        var metadata = new
        {
            dbEnum.TotalCount,
            dbEnum.PageSize,
            dbEnum.CurrentPage,
            dbEnum.TotalPages,
            dbEnum.HasNext,
            dbEnum.HasPrevious
        };

        Response.Headers.Append("Pagination", JsonConvert.SerializeObject(metadata));

        var result = _mapper.Map<IEnumerable<AccountDto>>(dbEnum);
        return Ok(result);
    }

    [HttpGet("{id}", Name = "AccountById")]
    public async Task<ActionResult<AccountDto>> GetById(int id)
    {
        var dbItem = await _repository.Account.GetById(id);

        if (dbItem is null)
        {
            return NotFound();
        }
        else
        {
            var result = _mapper.Map<AccountDto>(dbItem);
            return Ok(result);
        }
    }

    [HttpPost]
    public async Task<ActionResult<AccountDto>> Post([FromBody] AccountPostDto data)
    {
        if (data is null)
        {
            return BadRequest("No se ingreso la información de la cuenta");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest("Objeto de modelo invalido");
        }

        var newItem = _mapper.Map<Account>(data);

        _repository.Account.CreateItem(newItem);
        await _repository.SaveAsync();

        var result = _mapper.Map<AccountDto>(newItem);

        return CreatedAtRoute("AccountById", new { id = newItem.Code }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] AccountPutDto data)
    {
        if (data is null)
        {
            return BadRequest("No se ingreso la información de la cuenta");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest("Objeto de modelo invalido");
        }

        var dbItem = await _repository.Account.GetById(id);
        if (dbItem is null)
        {
            return NotFound();
        }

        _mapper.Map(data, dbItem);
        _repository.Account.UpdateItem(dbItem);
        await _repository.SaveAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var dbItem = await _repository.Account.GetById(id);
        if (dbItem is null)
        {
            return NotFound();
        }

        _repository.Account.DeleteItem(dbItem);
        await _repository.SaveAsync();

        return NoContent();
    }
}