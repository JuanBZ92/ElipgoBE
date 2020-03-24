using ElipgoBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElipgoBE.Services
{
    public interface ILoginService
    {
        Task<LoginResponseModel> login(string username, string password);
    }
}
