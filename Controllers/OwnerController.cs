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
    public IActionResult GetAllOwners()
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
}