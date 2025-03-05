using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Helpers;

namespace BusinessLogicLayer.IServices
{
    public interface IUserService
    {
        Task<ResponceModel> RegisterAsync(RegisterModel registerModel);
        Task<ResponceModel> LoginAsync(LoginModel loginModel);
    }
}
