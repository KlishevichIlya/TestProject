using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject_For_CoralTeam.Models;

namespace TestProject_For_CoralTeam.Services
{
    public interface IRecaptchaService
    {
        Task<RecaptchaResponse> Validate(IFormCollection form);
    }
}
