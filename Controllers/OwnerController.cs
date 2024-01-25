using AccountOwnerServer.Contracts;
using AutoMapper;
using Entities.DataTransferObjects;
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
    public ActionResult<IEnumerable<OwnerDto>> GetAll()
    {
        try
        {
            var dbEnum = _repository.Owner.GetAllOwners();

            var result = _mapper.Map<IEnumerable<OwnerDto>>(dbEnum);
            return Ok(result);
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet("{id}")]
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
            return StatusCode(500, "Internal server error");
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
            return StatusCode(500, "Internal server error");
        }
    }
}