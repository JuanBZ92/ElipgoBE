using ElipgoBE.DataSet;
using ElipgoBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElipgoBE.Services
{
    public class LoginService : ILoginService
    {
        public readonly LoginDataSet _loginDataSet;

        public LoginService(LoginDataSet loginDataSet)
        {
            _loginDataSet = loginDataSet;
        }
        public Task<LoginResponseModel> login(string username, string password)
        {
            return _loginDataSet.login(username, password);
        }
    }
}
