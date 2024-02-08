using AccountOwnerServer.Contracts;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace AccountOwnerServer.Controllers;

[ApiController]
[Route("api/accounts")]
public class AccountController(IRepositoryWrapper repository, IMapper mapper) : ControllerBase
{
    private readonly IRepositoryWrapper _repository = repository;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    public ActionResult<IEnumerable<AccountDto>> Get()
    {
        try
        {
            var dbEnum = _repository.Account.GetAll();

            var result = _mapper.Map<IEnumerable<AccountDto>>(dbEnum);
            return Ok(result);
        }
        catch (System.Exception)
        {   
            return StatusCode(500, "Error en el servidor");
        }
    }

    [HttpGet("{id}", Name = "AccountById")]
    public ActionResult<AccountDto> GetById(int id)
    {
        try
        {
            var dbItem = _repository.Account.GetById(id);

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
        catch (System.Exception)
        {
            return StatusCode(500, "Error en el servidor");
        }
    }

    [HttpPost]
    public ActionResult<AccountDto> Post([FromBody] AccountPostDto data)
    {
        try
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
            _repository.Save();

            var result = _mapper.Map<AccountDto>(newItem);

            return CreatedAtRoute("AccountById", new { id = newItem.Code }, result);
        }
        catch (System.Exception)
        {
            return StatusCode(500, "Error en el servidor");
        }
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] AccountPutDto data)
    {
        try
        {
            if (data is null)
            {
                return BadRequest("No se ingreso la información de la cuenta");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Objeto de modelo invalido");
            }

            var dbItem = _repository.Account.GetById(id);
            if (dbItem is null)
            {
                return NotFound();
            }

            _mapper.Map(data, dbItem);
            _repository.Account.UpdateItem(dbItem);
            _repository.Save();

            return NoContent();
        }
        catch (System.Exception)
        {
            return StatusCode(500, "Error en el servidor");
        }
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        try
        {
            var dbItem = _repository.Account.GetById(id);
            if (dbItem is null)
            {
                return NotFound();
            }

            _repository.Account.DeleteItem(dbItem);
            _repository.Save();

            return NoContent();
        }
        catch (System.Exception)
        {
            return StatusCode(500, "Error en el servidor");
        }
    }
}