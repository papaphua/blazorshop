﻿using BlazorShop.Server.Auth.PermissionHandler;
using BlazorShop.Server.Common;
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

    [HasPermission(Permissions.AdminPermission)]
    [HttpGet]
    public async Task<List<UserDto>> GetUsersByParameters([FromQuery] BaseParameters parameters)
    {
        var pagedList = await _userService.GetUsersByParametersAsync(parameters);

        Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pagedList.MetaData));

        return pagedList;
    }
    
    [HasPermission(Permissions.AdminPermission)]
    [HttpGet("id/{id:guid}")]
    public async Task<UserDto?> GetUserById(Guid id)
    {
        return await _userService.GetUserByIdAsync(id);
    }
    
    [HasPermission(Permissions.AdminPermission)]
    [HttpGet("username/{username}")]
    public async Task<UserDto?> GetUserByUsername(string username)
    {
        return await _userService.GetUserByUsernameAsync(username);
    }
    
    [HasPermission(Permissions.AdminPermission)]
    [HttpDelete("{id:guid}")]
    public async Task DeleteUser(Guid id)
    {
        await _userService.DeleteUserAsync(id);
    }
}