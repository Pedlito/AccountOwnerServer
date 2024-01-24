using AccountOwnerServer.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AccountOwnerServer.Controllers;

[ApiController]
[Route("api/owners")]
public class OwnerController : ControllerBase
{
    private IRepositoryWrapper _repository;

    public OwnerController(IRepositoryWrapper repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetAllOwners()
    {
        try
        {
            var owners = _repository.Owner.GetAllOwners();

            return Ok(owners);
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal server error");
        }
    }
}