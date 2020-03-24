using ElipgoBE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElipgoBE.DataSet
{
    public class LoginDataSet : ILoginDataSet
    {
        private readonly MyDbContext _context;
        public LoginDataSet(MyDbContext context)
        {
            _context = context;
        }

        public async Task<LoginResponseModel> login(string username, string password)
        {
            try
            {
                LoginModel access = await _context.Login.Where(x => x.Username == username && x.Password == password).SingleAsync();
                LoginResponseModel response = new LoginResponseModel();
                return response = LoginResponseModel.Map(access);
            } catch(Exception e)
            {
                throw e;
            }
        }
    }
}
