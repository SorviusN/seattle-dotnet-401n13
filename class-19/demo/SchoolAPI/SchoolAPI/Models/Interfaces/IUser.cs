﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using SchoolAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SchoolAPI.Models.Interfaces
{
  public interface IUser
  {
    public Task<UserDto> Register(RegisterUserDto data, ModelStateDictionary modelState);
    public Task<UserDto> Login(string username, string password);

    public Task<UserDto> GetUserAsync(ClaimsPrincipal principal);
  }
}
