using AccountOwnerServer.Contracts;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace AccountOwnerServer.Controllers;

[ApiController]
[Route("api/owners")]
public class OwnerController : ControllerBase
{
    private IRepositoryWrapper _repository;
    private IMapper _mapper;

    public OwnerController(IRepositoryWrapper repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<OwnerDto>> Get()
    {
        try
        {
            var dbEnum = _repository.Owner.GetAllOwners();

            var result = _mapper.Map<IEnumerable<OwnerDto>>(dbEnum);
            return Ok(result);
        }
        catch (Exception)
        {
            return StatusCode(500, "Error en el servidor");
        }
    }

    [HttpGet("{id}", Name = "OwnerById")]
    public ActionResult<OwnerDto> GetById(int id)
    {
        try
        {
            var dbItem = _repository.Owner.GetOwnerById(id);

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
        catch (System.Exception)
        {
            return StatusCode(500, "Error en el servidor");
        }
    }

    [HttpGet("{id}/accounts")]
    public ActionResult<OwnerAccountsDto> GetWithDetails(int id)
    {
        try
        {
            var dbItem = _repository.Owner.GetOwnerWithDetails(id);

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
        catch (System.Exception)
        {
            return StatusCode(500, "Error en el servidor");
        }
    }

    [HttpPost]
    public ActionResult<OwnerDto> Post([FromBody] OwnerPostDto data)
    {
        try
        {
            if (data is null)
            {
                return BadRequest("No se ingreso la información del propietario");
            }

            if (!ModelState.IsValid)
            {
                Console.WriteLine("hola");
                return BadRequest("Objeto de modelo invalido");
            }

            var dbItem = _mapper.Map<Owner>(data);

            _repository.Owner.CreateOwner(dbItem);
            _repository.Save();

            var createdItem = _mapper.Map<OwnerDto>(dbItem);

            return CreatedAtRoute("OwnerById", new { id = createdItem.Code }, createdItem);
        }
        catch (System.Exception)
        {
            return StatusCode(500, "Error en el servidor");
        }
    }

    [HttpPut("{id}")]
    public ActionResult<OwnerDto> Put(int id, [FromBody] OwnerPutDto data)
    {
        try
        {
            if (data is null)
            {
                return BadRequest("No se ingreso la información del propietario");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Objeto de modelo invalido");
            }


            var dbItem = _repository.Owner.GetOwnerById(id);
            if (dbItem is null)
            {
                return NotFound();
            }

            _mapper.Map(data, dbItem);
            _repository.Owner.UpdateOwner(dbItem);
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
            var dbItem = _repository.Owner.GetOwnerById(id);
            if (dbItem is null)
            {
                return NotFound();
            }

            _repository.Owner.DeleteOwner(dbItem);
            _repository.Save();

            return NoContent();
        }
        catch (System.Exception)
        {
            return StatusCode(500, "Error en el servidor");
        }
    }
}