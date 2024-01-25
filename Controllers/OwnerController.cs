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
    public ActionResult<IEnumerable<OwnerDto>> GetAllOwners()
    {
        try
        {
            var owners = _repository.Owner.GetAllOwners();

            var ownersResult = _mapper.Map<IEnumerable<OwnerDto>>(owners);
            return Ok(ownersResult);
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet("{id}")]
    public ActionResult<OwnerDto> GetOwnerById(int id)
    {
        var owner = _repository.Owner.GetOwnerById(id);

        if (owner is null)
        {
            return NotFound();
        }
        else
        {
            var ownerResult = _mapper.Map<OwnerDto>(owner);
            return Ok(ownerResult);
        }
    }
}