using System.Linq.Dynamic.Core.Tokenizer;
using AccountOwnerServer.Contracts;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AccountOwnerServer.Controllers;

[ApiController]
[Route("api/authentication")]
public class AuthenticationController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ITokenService _tokenService;

    public AuthenticationController(IMapper mapper, ITokenService tokenService)
    {
        _mapper = mapper;
        _tokenService = tokenService;
    }

    [HttpPost]
    public async Task<ActionResult<string?>> Get([FromBody] LoginPostDto data)
    {
        Console.WriteLine(data.UserName);
        Console.WriteLine(data.Password);
        return await _tokenService.Authenticate(data.UserName, data.Password);
    }
}