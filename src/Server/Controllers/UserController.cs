using BlazorShop.Server.Services.UserService;
using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Pagination.Parameters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlazorShop.Server.Controllers;

[Route("api/users")]
[ApiController]
public sealed class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<List<UserDto>> GetUsersByParameters([FromQuery] BaseParameters parameters)
    {
        var pagedList = await _userService.GetUsersByParametersAsync(parameters);

        Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pagedList.MetaData));

        return pagedList;
    }
    
    [HttpGet("id/{id:guid}")]
    public async Task<UserDto?> GetUserById(Guid id)
    {
        return await _userService.GetUserByIdAsync(id);
    }
    
    [HttpGet("username/{username}")]
    public async Task<UserDto?> GetUserByUsername(string username)
    {
        return await _userService.GetUserByUsernameAsync(username);
    }
}