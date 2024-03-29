using AccountOwnerServer.Contracts;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AccountOwnerServer.Controllers;

[ApiController]
[Route("api/owners")]
[Authorize]
public class OwnerController : ControllerBase
{
    private readonly IRepositoryWrapper _repository;
    private readonly IMapper _mapper;

    public OwnerController(IRepositoryWrapper repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OwnerDto>>> Get([FromQuery] OwnerParameters parameters)
    {
        var dbEnum = await _repository.Owner.GetAll(parameters);

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

        var result = _mapper.Map<IEnumerable<OwnerDto>>(dbEnum);
        return Ok(result);
    }

    [HttpGet("{id}", Name = "OwnerById")]
    public async Task<ActionResult<OwnerDto>> GetById(int id)
    {
        var dbItem = await _repository.Owner.GetById(id);

        if (dbItem is null)
        {
            return NotFound();
        }
        else
        {
            var result = _mapper.Map<OwnerDto>(dbItem);
            return Ok(result);
        }
    }

    [HttpGet("{id}/accounts")]
    public ActionResult<OwnerAccountsDto> GetWithDetails(int id)
    {
        var dbItem = _repository.Owner.GetWithDetails(id);

        if (dbItem is null)
        {
            return NotFound();
        }
        else
        {
            var result = _mapper.Map<OwnerAccountsDto>(dbItem);
            return Ok(result);
        }
    }

    [HttpPost]
    public async Task<ActionResult<OwnerDto>> Post([FromBody] OwnerPostDto data)
    {
        if (data is null)
        {
            return BadRequest("No se ingreso la información del propietario");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest("Objeto de modelo invalido");
        }

        var dbItem = _mapper.Map<Owner>(data);

        _repository.Owner.CreateItem(dbItem);
        await _repository.SaveAsync();

        var createdItem = _mapper.Map<OwnerDto>(dbItem);

        return CreatedAtRoute("OwnerById", new { id = createdItem.Code }, createdItem);
    }

    [HttpPost("accounts")]
    public async Task<ActionResult<OwnerDto>> PostWithAccounts([FromBody] OwnerPostAccountsDto data)
    {
        if (data is null)
        {
            return BadRequest("No se ingreso la información del propietario");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest("Objeto de modelo invalido");
        }

        var dbItem = _mapper.Map<Owner>(data);

        foreach (var accountDto in data.Accounts)
        {
            var account = _mapper.Map<Account>(accountDto);
            dbItem.AppendAccount(account);
        }

        _repository.Owner.CreateItem(dbItem);
        await _repository.SaveAsync();


        var createdItem = _mapper.Map<OwnerDto>(dbItem);
        return CreatedAtRoute("OwnerById", new { id = createdItem.Code }, createdItem);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] OwnerPutDto data)
    {
        if (data is null)
        {
            return BadRequest("No se ingreso la información del propietario");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest("Objeto de modelo invalido");
        }

        var dbItem = await _repository.Owner.GetById(id);
        if (dbItem is null)
        {
            return NotFound();
        }

        _mapper.Map(data, dbItem);
        _repository.Owner.UpdateItem(dbItem);
        await _repository.SaveAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var dbItem = await _repository.Owner.GetById(id);
        if (dbItem is null)
        {
            return NotFound();
        }

        if (_repository.Account.AccountsByOwner(id).Any())
        {
            return BadRequest("No se puede eliminar este propietario, Primero se deben de eliminar las cuentas");
        }

        _repository.Owner.DeleteItem(dbItem);
        await _repository.SaveAsync();

        return NoContent();
    }
}